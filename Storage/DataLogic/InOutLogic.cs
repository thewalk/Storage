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

    }
}
