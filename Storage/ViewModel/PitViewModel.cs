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
    public  class PitViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Pit> pitList;
        public ObservableCollection<Pit> PitList
        {
            get
            {
                return pitList;
            }
            set
            {
                pitList = value;
                OnPropertyChanged("pitList");
            }
        }
        public PitViewModel()
        {
            PitList = ConfigLogic.getAllPit();
            PitList.CollectionChanged += pitList_CollectionChanged;
        }
        public PitViewModel(ObservableCollection<Pit> list)
        {
            PitList = list;
            PitList.CollectionChanged += pitList_CollectionChanged;
        }

        void pitList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (Pit oldPit in e.OldItems)
                {
                    ConfigLogic.delPit(oldPit);
                }
            }
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (Pit newPit in e.NewItems)
                {
                    ConfigLogic.addPit(newPit);
                }
            }
        }

        public void PitUpd()
        {
            ConfigLogic.updPit();
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
