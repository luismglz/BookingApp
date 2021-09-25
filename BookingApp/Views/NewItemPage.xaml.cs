using BookingApp.Models;
using BookingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage() {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}