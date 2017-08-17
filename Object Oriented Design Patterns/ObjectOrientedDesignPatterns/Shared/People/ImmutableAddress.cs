namespace ObjectOrientedDesignPatterns.Shared.People
{
    public class ImmutableAddress
    {
        public ImmutableAddress(string country, string city, string postCode, string street, int houseNumber, int? flatNumber, int? roomNumber)
        {
            this.Country = country;
            this.City = city;
            this.PostCode = postCode;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.FlatNumber = flatNumber;
            this.RoomNumber = roomNumber;
        }

        public string Country { get; }

        public string Street { get; }

        public string PostCode { get; }

        public string City { get; }

        public int HouseNumber { get; }

        public int? FlatNumber { get; }

        public int? RoomNumber { get; }
    }
}