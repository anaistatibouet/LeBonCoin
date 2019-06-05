using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Leboncoin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Connexion : ContentPage
	{
		public Connexion ()
		{
			InitializeComponent ();
		}
        public void Login(object sender, EventArgs e)
        {
            string pseudo = Pseudo.Text;
            int password = Convert.ToInt32(Password.Text);

            Model.UserModel usrtest = ViewModel.UserViewModel.GetUserCo(pseudo, password);
            if(usrtest.Nom != null)
            {
                Application.Current.Properties["iduser"] = 1;
                Navigation.PushAsync(new MainPage());
            }
          
        }
        public void VersInscription(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.Inscription());

        }

    }
}