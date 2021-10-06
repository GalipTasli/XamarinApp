using ConsumeRestfulProject.Models;
using ConsumeRestfulProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsumeRestfulProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsPage : ContentPage
    {
        public CarsPage()
        {
            InitializeComponent();
        }
        public CarsPage(USER u)
        {
            InitializeComponent();
            BindingContext = new CarsPageViewModel(u);
        }
    }
}