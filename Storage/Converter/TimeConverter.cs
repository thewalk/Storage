using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Storage.Converter
{
    [ValueConversion(typeof(bool), typeof(String))]
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime time = DateTime.Parse(value.ToString());
            return string.Format("{0:g}", time);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = value as string;
            DateTime time = DateTime.Parse(str);
            return time;
        }
    }
}
