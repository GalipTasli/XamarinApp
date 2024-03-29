﻿using ConsumeRestfulProject.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConsumeRestfulProject.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        string userName;
        string password;
        string name;
        string surname;
        ImageSource imgSource;
        ICommand imageSelectCommand;
        ICommand singUpCommand;
        private Byte[] userImage;

        public SignUpViewModel()
        {
            ImgSource = ImageSource.FromResource("ConsumeRestfulProject.Images.emptyUser.png");
            ImageSelectCommand = new Command(selectImage);
            singUpCommand = new Command(singUpFunction);
        }
        public string UserName
        {
            get => userName; set
            {
                if (userName != value)
                    userName = value;

            }
        }


        public async void singUpFunction()
        {
            USER u = new USER();
            u.PASSWORD = Password;
            u.USERNAME = UserName;
            u.NAME = Name;
            u.SURNAME = Surname;
            if (UserImage != null)
                u.IMAGE = Convert.ToBase64String(UserImage);
            // USER user = await App.DBservice.GetUserByName(u.USERNAME);
            USER user = await App.UserService.getUserByUsernameAndPassword(u.USERNAME, u.PASSWORD);

            if (user == null)
            {
                //string status = (await App.DBservice.AddUser(u)).ToString();
                string status = (await App.UserService.addUser(u)).ToString();

                if (status != "0")
                {

                    await App.Current.MainPage.DisplayAlert("Message", "Kayıt Başarılı.", "Ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }
            else
            {

                await App.Current.MainPage.DisplayAlert("Message", "Böyle bir kullanıcı zaten kayıtlı!", "Ok");
            }
        }

        public async void selectImage()
        {
            MediaFile file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full
            });
            if (file == null)
                return;

            var memoryStream = new MemoryStream();
            file.GetStream().CopyTo(memoryStream);
            UserImage = memoryStream.ToArray();
            ImgSource = ImageSource.FromStream(file.GetStream);
            // file.Dispose();
        }

        public string Password
        {
            get => password; set
            {
                if (password != value)
                    password = value;
            }
        }
        public string Name
        {
            get => name; set
            {
                if (name != value)
                    name = value;
            }
        }
        public string Surname
        {
            get => surname; set
            {
                if (surname != value)
                    surname = value;
            }
        }
        public ImageSource ImgSource
        {
            get => imgSource; set
            {
                if (imgSource != value)
                {
                    imgSource = value;
                    OnPropertyChanged("ImgSource");
                }
            }
        }

        public ICommand ImageSelectCommand { get => imageSelectCommand; set => imageSelectCommand = value; }
        public ICommand SingUpCommand { get => singUpCommand; set => singUpCommand = value; }
        public byte[] UserImage { get => userImage; set => userImage = value; }
    }
}
