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
	public partial class Annonces : ContentPage
	{
		public Annonces ()
		{
			InitializeComponent ();
            listeAnnonces.ItemsSource = Model.AnnonceModel.LesAnnonces(1);
            //BindingContext = new Model.AnnonceModel();
        }
	}
}