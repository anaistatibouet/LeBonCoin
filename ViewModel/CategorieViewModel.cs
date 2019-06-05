using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.ViewModel
{
    class CategorieViewModel
    {
        private static ObservableCollection<Model.CategorieModel> _listCategorie;
        public static ObservableCollection<Model.CategorieModel> ListCategorie { get; set; }


        private int _id;
        private string _title;
        private string _description;
        private int _prix;
        private int _tel;
        private int _idcategorie;
        private int _iduser;
        //pour l'instant on stock les id avant de creer les objets en entier et de les stocker



        public CategorieViewModel()
        {


        }


        public static Model.CategorieModel GetCategorieParId(int id)
        {
            Model.CategorieModel cat = new Model.CategorieModel();
            ObservableCollection<Model.CategorieModel> categories = new ObservableCollection<Model.CategorieModel>();
            categories = GetCategories();
            //on parcourt toutes les categories
            foreach(Model.CategorieModel item in categories)
            {
                //si on a un id egal a celui qu'on a en param
                if (item.ID == id)
                {
                    cat = item; //cat vaut l'objet en question
                }
            }
            return cat;
        }
        //Methode qui recupere toute les categories
        public static ObservableCollection<Model.CategorieModel> GetCategories()
        {
            ObservableCollection<Model.CategorieModel> deuxannonces = new ObservableCollection<Model.CategorieModel>();


            //requete a la bdd 
            Model.CategorieModel c = new Model.CategorieModel()
            {
                ID = 1,
                Nom = "Jeux",
               

            };
            Model.CategorieModel c2 = new Model.CategorieModel()
            {
                ID = 2,
                Nom = "Vetement",

            };
            deuxannonces.Add(c);
            deuxannonces.Add(c2);
            return deuxannonces;

        }
    }
}
