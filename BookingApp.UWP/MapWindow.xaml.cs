using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BookingApp.UWP
{
    public sealed partial class MapWindow : UserControl
    {
        public MapWindow(LodgingModel lodging) {
            this.InitializeComponent();

            WindowPicture.Source = new BitmapImage(new Uri(lodging.Picture));
            WindowTitle.Text = lodging.Title.ToString();
            WindowPrice.Text = $"{lodging.Price.ToString()} USD";
        }
    }
}
