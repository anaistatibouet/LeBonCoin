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
    public class MesAnnoncesViewModel : SimpleObservableObject
    {
        private ObservableCollection<AnnonceModel> _liste_mes_annonces;
        public ObservableCollection<AnnonceModel> Liste_MesAnnonces
        {
            get { return _liste_mes_annonces; }
            set { Set(ref _liste_mes_annonces, value); }
        }

        public INavigation Navigation { get; set; }

        public MesAnnoncesViewModel(INavigation nav)
        {
            this.Navigation = nav;

            var Utilisateur = (UserModel)Application.Current.Properties["Utilisateur"];

            var conn = DependencyService.Get<IDbConnection>().DbConnection();

            Liste_MesAnnonces = new ObservableCollection<AnnonceModel>((IList<AnnonceModel>)conn.Query<AnnonceModel>("Select * from [Annonces] where UserId=?", Utilisateur.ID).ToList());
        }

    }
}
