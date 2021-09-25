using BookingApp.ViewModels;
using BookingApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BookingApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell() {
            Application.Current.UserAppTheme = OSAppTheme.Dark;
            InitializeComponent();
            
        
            Routing.RegisterRoute(nameof(LodgingsListView), typeof(LodgingsListView));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
