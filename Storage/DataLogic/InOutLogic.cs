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
        public static ObservableCollection<Batch> getExportBatch()
        {
            var result = from batch in storageDataContext.Batch where batch.InOut == false select batch;
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
        public static ObservableCollection<Batch> getImportBatchByContactID(int contactID)
        {
            var result = from batch in storageDataContext.Batch 
                         where batch.ContactID == contactID && batch.InOut == true 
                         select batch;
            ObservableCollection<Batch> batchList = new ObservableCollection<Batch>();
            foreach (Batch batch in result)
            {
                batchList.Add(batch);
            }
            return batchList;
        }
        public static ObservableCollection<Batch> getExportBatchByContactID(int contactID)
        {
            var result = from batch in storageDataContext.Batch
                         where batch.ContactID == contactID && batch.InOut == false
                         select batch;
            ObservableCollection<Batch> batchList = new ObservableCollection<Batch>();
            foreach (Batch batch in result)
            {
                batchList.Add(batch);
            }
            return batchList;
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
            if (import.Size.Value < getCurrentPortSize(import.ContactID.Value, import.PitID.Value, import.KindID.Value))
            {
                Exception e = new Exception();
                e.Source = "储窖中没有足够储量，该入库记录不可删除！";
                throw e;
            }
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

            CurrentPort currentPort = storageDataContext.CurrentPort.SingleOrDefault(
                c => c.ContactID == import.ContactID && c.PitID == import.PitID && c.KindID == import.KindID);
            if (currentPort == null)
            {
                currentPort = new CurrentPort();
                currentPort.Contact = import.Contact;
                currentPort.Pit = import.Pit;
                currentPort.Kind = import.Kind;
                currentPort.Size = import.Size;
                storageDataContext.CurrentPort.InsertOnSubmit(currentPort);
            }
            else
            {
                currentPort.Size += import.Size;
                storageDataContext.CurrentPort.InsertOnSubmit(currentPort);
            }
            storageDataContext.SubmitChanges();

        }
        public static void updImport()
        {
            storageDataContext.SubmitChanges();
        }
        #endregion

        #region Operation On Export
        public static ObservableCollection<Export> getAllExport()
        {
            var result = from export in storageDataContext.Export select export;
            ObservableCollection<Export> exportList = new ObservableCollection<Export>();
            foreach (Export export in result)
            {
                exportList.Add(export);
            }
            return exportList;
        }
        public static void delExport(Export export)
        {
            storageDataContext.Export.DeleteOnSubmit(export);
            storageDataContext.SubmitChanges();
        }
        public static void addExport(Export export)
        {
            export.Contact = storageDataContext.Contact.Single(contact => contact.ID == export.ContactID);
            export.Batch = storageDataContext.Batch.Single(batch => batch.ID == export.BatchID);
            export.Kind = storageDataContext.Kind.Single(kind => kind.ID == export.KindID);
            export.Pit = storageDataContext.Pit.Single(pit => pit.ID == export.PitID);
            storageDataContext.Export.InsertOnSubmit(export);
            storageDataContext.SubmitChanges();
        }
        public static void updExport()
        {
            storageDataContext.SubmitChanges();
        }
        #endregion

        #region Operation On CurrentPort
        public static ObservableCollection<Pit> getPitByContactID(int contactID)
        {
            var result = (from currentPort in storageDataContext.CurrentPort
                          where currentPort.ContactID == contactID
                          select currentPort).Distinct();
            ObservableCollection<Pit> pitList = new ObservableCollection<Pit>();
            foreach(CurrentPort currentPort  in result)
            {
                pitList.Add(currentPort.Pit);
            }
            return pitList;
        }
        public static ObservableCollection<Kind> getKindByContactAndPit(int contactID, int pitID)
        {
            var result = (from currentPort in storageDataContext.CurrentPort
                          where currentPort.ContactID == contactID && currentPort.PitID == pitID
                          select currentPort).Distinct();
            ObservableCollection<Kind> kindList = new ObservableCollection<Kind>();
            foreach (CurrentPort currentPort in result)
            {
                kindList.Add(currentPort.Kind);
            }
            return kindList;
        }
        public static double getCurrentPortSize(int contactID, int pitID, int kindID)
        {
            CurrentPort currentPort = storageDataContext.CurrentPort.SingleOrDefault(c => c.ContactID == contactID && c.PitID == pitID && c.KindID == kindID);
            return currentPort.Size.Value;
        }
        #endregion
    }
}
