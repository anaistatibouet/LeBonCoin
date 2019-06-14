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
	public partial class MesAnnonces : ContentPage
	{
		public MesAnnonces ()
		{
			InitializeComponent ();
            this.BindingContext = new MesAnnoncesViewModel(Navigation);
		}
	}
}