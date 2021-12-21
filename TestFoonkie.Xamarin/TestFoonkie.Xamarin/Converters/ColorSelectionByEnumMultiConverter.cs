using System;
using System.Globalization;
using Xamarin.Forms;

namespace TestFoonkie.Xamarin
{
    public class ColorSelectionByEnumMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values?.Length != 3) return null;
            string selectedEnum = values[0]?.ToString();
            string SelectedColor = ((Color)values[1]).ToHex();
            string UnSelectedColor = ((Color)values[2]).ToHex();
            return selectedEnum == parameter as string ? SelectedColor : UnSelectedColor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}