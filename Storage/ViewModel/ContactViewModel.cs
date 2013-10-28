using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DataLogic;
using Storage.Model;

namespace Storage.ViewModel
{
    public class ContactViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Contact> contactList;
        public ObservableCollection<Contact> ContactList
        {
            get
            {
                return contactList;
            }
            set
            {
                contactList = value;
                OnPropertyChanged("contactList");
            }
        }
        public ContactViewModel()
        {
            ContactList = ConfigLogic.getAllContact();
            ContactList.CollectionChanged += ContactList_CollectionChanged;
        }

        void ContactList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (Contact oldContact in e.OldItems)
                {
                    ConfigLogic.delContact(oldContact);
                }
            }
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (Contact newContact in e.NewItems)
                {
                    ConfigLogic.addContact(newContact);
                }
            }
        }
        public void ContactUpd()
        {
            ConfigLogic.updContact();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
