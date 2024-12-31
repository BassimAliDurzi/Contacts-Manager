using System;
namespace ContactsManager.Core.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public Contact(string firstName, string lastName, string street, string postcode, string city)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Street = street;
            PostCode = postcode;
            City = city;
        }

        public override string ToString()
        {
            return $"\nContact information: " +
                $"\nName: {FirstName} {LastName}" +
                $"\nEmail: {Email}" +
                $"\nPhone Number: {PhoneNumber}" +
                $"\nAddress: {Street}, {PostCode} {City}";
        }
    }
}
