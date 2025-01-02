using System;
using System.Collections.Generic;
using ContactsManager.Core.Models;

namespace ContactsManager.Core.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();

        Contact GetContactById(Guid id);

        void AddContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(Guid id);

        void SaveAsJson(string filePath);

        void LoadFromJson(string filePath);

    }
}
