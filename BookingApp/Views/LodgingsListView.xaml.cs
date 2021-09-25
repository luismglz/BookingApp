using BookingApp.Models;
using BookingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LodgingsListView : ContentPage
    {
        public LodgingsListView() {
            Application.Current.UserAppTheme = OSAppTheme.Dark;
            InitializeComponent();
            BindingContext = new LodgingsViewModel();
        }


    }
}