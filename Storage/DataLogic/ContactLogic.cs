using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Model;
namespace Storage.DataLogic
{
    public static class ContactLogic
    {
        static StorageDataContext storageDataContext = new StorageDataContext();
        public static ObservableCollection<Contact> getAllContact()
        {
            ObservableCollection<Contact> ContactList = new ObservableCollection<Contact>();
            var result = from contact in storageDataContext.Contact select contact;
            foreach (Contact contact in result)
            {
                ContactList.Add(contact);
            }
            return ContactList;
        }
    }
}
