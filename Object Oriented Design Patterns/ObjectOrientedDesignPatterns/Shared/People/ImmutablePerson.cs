namespace ObjectOrientedDesignPatterns.Shared.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ImmutablePerson
    {
        public ImmutablePerson(List<string> names, DateTime birthDate, ImmutableAddress placeOfBirth, string favouriteColor, ImmutableAddress address)
        {
            this.Names = names;
            this.BirthDate = birthDate;
            this.PlaceOfBirth = placeOfBirth;
            this.FavouriteColor = favouriteColor;
            this.CurrentAddress = address;
        }

        public List<string> Names { get; }

        public string FirstName => this.Names.First();

        public string LastName => this.Names.Last();

        public DateTime BirthDate { get; }

        public int Age => (int)((DateTime.Now - this.BirthDate).TotalDays / 365);

        public string FavouriteColor { get; }

        public ImmutableAddress PlaceOfBirth { get; }

        public ImmutableAddress CurrentAddress { get; }
    }
}