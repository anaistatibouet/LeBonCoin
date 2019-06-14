using System;
using System.Collections.Generic;
using System.Text;
using Leboncoin.DAL;
using Leboncoin.Model;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace Leboncoin.ViewModel
{
    public class InscriptionViewModel : SimpleObservableObject
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

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { Set(ref _nom, value); }
        }

        private string _prenom;
        public string Prenom
        {
            get { return _prenom; }
            set { Set(ref _prenom, value); }
        }


        public INavigation Navigation { get; set; }

        public InscriptionViewModel(INavigation nav)
        {
            this.Navigation = nav;
        }

        private Command _inscription;
        public Command Inscription => _inscription
            ??
            (_inscription = new Command(async () =>
            {
                var conn = DependencyService.Get<IDbConnection>().DbConnection();
                
                var newuser = new UserModel {
                    Nom = this.Nom,
                    Prenom = this.Prenom,
                    Login = this.Login,
                    Mdp = this.MotDePasse
                };

                conn.Insert(newuser);
                Application.Current.Properties["Utilisateur"] = newuser;
                await Navigation.PushAsync(new MainPage());
            }
            ));
    }
}
