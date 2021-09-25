using BookingApp.Services;
using BookingApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApp
{
    public partial class App : Application
    {

        public App() {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            // MainPage = new LodgingsListView();
            LodgingsListView listView = new LodgingsListView();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
