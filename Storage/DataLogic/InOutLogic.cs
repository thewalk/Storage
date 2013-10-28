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
        static StorageDataContext storageDataContext = new StorageDataContext();

        #region Operation On Batch
        //public static Dictionary<Batch, Contact> getAllBatchWithContact()
        //{
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("Name", Type.GetType("String"));
        //    dataTable.Columns.Add("Size", Type.GetType("float"));
        //    dataTable.Columns.Add("InOut", Type.GetType("Boolean"));
        //    dataTable.Columns.Add("Note", Type.GetType("String"));
        //    dataTable.Columns.Add("ContactID", Type.GetType("Int"));

        //    Dictionary<Batch, Contact> map = new Dictionary<Batch, Contact>();
        //    var resultBatch = from batch in storageDataContext.Batch select batch;
        //    foreach (Batch row in resultBatch)
        //    {
        //        Contact contact = storageDataContext.Contact.Single(c => c.ID == row.ContactID);
        //        map.Add(row, contact);
        //    }
        //    return map;
        //}
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
