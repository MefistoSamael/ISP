using System.Globalization;


namespace Lab1Bychko.Lab4.ViewModel
{
    public class DecimalToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            if (value is null)
                return string.Empty;

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var val = (string)value;
            if (val == string.Empty || !Decimal.TryParse(val, out decimal result))
               return null;

            return result;
        }
    }
}
