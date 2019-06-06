using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.Model
{
    class AnnonceModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Prix { get; set; }
        public int Tel { get; set; }
        public CategorieModel Categorie { get; set; }
        public UserModel User { get; set; }


        public static ObservableCollection<Model.AnnonceModel> LesAnnonces(int iduser)
        {
            return ViewModel.AnnonceViewModel.AnnonceSaufMoi(iduser);
        }

    }
}
