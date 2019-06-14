using SQLite;
using SQLiteNetExtensions.Attributes;
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
        [NotNull]
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

        private int _tel;
        [NotNull]
        public int Tel {
            get { return _tel; }
            set { _tel = value; }
        }

        private int _categorieId;
        [ForeignKey(typeof(CategorieModel)), NotNull]
        public int CategorieId {
            get { return _categorieId; }
            set { _categorieId = value; }
        }

        private int _userId;
        [ForeignKey(typeof(UserModel)), NotNull]
        public int UserId {
            get { return _userId; }
            set { _userId = value; }
        }

    }
}
