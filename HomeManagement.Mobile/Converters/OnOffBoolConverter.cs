using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Mobile.Converters
{
    public class OnOffBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (bool)value ? "On" : "Off";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => (string)value == "On";
    }
}
