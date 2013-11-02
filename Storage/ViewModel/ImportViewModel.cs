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
    public class ImportViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Import> importList = new ObservableCollection<Import>();
        public ObservableCollection<Import> ImportList
        {
            get
            {
                return importList;
            }
            set
            {
                importList = value;
                OnPropertyChanged("importList");
            }
        }
        public ImportViewModel()
        {
            ImportList = InOutLogic.getAllImport();
            ImportList.CollectionChanged += importList_CollectionChanged;
        }
        public ImportViewModel(ObservableCollection<Import> list)
        {
            ImportList = list;
            ImportList.CollectionChanged += importList_CollectionChanged;
        }

        void importList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (Import oldImport in e.OldItems)
                {
                    InOutLogic.delImport(oldImport);
                }
            }
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (Import newImport in e.NewItems)
                {
                    InOutLogic.addImport(newImport);
                }
            }
        }

        public void ImportUpd()
        {
            InOutLogic.updImport();
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
