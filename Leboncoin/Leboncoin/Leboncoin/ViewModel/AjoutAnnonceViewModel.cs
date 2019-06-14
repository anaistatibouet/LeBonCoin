using Leboncoin.DAL;
using Leboncoin.Model;
using Leboncoin.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Leboncoin.ViewModel
{
    public class AjoutAnnonceViewModel : SimpleObservableObject
    {

        private string _titre;
        public string Titre
        {
            get { return _titre; }
            set { Set(ref _titre, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { Set(ref _description, value); }
        }

        private double _prix;
        public double Prix
        {
            get { return _prix; }
            set { Set(ref _prix, value); }
        }

        private int _tel;
        public int Tel
        {
            get { return _tel; }
            set { Set(ref _tel, value); }
        }

        private int _catgorieid;
        public int CategorieId
        {
            get { return _catgorieid; }
            set { Set(ref _catgorieid, value); }
        }

        private int _index;
        public int Index {
            get { return _index;  }
            set { Set(ref _index, value); }
        }

        // Création de la liste des catégories
        private ObservableCollection<CategorieModel> _liste_categories;
        public ObservableCollection<CategorieModel> Liste_Categories
        {
            get { return _liste_categories; }
            set { Set(ref _liste_categories, value); }
        }

        public INavigation Navigation { get; set; }

        public AjoutAnnonceViewModel(INavigation nav)
        {
            this.Navigation = nav;

            var conn = DependencyService.Get<IDbConnection>().DbConnection();
            Liste_Categories = new ObservableCollection<CategorieModel>((IList<CategorieModel>)conn.Query<CategorieModel>("Select * from [Categorie]").ToList());
        }

        private Command _ajouterAnnonce;
        public Command AjouterAnnonce => _ajouterAnnonce
            ??
            (_ajouterAnnonce = new Command(async () =>
            {
                var conn = DependencyService.Get<IDbConnection>().DbConnection();

                var Utilisateur = (UserModel)Application.Current.Properties["Utilisateur"];

                var newannonce = new AnnonceModel
                {
                    Titre = this.Titre,
                    Description = this.Description,
                    Prix = this.Prix,
                    Tel = this.Tel,
                    CategorieId = Liste_Categories[CategorieId].ID,
                    UserId = Utilisateur.ID,
                };

                conn.Insert(newannonce);

                await Navigation.PushAsync(new MesAnnonces());
            }
            ));
    }
}
