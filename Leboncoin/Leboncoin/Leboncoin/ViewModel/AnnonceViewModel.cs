using Leboncoin.DAL;
using Leboncoin.Model;
using Leboncoin.View;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Leboncoin.ViewModel
{
    public class AnnonceViewModel : SimpleObservableObject
    {

        private ObservableCollection<CategorieModel> _liste_categories;
        public ObservableCollection<CategorieModel> Liste_Categories
        {
            get { return _liste_categories; }
            set { Set(ref _liste_categories, value); }
        }

        private ObservableCollection<UserModel> _liste_utilisateurs;
        public ObservableCollection<UserModel> Liste_Utilisateurs
        {
            get { return _liste_utilisateurs; }
            set { Set(ref _liste_utilisateurs, value); }
        }

        private AnnonceModel _annonce;
        public AnnonceModel Annonce
        {
            get { return _annonce; }
            set { Set(ref _annonce, value); }
        }

        private UserModel _utilisateur;
        public UserModel Utilisateur
        {
            get { return _utilisateur; }
            set { Set(ref _utilisateur, value);  }
        }

        private CategorieModel categorie;
        public CategorieModel Categorie
        {
            get { return categorie; }
            set { Set(ref categorie, value); }
        }

        public INavigation Navigation { get; set; }

        public AnnonceViewModel(INavigation nav, AnnonceModel a)
        {
            this.Navigation = nav;
            this.Annonce = a;

            var conn = DependencyService.Get<IDbConnection>().DbConnection();
            Liste_Categories = new ObservableCollection<CategorieModel>((IList<CategorieModel>)conn.Query<CategorieModel>("Select * from [Categorie] where ID=?", Annonce.CategorieId).ToList());
            Categorie = Liste_Categories[0];

            Liste_Utilisateurs = new ObservableCollection<UserModel>((IList<UserModel>)conn.Query<UserModel>("Select * from [User] where ID=?", Annonce.UserId).ToList());
            Utilisateur = Liste_Utilisateurs[0];

        }

        private Command _composerNum;
        public Command ComposerNum => _composerNum
            ??
            (_composerNum = new Command( () =>
            {
                var PhoneCallTask = CrossMessaging.Current.PhoneDialer;
                if (PhoneCallTask.CanMakePhoneCall)
                    PhoneCallTask.MakePhoneCall(Annonce.Tel.ToString());
            }
            ));
      
    }
}
