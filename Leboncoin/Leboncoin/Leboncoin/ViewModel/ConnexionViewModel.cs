using System;
using System.Collections.Generic;
using System.Text;
using Leboncoin.DAL;
using Leboncoin.Model;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using Leboncoin.View;

namespace Leboncoin.ViewModel
{
    public class ConnexionViewModel : SimpleObservableObject
    {
        private string _login;
        public string Login
        {
            get { return _login; }
            set { Set(ref _login, value); }
        }

        private int _motdepasse;
        public int MotDePasse
        {
            get { return _motdepasse; }
            set { Set(ref _motdepasse, value); }
        }


        public INavigation Navigation { get; set; }

        public ConnexionViewModel(INavigation nav)
        {
            this.Navigation = nav;

            //Initialisation de la connexion avec la base de données
            var conn = DependencyService.Get<IDbConnection>().DbConnection();

            //Creation des tables
            conn.CreateTable<AnnonceModel>();
            conn.CreateTable<CategorieModel>();
            conn.CreateTable<UserModel>();

            //Check qui vérifie si l'application est lancée pour la première fois,
            //Ajoute des données si c'est le cas
            var item = (IList<CategorieModel>)conn.Query<CategorieModel>("Select * from [Categorie]").ToList();
            if (item.Count() == 0)
            {
                Ajout_Donnees();
            }
        }

        public void Ajout_Donnees()
        {
            var conn = DependencyService.Get<IDbConnection>().DbConnection();

            conn.Insert(new CategorieModel { Nom = "Console & Jeux Videos" });
            conn.Insert(new CategorieModel { Nom = "Immobiliers" });
            conn.Insert(new CategorieModel { Nom = "Electroménager" });
            conn.Insert(new CategorieModel { Nom = "Sport" });
            conn.Insert(new CategorieModel { Nom = "Véhicules" });
            conn.Insert(new UserModel { Prenom = "Toto", Nom = "tata", Login = "toutou", Mdp = 123 });
            conn.Insert(new AnnonceModel { Titre = "PS4", Description = "Comme neuf", CategorieId = 1, Prix=200, Tel=0645879512, UserId=1 });
        }

        // Vérification que le login et le mot de passe correspondent
        private Command _connexion;
        public Command Connexion => _connexion
            ??
            (_connexion = new Command(async () =>
                {
                    var conn = DependencyService.Get<IDbConnection>().DbConnection();

                    try
                    {
                        var users = (IList<UserModel>)conn.Query<UserModel>("Select * from [User] where Login=?", this.Login).ToList();
                        if (users[0].Mdp == this.MotDePasse)
                        {
                            Application.Current.Properties["Utilisateur"] = users[0];
                            await Navigation.PushAsync(new MainPage());
                        }
                    }
                    catch
                    {

                    }
                    
                }
            ));

        private Command _inscription;
        public Command Inscription => _inscription
            ??
            (_inscription = new Command(async () =>
                {
                    
                    await Navigation.PushAsync(new Inscription());
                   
                }
            ));
    }
}
