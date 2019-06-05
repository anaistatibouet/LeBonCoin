using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.ViewModel
{
    class AnnonceViewModel : SimpleObservableObject
    {
        private static ObservableCollection<Model.AnnonceModel> _listAnnonce;
        public static ObservableCollection<Model.AnnonceModel> ListAnnonce { get; set; }


        private int _id;
        private string _title;
        private string _description;
        private int _prix;
        private int _tel;
        private Model.CategorieModel _categorie;
        private Model.UserModel _user;
        //pour l'instant on stock les id avant de creer les objets en entier et de les stocker



        public AnnonceViewModel()
        {
          
            
        }

        public static ObservableCollection<Model.AnnonceModel> getAnnonces()
        {
            ObservableCollection<Model.AnnonceModel> deuxannonces = new ObservableCollection<Model.AnnonceModel>();


            //requete a la bdd 
            Model.AnnonceModel a = new Model.AnnonceModel()
            {
                ID = 1,
                Title = "oui",
                Description = "Desc1",
                Prix = 10,
                Tel = 0682344200,
                Categorie = CategorieViewModel.GetCategorieParId(1),
                User = UserViewModel.GetUserParId(1)

            };
            Model.AnnonceModel a2 = new Model.AnnonceModel()
            {
                ID = 2,
                Title = "non",
                Description = "Desc2",
                Prix = 25,
                Tel = 0682344200,
                Categorie = CategorieViewModel.GetCategorieParId(2),
                User = UserViewModel.GetUserParId(3)

            };
            deuxannonces.Add(a);
            deuxannonces.Add(a2);
            return deuxannonces;

        }

    }
}
