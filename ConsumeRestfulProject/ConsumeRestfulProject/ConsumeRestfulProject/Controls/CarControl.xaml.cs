using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsumeRestfulProject.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarControl : ContentView
    {

        public static BindableProperty BrandTextProperty = BindableProperty.Create(propertyName: "BrandText", defaultValue: string.Empty,
            returnType: typeof(string), declaringType: typeof(CarControl), defaultBindingMode: BindingMode.TwoWay, propertyChanged: BrandTextPropertyChanged);


        public static BindableProperty YearTextProperty = BindableProperty.Create(propertyName: "YearText", defaultValue: string.Empty,
            returnType: typeof(string), declaringType: typeof(CarControl), defaultBindingMode: BindingMode.TwoWay, propertyChanged: YearTextPropertyChanged);

        public static BindableProperty ModelTextProperty = BindableProperty.Create(propertyName: "ModelText", defaultValue: string.Empty,
            returnType: typeof(string), declaringType: typeof(CarControl), defaultBindingMode: BindingMode.TwoWay, propertyChanged: ModelTextPropertyChanged);

        public static BindableProperty DetailsTextProperty = BindableProperty.Create(propertyName: "DetailsText", defaultValue: string.Empty,
            returnType: typeof(string), declaringType: typeof(CarControl), defaultBindingMode: BindingMode.TwoWay, propertyChanged: DetailsTextPropertyChanged);


        public static BindableProperty ImageUriProperty = BindableProperty.Create(propertyName: "ImageUri", defaultValue: string.Empty,
            returnType: typeof(string), declaringType: typeof(CarControl), defaultBindingMode: BindingMode.TwoWay, propertyChanged: ImageUriPropertyChanged);

        public static BindableProperty ImgSourceProperty = BindableProperty.Create(propertyName: "ImgSource", defaultValue: null,
            returnType: typeof(ImageSource), declaringType: typeof(CarControl), defaultBindingMode: BindingMode.TwoWay, propertyChanged: ImgSourcePropertyChanged);

        public string BrandText
        {
            get { return GetValue(BrandTextProperty).ToString(); }
            set { SetValue(BrandTextProperty, value); }

        }
        public string ImageUri
        {
            get { return GetValue(ImageUriProperty).ToString(); }
            set { SetValue(ImageUriProperty, value); }

        }
        public string YearText
        {
            get { return GetValue(YearTextProperty).ToString(); }
            set { SetValue(YearTextProperty, value); }

        }
        public string ModelText
        {
            get { return GetValue(ModelTextProperty).ToString(); }
            set { SetValue(ModelTextProperty, value); }

        }
        public string DetailsText
        {
            get { return GetValue(DetailsTextProperty).ToString(); }
            set { SetValue(DetailsTextProperty, value); }

        }


        public ImageSource ImgSource
        {
            get { return GetValue(ImgSourceProperty) as ImageSource; }
            set { SetValue(BrandTextProperty, value); }

        }
        private static void ImageUriPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var control = (CarControl)bindable;
            if (newValue != null && string.IsNullOrEmpty((string)newValue) == false)
                control.image.Source = ImageSource.FromUri(new Uri((string)newValue));

        }
        private static void ImgSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var control = (CarControl)bindable;
            if (newValue != null)
                control.image.Source = (ImageSource)newValue;

        }
        private static void BrandTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var control = (CarControl)bindable;
            if (newValue != null)
                control.labelBrand.Text = newValue.ToString();

        }


        private static void DetailsTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var control = (CarControl)bindable;
            if (newValue != null)
                control.labelDetail.Text = newValue.ToString();

        }


        private static void ModelTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var control = (CarControl)bindable;
            if (newValue != null)
                control.labelModel.Text = newValue.ToString();

        }
        private static void YearTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var control = (CarControl)bindable;
            if (newValue != null)
                control.labelYear.Text = newValue.ToString();

        }
        public CarControl()
        {
            InitializeComponent();
        }
    }
}