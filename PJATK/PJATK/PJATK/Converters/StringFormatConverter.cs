using System;
using System.Globalization;
using Xamarin.Forms;

namespace PJATK.Converters
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var formatString = parameter as string;

            return string.IsNullOrEmpty(formatString)
                ? value.ToString()
                : string.Format(culture, formatString, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
