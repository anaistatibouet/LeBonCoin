using Leboncoin.ViewModel;
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
	public partial class AjoutAnnonce : ContentPage
	{
		public AjoutAnnonce ()
		{
			InitializeComponent ();
            this.BindingContext = new AjoutAnnonceViewModel(Navigation);
		}
	}
}