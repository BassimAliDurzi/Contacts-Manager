using System;
using System.Collections.Generic;
using System.IO;
using ContactsManager.Core.Models;
using Newtonsoft.Json;


namespace ContactsManager.Core.Services
{
    public class ContactJsonFileManager
    {
        public void SaveAsJson(string filePath, List<Contact> contacts)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException("File path should not be epmty");

            string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }


        public List<Contact> LoadFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Contact>>(json) ?? new List<Contact>();
        }
    }
}
