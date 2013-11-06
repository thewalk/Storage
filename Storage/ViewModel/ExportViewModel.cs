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
    public class ExportViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Export> exportList = new ObservableCollection<Export>();
        public ObservableCollection<Export> ExportList
        {
            get
            {
                return exportList;
            }
            set
            {
                exportList = value;
            }
        }
        public ExportViewModel()
        {
            ExportList = InOutLogic.getAllExport();
            ExportList.CollectionChanged += ExportList_CollectionChanged;
        }
        public ExportViewModel(ObservableCollection<Export> exportList)
        {
            ExportList = exportList;
            ExportList.CollectionChanged += ExportList_CollectionChanged;
        }

        void ExportList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (Export oldExport in e.OldItems)
                {
                    InOutLogic.delExport(oldExport);
                }
            }
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (Export newExport in e.NewItems)
                {
                    InOutLogic.addExport(newExport);
                }
            }
        }
        public void ExportUpd()
        {
            InOutLogic.updExport();
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
