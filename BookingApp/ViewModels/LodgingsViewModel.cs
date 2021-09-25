using BookingApp.Models;
using BookingApp.Services;
using BookingApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookingApp.ViewModels
{
    public class LodgingsViewModel : BaseViewModel
    {

        Command _LoadCommand;
        public Command LoadCommand => _LoadCommand ?? (_LoadCommand = new Command(LoadAction));

        Command _NewCommand;
        public Command NewCommand => _NewCommand ?? (_NewCommand = new Command(NewAction));

        Command _SelectCommand;
        public Command SelectCommand => _SelectCommand ?? (_SelectCommand = new Command(SelectAction));

        Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(LoadLodgings));

        List<LodgingModel> _LodgingsList;
        public List<LodgingModel> LodgingsList
        {
            get => _LodgingsList;
            set => SetProperty(ref _LodgingsList, value);
        }

        LodgingModel _LodgingSelected;
        public LodgingModel LodgingSelected
        {
            get => _LodgingSelected;
            set => SetProperty(ref _LodgingSelected, value);
        }

        public LodgingsViewModel() {
            LoadLodgings();
        }

        private async void LoadLodgings() {

            IsBusy = true;
            ResponseModel response = await new ApiService().GetDataAsync("Lodging");
            if (response == null || !response.IsSuccess)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("AppLodgings", $"Error loading information {response.Message}", "Ok");
                return;
            }
            LodgingsList = JsonConvert.DeserializeObject<List<LodgingModel>>(response.Result.ToString());
            IsBusy = false;
        }

        private void LoadAction() {
            LoadLodgings();
        }


        public void LodgingsRefresh() {
            LoadLodgings();
        }

        private void NewAction(object obj) {
            Application.Current.MainPage.Navigation.PushAsync(new LodgingsDetailViews(this));
        }

        private void SelectAction(object obj) {
            Application.Current.MainPage.Navigation.PushAsync(new LodgingsDetailViews(this,LodgingSelected));
        }
    }
}
