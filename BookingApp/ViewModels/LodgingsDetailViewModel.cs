using BookingApp.Models;
using BookingApp.Services;
using BookingApp.Views;
using Newtonsoft.Json;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookingApp.ViewModels
{
    public class LodgingsDetailViewModel : BaseViewModel
    {
        LodgingModel LodgingSelected;
        LodgingsViewModel LodgingsViewModel;

        Command _SaveCommand;
        public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        Command _DeleteCommand;
        public Command DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new Command(DeleteAction));

        Command _MapCommand;
        public Command MapCommand => _MapCommand ?? (_MapCommand = new Command(MapAction));


        //This is a function executed when getlocation button is clicked
        Command _GetLocationCommand;
        public Command GetLocationCommand => _GetLocationCommand ?? (_GetLocationCommand = new Command(GetLocationAction));

        Command _TakePictureCommand;
        public Command TakePictureCommand => _TakePictureCommand ?? (_TakePictureCommand = new Command(TakePictureAction));

        Command _SelectPictureCommand;
        public Command SelectPictureCommand => _SelectPictureCommand ?? (_SelectPictureCommand = new Command(SelectPictureAction));

        int _LodgingID;

        string _LodgingPicture64;
        public string LodgingPicture64
        {
            get => _LodgingPicture64;
            set => SetProperty(ref _LodgingPicture64, value);
        }

        string _LodgingTitle;
        public string LodgingTitle
        {
            get => _LodgingTitle;
            set => SetProperty(ref _LodgingTitle, value);
        }

        string _LodgingDescription;
        public string LodgingDescription
        {
            get => _LodgingDescription;
            set => SetProperty(ref _LodgingDescription, value);
        }

        double _LodgingPrice;
        public double LodgingPrice
        {
            get => _LodgingPrice;
            set => SetProperty(ref _LodgingPrice, value);
        }

        string _LodgingCheckIn;
        public string LodgingCheckIn
        {
            get => _LodgingCheckIn;
            set => SetProperty(ref _LodgingCheckIn, value);
        }

        string _LodgingCheckOut;
        public string LodgingCheckOut
        {
            get => _LodgingCheckOut;
            set => SetProperty(ref _LodgingCheckOut, value);
        }

        string _LodgingLocation;
        public string LodgingLocation
        {
            get => _LodgingLocation;
            set => SetProperty(ref _LodgingLocation, value);
        }

        int _LodgingAdultAvailable;
        public int LodgingAdultAvailable
        {
            get => _LodgingAdultAvailable;
            set => SetProperty(ref _LodgingAdultAvailable, value);
        }

        int _LodgingKidAvailable;
        public int LodgingKidAvailable
        {
            get => _LodgingKidAvailable;
            set => SetProperty(ref _LodgingKidAvailable, value);
        }

        string _LodgingCategory;
        public string LodgingCategory
        {
            get => _LodgingCategory;
            set => SetProperty(ref _LodgingCategory, value);
        }

        double _LodgingLatitude;
        public double LodgingLatitude
        {
            get => _LodgingLatitude;
            set => SetProperty(ref _LodgingLatitude, value);
        }

        double _LodgingLongitude;
        public double LodgingLongitude
        {
            get => _LodgingLongitude;
            set => SetProperty(ref _LodgingLongitude, value);
        }

        public LodgingsDetailViewModel(LodgingsViewModel lodgingsViewModel) {
            LodgingsViewModel = lodgingsViewModel;
        }

        public LodgingsDetailViewModel(LodgingsViewModel lodgingsViewModel, LodgingModel lodging) {
            LodgingsViewModel = lodgingsViewModel;
           
            _LodgingID = lodging.IDLodging;
            LodgingPicture64 = lodging.Picture;
            LodgingTitle = lodging.Title;
            LodgingDescription = lodging.Description;
            LodgingPrice = lodging.Price;
            LodgingCheckIn = lodging.CheckIn;
            LodgingCheckOut = lodging.CheckOut;
            LodgingLocation = lodging.Location;
            LodgingAdultAvailable = lodging.AdultAvailable;
            LodgingKidAvailable = lodging.KidAvailable;
            LodgingCategory = lodging.Category;
            LodgingLatitude = lodging.Latitude;
            LodgingLongitude = lodging.Longitude;


        }

        private async void SaveAction() {
          
            ResponseModel response;
            try
            {
                LodgingModel LodgingSelected = new LodgingModel
                {
                    IDLodging = _LodgingID,
                    Picture = LodgingPicture64,
                    Title = LodgingTitle,
                    Description = LodgingDescription,
                    Price = LodgingPrice,
                    CheckIn = LodgingCheckIn,
                    CheckOut = LodgingCheckOut,
                    Location = LodgingLocation,
                    AdultAvailable = LodgingAdultAvailable,
                    KidAvailable = LodgingKidAvailable,
                    Category = LodgingCategory,
                    Latitude = LodgingLatitude,
                    Longitude = LodgingLongitude
                };

                if (LodgingSelected.IDLodging > 0)
                {
                    //update
                    response = await new ApiService().PutDataAsync("lodging", LodgingSelected);
                }
                else
                {
                    //insert
                    response = await new ApiService().PostDataAsync("lodging", LodgingSelected);
                }


                if (response == null || !response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert("BookingApp", $"Failed to process Lodging {response.Message}", "Ok");
                    return;
                }
                LodgingsViewModel.LodgingsRefresh();
                await Application.Current.MainPage.DisplayAlert("BookingApp", "Reservation successfully modified ✅", "Ok");


            }
            catch (Exception exc)
            {

                await Application.Current.MainPage.DisplayAlert("BookingApp", $"Failed to process Lodging {exc.Message}", "Ok");
            }

        }


        private void MapAction() {
            Application.Current.MainPage.Navigation.PushAsync(
                new LodgingsMapsView(new LodgingModel
                {
                    IDLodging = _LodgingID,
                    Picture = LodgingPicture64,
                    Title = LodgingTitle,
                    Description = LodgingDescription,
                    Price = LodgingPrice,
                    CheckIn = LodgingCheckIn,
                    CheckOut = LodgingCheckOut,
                    Location = LodgingLocation,
                    AdultAvailable = LodgingAdultAvailable,
                    KidAvailable = LodgingKidAvailable,
                    Category = LodgingCategory,
                    Latitude = LodgingLatitude,
                    Longitude = LodgingLongitude
                })
            );
        }



        private async void DeleteAction() {
            ResponseModel response;

            try
            {
                LodgingModel lodging = new LodgingModel
                {
                    IDLodging = _LodgingID,
                    Picture = LodgingPicture64,
                    Title = LodgingTitle,
                    Description = LodgingDescription,
                    Price = LodgingPrice,
                    CheckIn = LodgingCheckIn,
                    CheckOut = LodgingCheckOut,
                    Location = LodgingLocation,
                    AdultAvailable = LodgingAdultAvailable,
                    KidAvailable = LodgingKidAvailable,
                    Category = LodgingCategory,
                    Latitude = LodgingLatitude,
                    Longitude = LodgingLongitude

                };

                if (lodging.IDLodging > 0)
                {
                    //delete
                    response = await new ApiService().DeleteDataAsync("lodging", _LodgingID);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("BookingApp", "Failed to process Lodging", "Ok");
                    return;
                }
                LodgingsViewModel.LodgingsRefresh();
                await Application.Current.MainPage.DisplayAlert("BookingApp", "Reservation successfully deleted. ✅", "Ok");
                


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async void GetLocationAction() {
            try
            {
                LodgingLatitude = LodgingLongitude = 0;
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                  
                    LodgingLatitude = location.Latitude;
                    LodgingLongitude = location.Longitude;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                await Application.Current.MainPage.DisplayAlert("BookingApp", $"GPS is not supported on the device({fnsEx.Message})", "Ok");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                await Application.Current.MainPage.DisplayAlert("BookingApp", $"GPS is not activated on the device({fneEx.Message})", "ok");
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                await Application.Current.MainPage.DisplayAlert("BookingApp", $"Could not get device location permissions({pEx.Message})", "ok");
            }
            catch (Exception ex)
            {
                // Unable to get location
                await Application.Current.MainPage.DisplayAlert("BookingApp", $"An error was generated getting the device location 😈😈({ex.Message})", "ok");
            }
        }

        private async void TakePictureAction() {

            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("No camera", "Camera not available on device.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "BookingApp",
                    Name = "LodgingSelected.jpg"
                });

                if (file == null)
                    return;

                LodgingPicture64 = _LodgingPicture64 = await new ImageService().ConvertImageFilePathToBase64(file.Path);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("BookingApp", $"An error was generated when taking the photo {ex.Message}.", "OK");
            }
        }


        private async void SelectPictureAction() {


            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("No camera", "Cannot select photos.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null)
                    return;

                LodgingPicture64 = _LodgingPicture64 = await new ImageService().ConvertImageFilePathToBase64(file.Path);
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("BookingApp", $"An error was generated when taking the photo {ex.Message}.", "OK");
            }

        }
    }
}
