using BookingApp.Models;
using BookingApp.Renders;
using BookingApp.UWP.Renders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MyMap), typeof(MyMapRenderer))]
namespace BookingApp.UWP.Renders
{
    class MyMapRenderer : MapRenderer
    {
        MapControl NativeMap;
        LodgingModel Lodging;
        MapWindow LodgingWindow;
        bool IsLodgingWindowVisible = false;


        protected override void OnElementChanged(ElementChangedEventArgs<Map> e) {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.MapElementClick -= OnMapElementClick;
                NativeMap.Children.Clear();
                NativeMap = null;
                LodgingWindow = null;
            }

            if (e.NewElement != null)
            {
                this.Lodging = (e.NewElement as MyMap).Lodging;

                var formsMap = (MyMap)e.NewElement;
                NativeMap = Control as MapControl;
                NativeMap.Children.Clear();
                NativeMap.MapElementClick += OnMapElementClick;

                var position = new BasicGeoposition
                {
                    Latitude = this.Lodging.Latitude,
                    Longitude = Lodging.Longitude
                };

                var point = new Geopoint(position);

                var mapIcon = new MapIcon();
                mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///pin.png"));
                mapIcon.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;
                mapIcon.Location = point;
                mapIcon.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);

                NativeMap.MapElements.Add(mapIcon);
            }

        }

        private void OnMapElementClick(MapControl sender, MapElementClickEventArgs args) {

            var mapIcon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;

            if (mapIcon != null)
            {
                if (!IsLodgingWindowVisible)
                {
                    if (LodgingWindow == null) LodgingWindow = new MapWindow(Lodging);

                    var position = new BasicGeoposition
                    {
                        Latitude = Lodging.Latitude,
                        Longitude = Lodging.Longitude
                    };

                    var point = new Geopoint(position);

                    NativeMap.Children.Add(LodgingWindow);
                    MapControl.SetLocation(LodgingWindow, point);
                    MapControl.SetNormalizedAnchorPoint(LodgingWindow, new Windows.Foundation.Point(0.5, 1.0));

                    IsLodgingWindowVisible = true;
                }
                else
                {
                    NativeMap.Children.Remove(LodgingWindow);
                    IsLodgingWindowVisible = false;
                }
            }
        }

    }
}
