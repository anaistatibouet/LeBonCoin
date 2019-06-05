using Leboncoin.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Leboncoin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("pseudo"))
            {

            } else
            {
                Navigation.PushAsync(new View.Connexion());
            }
            
           
        }
        public void VersAnnonces(object sender, EventArgs e)
        {
           
                Navigation.PushAsync(new View.Annonces());
            
        }
    }
}
