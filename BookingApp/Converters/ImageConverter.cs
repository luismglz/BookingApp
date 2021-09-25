using BookingApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BookingApp.Converters
{

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return "404.png";

            }

            return new ImageService().ConvertImageFromBase64ToImageSource(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
