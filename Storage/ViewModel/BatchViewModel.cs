using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.DataLogic;
using Storage.Model;

namespace Storage.ViewModel
{
    public class BatchViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Batch> batchList;
        public ObservableCollection<Batch> BatchList
        {
            get
            {
                return batchList;
            }
            set
            {
                batchList = value;
                OnPropertyChanged("batchList");
            }
        }

        public BatchViewModel()
        {
            batchList = InOutLogic.getAllBatch();
            batchList.CollectionChanged += batchList_CollectionChanged;
        }

        void batchList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (Batch oldBatch in e.OldItems)
                {
                    InOutLogic.delBatch(oldBatch);
                }
            }
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (Batch newBatch in e.NewItems)
                {
                    InOutLogic.addBatch(newBatch);
                }
            }
        }

        public void BatchUpd()
        {
            InOutLogic.updBatch();
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
