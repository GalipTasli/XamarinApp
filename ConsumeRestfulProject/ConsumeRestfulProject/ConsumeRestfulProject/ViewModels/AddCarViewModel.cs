using Android.Media;
using ConsumeRestfulProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConsumeRestfulProject.ViewModels
{
    public class AddCarViewModel : BaseViewModel
    {
        string brand;
        string model;
        string year;
        string details;
        string imageUri;
        ImageSource imgSource;
        ICommand addCommand;
        public AddCarViewModel()
        {

            AddCommand = new Command(addFunction);

        }
        async void addFunction()
        {
            CAR car = new CAR();
            car.BRAND = Brand;
            car.DETAILS = Details;
            car.YEAR = Year;
            car.MODEL = Model;
            car.IMAGE = imageUri;
            string status = await App.CarService.addCar(car);
            //string status = (await App.DBservice.AddCar(car)).ToString();
            if (status != "0")
            {
                await App.Current.MainPage.DisplayAlert("Message", "Kayıt Başarılı", "ok");
                await App.Current.MainPage.Navigation.PopAsync();

            }
        }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Year { get => year; set => year = value; }
        public string Details { get => details; set => details = value; }
        public string ImageUri
        {
            get => imageUri; set
            {
                if (imageUri != value)
                {
                    imageUri = value;
                    ImgSource = ImageSource.FromUri(new Uri(ImageUri));
                }

            }
        }
        public ImageSource ImgSource
        {
            get => imgSource; set
            {
                imgSource = value;
                OnPropertyChanged("ImgSource");

            }
        }
        public ICommand AddCommand { get => addCommand; set => addCommand = value; }
    }
}
