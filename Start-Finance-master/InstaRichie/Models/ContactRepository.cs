using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    public class ContactRepository : IContactRepository
    {
        string path;
        SQLiteConnection conn;

        public ContactRepository(string dbName)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalCacheFolder.Path, dbName);
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Contact>();
        }

        public bool DeleteContact(int contactId)
        {
            Contact c = GetContactById(contactId);
            if (conn.Delete(c) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Contact> GetContact()
        {
            return conn.Table<Contact>().OrderBy(c => c.FirstName).ToList();
        }

        public IEnumerable<List<Contact>> GetContactList()
        {
            return conn.Table<List<Contact>>().ToList();
        }

        public Contact GetContactById(int contactId)
        {
            var contact = conn.Table<Contact>().ToList();
            return contact.First(c => c.ContactID == contactId);
        }

        public bool InsertContact(Contact contact)
        {
            if (conn.Insert(contact) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateContact(Contact contact)
        {
            if (conn.Update(contact) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
