using BookingApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BookingApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}