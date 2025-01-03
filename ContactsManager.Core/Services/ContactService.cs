using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactsManager.Core.Models;
using Newtonsoft.Json;
using System.IO;

namespace ContactsManager.Core.Services
{
    public class ContactService : IContactService
    {

        private readonly List<Contact> contacts;
        private readonly ContactJsonFileManager fileManager;

        public ContactService(ContactJsonFileManager fileManager)
        {
            contacts = new List<Contact>();
            fileManager = fileManager ?? throw new ArgumentNullException(nameof(fileManager));
        }

        public List<Contact> GetAllContacts() => contacts;

        public Contact GetContactById(Guid id) => contacts.FirstOrDefault(contact => contact.Id == id);

        public void AddContact(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            contacts.Add(contact);
        }

        public void UpdateContact(Contact updatedContact)
        {
            if (updatedContact == null) throw new ArgumentNullException(nameof(updatedContact));
            var contact = GetContactById(updatedContact.Id);

            if (contact == null) throw new InvalidOperationException($"Contact Id {updatedContact.Id} not found");

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Email = updatedContact.Email;
            contact.PhoneNumber = updatedContact.PhoneNumber;
            contact.Street = updatedContact.Street;
            contact.PostCode = updatedContact.PostCode;
            contact.City = updatedContact.City;
        }

        public void DeleteContact(Guid id)
        {
            var contact = GetContactById(id);
            if (contact == null) throw new InvalidOperationException($"Contact Id {id} not found.");
        }

        public void SaveAsJson(string filePath, List<Contact> contacts) => fileManager.SaveAsJson(filePath, contacts);


        public void LoadFromJson(string filePath)
        {
            var contacts = fileManager.LoadFromFile(filePath);
            contacts.Clear();
            contacts.AddRange(contacts);
        }
    }
}
