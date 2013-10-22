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
    class KindViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Kind> kindList;
        public ObservableCollection<Kind> KindList
        {
            get
            {
                return kindList;
            }
            set
            {
                kindList = value;
                OnPropertyChanged("kindList");
            }
        }
        public KindViewModel()
        {
            kindList = KindLogic.getAllKind();
            kindList.CollectionChanged += kindList_CollectionChanged;
        }

        void kindList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (Kind oldKind in e.OldItems)
                {
                    KindLogic.delKind(oldKind);
                }
            }
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (Kind newKind in e.NewItems)
                {
                    KindLogic.addKind(newKind);
                }
            }
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
