using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.Model
{
    [Table("Annonces")]
    public class AnnonceModel
    {

        private int _id;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _titre;

        [MaxLength(50), NotNull]
        public string Titre {
            get { return _titre; }
            set { _titre = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private double _prix;

        [NotNull]
        public double Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        private string _date;

        [NotNull]
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private int _tel;

        [NotNull]
        public int Tel {
            get { return _tel; }
            set { _tel = value; }
        }

        private CategorieModel _categorie;

        [NotNull]
        public CategorieModel Categorie {
            get { return _categorie; }
            set { _categorie = value; }
        }

        private UserModel _user;

        [NotNull]
        public UserModel User {
            get { return _user; }
            set { _user = value; }
        }


        public static ObservableCollection<Model.AnnonceModel> LesAnnonces(int iduser)
        {
            return ViewModel.AnnonceViewModel.AnnonceSaufMoi(iduser);
        }

    }
}
