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
            ContactList = ContactLogic.getAllContact();
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
