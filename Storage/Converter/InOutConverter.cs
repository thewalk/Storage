using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Storage.Converter
{
    [ValueConversion(typeof(bool), typeof(String))]
    public class InOutConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool inout = (bool)value;
            string result;
            if (inout) result = "入库";
            else result = "出库";
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string inout = (string)value;
            bool result;
            if (inout == "出库") result = true;
            else result = false;
            return result;
        }
    }
}
