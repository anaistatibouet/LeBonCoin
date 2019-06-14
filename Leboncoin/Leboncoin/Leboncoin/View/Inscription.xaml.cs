﻿using Leboncoin.ViewModel;
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
	public partial class Inscription : ContentPage
	{
		public Inscription()
		{
			InitializeComponent();
            this.BindingContext = new InscriptionViewModel(Navigation);
		}
	}
}