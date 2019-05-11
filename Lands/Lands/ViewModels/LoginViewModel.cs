using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using Lands.Views;

namespace Lands.ViewModels
{

    public class LoginViewModel : BaseViewModels
    {
        #region eventos
        //interface era INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region atributos
        private string email;
        private string password;
        private bool isrunning;
        private bool isenable;

        

        #endregion


        #region propiedades
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }


        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
          //  #region cambios necesarios para usar interfas INotifyPropertyChanged
          //  get { return this.password; }
          //  set
           // {
           //     if (this.password != value)
           //     {
            //        this.password = value;
             //       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Password)));
             //   }
            //} 
            //#endregion
        }
        public bool IsRunning
        {
            get { return this.isrunning; }
            set { SetValue(ref this.isrunning, value); }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnable
        {
            get { return this.isenable; }
            set { SetValue(ref this.isenable, value); }
        }
        #endregion
        #region constructores
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnable = true;

            this.Email = "hector";
            this.Password = "hola";
        }

  
        #endregion
        #region comandos
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("error", "enter a email", "ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("error", "enter a password", "ok");
                return;
            }

            if (this.Email != "hector" || this.Password != "hola")
            {
                this.IsRunning = false;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert("error", "email o paas incorrect", "ok");
                this.Password = string.Empty;
                return;               
            }
            this.IsRunning = false;
            this.IsEnable = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
    }


}
