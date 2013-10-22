using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Model;

namespace Storage.DataLogic
{
    public static class KindLogic
    {
        static StorageDataContext storageDataContext = new StorageDataContext();
        public static ObservableCollection<Kind> getAllKind()
        {
            ObservableCollection<Kind> KindList = new ObservableCollection<Kind>();
            var result = from kind in storageDataContext.Kind select kind;
            foreach (Kind kind in result)
            {
                KindList.Add(kind);
            }
            return KindList;
        }
        public static void delKind(Kind kind)
        {
            storageDataContext.Kind.DeleteOnSubmit(kind);
            storageDataContext.SubmitChanges();
        }
        public static void addKind(Kind kind) 
        {
            storageDataContext.Kind.InsertOnSubmit(kind);
            storageDataContext.SubmitChanges();
        }
        public static void updKind()
        {
            storageDataContext.SubmitChanges();
        }
    }
}
