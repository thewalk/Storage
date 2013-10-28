using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Model;
namespace Storage.DataLogic
{
    public static class ConfigLogic
    {
        static StorageDataContext storageDataContext = new StorageDataContext();
 
        #region Operation On Contact
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
        public static void delContact(Contact contact)
        {
            storageDataContext.Contact.DeleteOnSubmit(contact);
            storageDataContext.SubmitChanges();
        }
        public static void addContact(Contact contact)
        {
            storageDataContext.Contact.InsertOnSubmit(contact);
            storageDataContext.SubmitChanges();
        }
        public static void updContact()
        {
            storageDataContext.SubmitChanges();
        }

        #endregion

        #region Operation On Kind
        public static ObservableCollection<Kind> getAllKind()
        {
            ObservableCollection<Kind> KindList = new ObservableCollection<Kind>();
            var result = from kind in storageDataContext.Kind select kind;
            foreach (Kind kind in result)
            {
                KindList.Add(kind);
            }
            return KindList;
        }
        public static void delKind(Kind kind)
        {
            storageDataContext.Kind.DeleteOnSubmit(kind);
            storageDataContext.SubmitChanges();
        }
        public static void addKind(Kind kind)
        {
            storageDataContext.Kind.InsertOnSubmit(kind);
            storageDataContext.SubmitChanges();
        }
        public static void updKind()
        {
            storageDataContext.SubmitChanges();
        }
        #endregion

        #region Operation On  Pit
        public static ObservableCollection<Pit> getAllPit()
        {
            ObservableCollection<Pit> PitList = new ObservableCollection<Pit>();
            var result = from pit in storageDataContext.Pit select pit;
            foreach (Pit pit in result)
            {
                PitList.Add(pit);
            }
            return PitList;
        }
        public static void delPit(Pit pit)
        {
            storageDataContext.Pit.DeleteOnSubmit(pit);
            storageDataContext.SubmitChanges();
        }
        public static void addPit(Pit pit)
        {
            storageDataContext.Pit.InsertOnSubmit(pit);
            storageDataContext.SubmitChanges();
        }
        public static void updPit()
        {
            storageDataContext.SubmitChanges();
        }
        #endregion

    }
}
