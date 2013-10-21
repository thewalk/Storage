﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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