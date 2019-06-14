using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.Model
{
    [Table("Categorie")]
    public class CategorieModel
    {
        private int _id;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nom;
        [MaxLength(100), NotNull]
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        [OneToMany]
        public List<AnnonceModel> AnnonceCategorie { get; set; }

    }
}
