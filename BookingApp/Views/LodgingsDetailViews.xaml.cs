using BookingApp.Models;
using BookingApp.Resources;
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
    public partial class LodgingsDetailViews : ContentPage
    {
        List<LocationItems> locations;
        List<CategoryItems> categories;
        LodgingModel LodgingSelected = new LodgingModel();
        

        public LodgingsDetailViews(LodgingsViewModel lodgingsViewModel) {
            Application.Current.UserAppTheme = OSAppTheme.Dark;
            InitializeComponent();
            BindingContext = new LodgingsDetailViewModel(lodgingsViewModel);
            InitCategoryPicker();
            InitLocationPicker();
            
        }

        public LodgingsDetailViews(LodgingsViewModel lodgingsViewModel, LodgingModel lodging) {
            Application.Current.UserAppTheme = OSAppTheme.Dark;
            InitializeComponent();
            BindingContext = new LodgingsDetailViewModel(lodgingsViewModel, lodging);
            InitCategoryPicker();
            InitLocationPicker();
        }

        private void InitLocationPicker() {
            locations = new List<LocationItems>();
            locations.Add(new LocationItems { LocationPlace = "Tokyo, Japan" });
            locations.Add(new LocationItems { LocationPlace = "Mexico City, Mexico" });
            locations.Add(new LocationItems { LocationPlace = "Bangkok, Thailand" });
            locations.Add(new LocationItems { LocationPlace = "New York, USA" });
            locations.Add(new LocationItems { LocationPlace = "Daegu, South Korea" });
            locations.Add(new LocationItems { LocationPlace = "Kowloon, Hong Kong" });
            locations.Add(new LocationItems { LocationPlace = "Los Angeles, USA" });
            locations.Add(new LocationItems { LocationPlace = "Kolkata, India" });
            locations.Add(new LocationItems { LocationPlace = "Tel Aviv, Israel" });
            locations.Add(new LocationItems { LocationPlace = "Osaka, Japan" });
            locations.Add(new LocationItems { LocationPlace = "Madrid, Spain" });
            locations.Add(new LocationItems { LocationPlace = "Rome, Italy" });
            locations.Add(new LocationItems { LocationPlace = "Isfahan, Iran" });

            foreach (var location in locations)
            {
                PickerLocation.Items.Add(location.LocationPlace);
            }
        }

        private void InitCategoryPicker() {
            categories = new List<CategoryItems>();
            categories.Add(new CategoryItems { CategoriesPlace = "Hotel" });
            categories.Add(new CategoryItems { CategoriesPlace = "Hostel" });
            categories.Add(new CategoryItems { CategoriesPlace = "Apartment" });
            categories.Add(new CategoryItems { CategoriesPlace = "Resort" });
            categories.Add(new CategoryItems { CategoriesPlace = "Capsule Hotel" });

            foreach (var category in categories)
            {
                PickerCategory.Items.Add(category.CategoriesPlace);
            }
        }

        private void PickerLocation_SelectedIndexChanged(object sender, EventArgs e) {
            Picker pickerLocation = sender as Picker;
            LodgingSelected.Location = pickerLocation.SelectedIndex.ToString();
        }

        private void PickerCategory_SelectedIndexChanged(object sender, EventArgs e) {
            Picker pickerCategory = sender as Picker;
            LodgingSelected.Category = pickerCategory.SelectedIndex.ToString();
        }

        
    }
}