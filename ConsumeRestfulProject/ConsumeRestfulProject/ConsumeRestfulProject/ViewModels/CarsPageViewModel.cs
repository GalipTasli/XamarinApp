using ConsumeRestfulProject.Models;
using ConsumeRestfulProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConsumeRestfulProject.ViewModels
{
    public class CarsPageViewModel : BaseViewModel
    {

        private USER user;
        ImageSource profilImage;
        ICommand addCarCommand;
        ICommand deleteCarCommand;
        ICommand refreshCommand;

        ObservableCollection<CAR> carList;
        bool isRefreshing;

        public CarsPageViewModel()
        {
        }

        public async void addCarFunction()
        {

            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new AddCarPage()));

        }

        public async void deleteCarFunction(CAR car)
        {
            await App.DBservice.DeleteCar(car.CARID);
            initializeData();
            await App.Current.MainPage.DisplayAlert("Message", "Silme işlemi başarılı ", "ok");

        }

        public CarsPageViewModel(USER u)
        {
            User = u;
            ProfilImage = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(User.IMAGE)));

            AddCarCommand = new Command(addCarFunction);
            initializeData();
            DeleteCarCommand = new Command<CAR>(deleteCarFunction);
            RefreshCommand = new Command(refreshFunction);
        }

        public async void refreshFunction()
        {
            IsRefreshing = true;
            List<CAR> cars = await App.CarService.getCars();
          //  List<CAR> cars = await App.DBservice.GetCars();
            if (cars != null)
                CarList = new ObservableCollection<CAR>(cars);
            else
                CarList = new ObservableCollection<CAR>();
            IsRefreshing = false;

        }

        public async void initializeData()
        {
            List<CAR> cars = await App.CarService.getCars();
           // List<CAR> cars = await App.DBservice.GetCars();
            if (cars != null)
                CarList = new ObservableCollection<CAR>(cars);
            else
                CarList = new ObservableCollection<CAR>();
        }

        public USER User { get => user; set => user = value; }
        public ImageSource ProfilImage
        {
            get => profilImage; set
            {
                profilImage = value;
                OnPropertyChanged("ProfilImage");
            }
        }

        public ICommand AddCarCommand { get => addCarCommand; set => addCarCommand = value; }
        public ObservableCollection<CAR> CarList
        {
            get => carList; set
            {
                carList = value;
                OnPropertyChanged("CarList");
            }
        }

        public ICommand DeleteCarCommand { get => deleteCarCommand; set => deleteCarCommand = value; }
        public bool IsRefreshing
        {
            get => isRefreshing; set
            {

                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public ICommand RefreshCommand { get => refreshCommand; set => refreshCommand = value; }
    }
}
