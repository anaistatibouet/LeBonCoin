using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Connexion : ContentPage
	{
		public Connexion ()
        {
            InitializeComponent();
        }
       

        private void Verification(object sender, EventArgs e)
        {
            string pseudo = Pseudo.Text;
            string password = Password.Text;
            if (pseudo == "oui" && password == "oui")
            {
                Navigation.PushAsync(new MainPage());
            }
        }
    }
}