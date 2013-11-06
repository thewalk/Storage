using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FirstFloor.ModernUI.Windows.Controls;

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
            DateTime time;
            try
            {
                string str = value as string;
                time = DateTime.Parse(str);
                return time;
            }
            catch
            {
                ModernDialog.ShowMessage("时间格式错误，修改为当前时间！","",System.Windows.MessageBoxButton.OK);
                return DateTime.Now;
            }
        }
    }
}
