using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactsManager.Core.Models;

namespace ContactsManager.Core.Services
{
    public class ContactService : IContactService
    {

        private readonly List<Contact> contacts;

        public ContactService()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            contacts.Add(contact);
        }

        public void DeleteContact(Guid id)
        {
            var contact = GetContactById(id);
            if (contact == null)
            {
                throw new InvalidCastException($"Contact ID {id} not found");
            }

            contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public Contact GetContactById(Guid id)
        {
            return contacts.FirstOrDefault(contact => contact.Id == id);
        }

        public void UpdateContact(Contact updatedContact)
        {
            if (updatedContact == null) throw new ArgumentNullException(nameof(updatedContact));

            var contact = GetContactById(updatedContact.Id);
            if (contact == null) throw new InvalidCastException($"Contact  id {updatedContact.Id} not found");

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Email = updatedContact.Email;
            contact.PhoneNumber = updatedContact.PhoneNumber;
            contact.Street = updatedContact.Street;
            contact.PostCode = updatedContact.PostCode;
            contact.City = updatedContact.City;
        }

        public void LoadFromJson(string filePath)
        {
            throw new NotImplementedException();
        }

        public void SaveAsJson(string filePath)
        {
            throw new NotImplementedException();
        }


    }
}
