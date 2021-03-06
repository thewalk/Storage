﻿using System;
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
    public class KindViewModel : INotifyPropertyChanged
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
            KindList = ConfigLogic.getAllKind();
            KindList.CollectionChanged += kindList_CollectionChanged;
        }
        public KindViewModel(ObservableCollection<Kind> list)
        {
            KindList = list;
            KindList.CollectionChanged += kindList_CollectionChanged;
        }

        void kindList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (Kind oldKind in e.OldItems)
                {
                    ConfigLogic.delKind(oldKind);
                }
            }
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (Kind newKind in e.NewItems)
                {
                    ConfigLogic.addKind(newKind);
                }
            }
        }

        public void KindUpd()
        {
            ConfigLogic.updKind();
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
