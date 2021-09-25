using BookingApp.Models;
using BookingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace BookingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LodgingsMapsView : ContentPage
    {
        public LodgingsMapsView(LodgingModel lodgingSelected) {
            InitializeComponent();

            lodgingSelected.Picture = new ImageService().SaveImageFromBase64(lodgingSelected.Picture, lodgingSelected.IDLodging);
            MapLodgings.Lodging = lodgingSelected;

            MapLodgings.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lodgingSelected.Latitude, lodgingSelected.Longitude),Distance.FromMiles(.5)));

            MapLodgings.Pins.Add(
                new Pin
                {
                    Type = PinType.Place,
                    Label = "Lodging",
                    Position = new Position(
                        lodgingSelected.Latitude,
                        lodgingSelected.Longitude
                        )
                });

            LodgingTitle.Text = lodgingSelected.Title;
            LodgingPrice.Text = lodgingSelected.Price.ToString();
            //LodgingLocation.Text = lodgingSelected.Location.ToString();
        }
    }
}