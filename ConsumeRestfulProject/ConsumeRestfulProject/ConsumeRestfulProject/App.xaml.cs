using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ConsumeRestfulProject.Views;
using System.Security.Cryptography.X509Certificates;
using ConsumeRestfulProject.Services;
using System.IO;

namespace ConsumeRestfulProject
{
    public partial class App : Application
    {
        private static UserRestService userService;
        private static CarRestService carService;
        private static DBservice dBservice;
        public static UserRestService UserService { get => userService; set => userService = value; }
        public static CarRestService CarService { get => carService; set => carService = value; }
        public static DBservice DBservice { get => dBservice; set => dBservice = value; }

        public App()
        {


            InitializeComponent();
            UserService = new UserRestService();
            CarService = new CarRestService();
            DBservice = new DBservice(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "xamarinDB.db3"));
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
