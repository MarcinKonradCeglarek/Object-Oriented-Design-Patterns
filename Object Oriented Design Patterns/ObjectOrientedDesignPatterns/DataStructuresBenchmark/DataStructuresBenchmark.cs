namespace ObjectOrientedDesignPatterns.DataStructuresBenchmark
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using ObjectOrientedDesignPatterns.Shared.People;

    using Xunit;

    public class DataStructuresBenchmark
    {
        private const int TotalCount = 20000;

        private const int SearchCount = 2000;

        private readonly Random random = new Random();

        private readonly Stopwatch stopwatch = new Stopwatch();

        private readonly List<Guid> guidsToFind = new List<Guid>();

        [Fact]
        public void DataStructuresBenchmark_IEnumerable()
        {
            var ids = Enumerable.Range(0, TotalCount).Select(x => Guid.NewGuid()).ToList();
            var people = ids.Select(id => new ImmutablePerson(id, id.ToString().Split('-').ToList(), DateTime.MinValue, this.GenerateAddress(), "Black", this.GenerateAddress()))
                .ToList();

            for (var i = 0; i < SearchCount; i++)
            {
                this.guidsToFind.Add(ids.Skip(this.random.Next(TotalCount - 1)).Take(1).Single());
            }

            var sortedList = this.Generate<SortedList<Guid, ImmutablePerson>>("SortedList", people, (obj, person) => obj.Add(person.Id, person));
            var hashSet = this.Generate<HashSet<ImmutablePerson>>("HashSet", people, (hashset, person) => hashset.Add(person));
            var dictionary = this.Generate<Dictionary<Guid, ImmutablePerson>>("Dictionary", people, (dict, person) => dict.Add(person.Id, person));

            this.Test("Index on SortedList", sortedList, (sortedlist, guid) => sortedlist[guid]);
            this.Test("First on hashset", hashSet, (hashset, guid) => hashset.First(x => x.Id == guid));
            this.Test("Last on hashset", hashSet, (hashset, guid) => hashset.Last(x => x.Id == guid));
            this.Test("Single on hashset", hashSet, (hashset, guid) => hashset.Single(x => x.Id == guid));
            this.Test("Index on Dictionary", dictionary, (dict, guid) => dict[guid]);
            this.Test("Find in a Dictionary", dictionary, (dict, guid) => dict.First(e => e.Value.Id == guid).Value);
        }

        private T Generate<T>(string type, IEnumerable<ImmutablePerson> set, Action<T, ImmutablePerson> addToSetAction)
            where T : new()
        {
            this.stopwatch.Start();
            var retVal = new T();

            foreach (var immutablePerson in set)
            {
                addToSetAction(retVal, immutablePerson);
            }

            this.stopwatch.Stop();
            Trace.TraceInformation($"Creating {type} took {this.stopwatch.Elapsed}");
            this.stopwatch.Reset();

            return retVal;
        }

        private long Test<T>(string type, T set, Func<T, Guid, ImmutablePerson> expression)
        {
            this.stopwatch.Start();
            foreach (var guidToFind in this.guidsToFind)
            {
                var found = expression(set, guidToFind);
            }

            this.stopwatch.Stop();
            Trace.TraceInformation($"{type} search took {this.stopwatch.Elapsed}");
            var milliseconds = this.stopwatch.ElapsedMilliseconds;
            this.stopwatch.Reset();

            return milliseconds;
        }

        private ImmutableAddress GenerateAddress()
        {
            return new ImmutableAddress(
                $"Country_{this.random.Next(5)}",
                $"City_{this.random.Next(20)}",
                $"PostCode_{this.random.Next(20)}",
                "Street",
                this.random.Next(200),
                0,
                0);
        }
    }
}