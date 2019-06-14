using System;
using System.Collections.Generic;
using System.Text;
using Leboncoin.DAL;
using Leboncoin.Model;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using Leboncoin.View;

namespace Leboncoin.ViewModel
{
    public class MainViewModel : SimpleObservableObject
    {
        private ObservableCollection<AnnonceModel> _liste_annonces;
        public ObservableCollection<AnnonceModel> Liste_Annonces
        {
            get { return _liste_annonces; }
            set { Set(ref _liste_annonces, value); }
        }

        public INavigation Navigation { get; set; }

        public MainViewModel(INavigation nav)
        {
            this.Navigation = nav;

            var Utilisateur = (UserModel)Application.Current.Properties["Utilisateur"];

            var conn = DependencyService.Get<IDbConnection>().DbConnection();

            Liste_Annonces = new ObservableCollection<AnnonceModel>((IList<AnnonceModel>)conn.Query<AnnonceModel>("Select * from [Annonces] where UserId!=?", Utilisateur.ID).ToList());
        }

        private Command _annonce;
        public Command Annonce => _annonce
            ??
            (_annonce = new Command(async Selected_Annonce =>
            {
                var Annonce = ((SelectedItemChangedEventArgs)Selected_Annonce).SelectedItem;
          
                await Navigation.PushAsync(new Annonces(Annonce as AnnonceModel));

            }
            ));


        private Command _ajoutAnnonce;
        public Command AjoutAnnonce => _ajoutAnnonce
            ??
            (_ajoutAnnonce = new Command(async () =>
            {
                await Navigation.PushAsync(new AjoutAnnonce());
            }
            ));

        private Command _mesAnnonces;
        public Command MesAnnonces => _mesAnnonces
            ??
            (_mesAnnonces = new Command(async () =>
            {
                await Navigation.PushAsync(new MesAnnonces());
            }
            ));
    }
}
