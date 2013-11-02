using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Model;

namespace Storage.DataLogic
{
    public static class InOutLogic
    {
        static StorageDataContext storageDataContext = MyDataContext.storageDataContext;

        #region Operation On Batch
        public static ObservableCollection<Batch> getAllBatch()
        {
            var result = from batch in storageDataContext.Batch select batch;
            ObservableCollection<Batch> batchList = new ObservableCollection<Batch>();
            foreach (Batch batch in result)
            {
                batchList.Add(batch);
            }
            return batchList;
        }
        public static ObservableCollection<Batch> getImportBatch()
        {
            var result = from batch in storageDataContext.Batch where batch.InOut==true select batch;
            ObservableCollection<Batch> batchList = new ObservableCollection<Batch>();
            foreach (Batch batch in result)
            {
                batchList.Add(batch);
            }
            return batchList;
        }
        public static void delBatch(Batch batch)
        {
        }
        public static void addBatch(Batch batch)
        {
            batch.Contact = storageDataContext.Contact.SingleOrDefault(contact=>contact.ID == batch.ContactID);
            storageDataContext.Batch.InsertOnSubmit(batch);
            storageDataContext.SubmitChanges();
        }
        public static void updBatch()
        {
            storageDataContext.SubmitChanges();
        }
        #endregion


        #region Operation On Import
        public static ObservableCollection<Import> getAllImport()
        {
            var result = from import in storageDataContext.Import select import;
            ObservableCollection<Import> importList = new ObservableCollection<Import>();
            foreach (Import import in result)
            {
                importList.Add(import);
            }
            return importList;
        }
        public static void delImport(Import import)
        {
            storageDataContext.Import.DeleteOnSubmit(import);
            storageDataContext.SubmitChanges();
        }
        public static void addImport(Import import)
        {
            import.Contact = storageDataContext.Contact.Single(contact => contact.ID == import.ContactID);
            import.Batch = storageDataContext.Batch.Single(batch => batch.ID == import.BatchID);
            import.Kind = storageDataContext.Kind.Single(kind => kind.ID == import.KindID);
            import.Pit = storageDataContext.Pit.Single(pit => pit.ID == import.PitID);
            storageDataContext.Import.InsertOnSubmit(import);
            storageDataContext.SubmitChanges();
        }
        public static void updImport()
        {
            storageDataContext.SubmitChanges();
        }
        #endregion
    }
}
