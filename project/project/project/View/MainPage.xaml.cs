using project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace project
{
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();

                 BindingContext = new MainViewModel();

                // A gérer dans le ViewModel Bryan :)
                if (Application.Current.Properties.ContainsKey("pseudo"))
                {

                }
                else
                {
                    Navigation.PushAsync(new View.Connexion());
                }
            }
        }
    }
