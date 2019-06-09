using Leboncoin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Leboncoin.DAL
{
    [Table("Categorie")]
    public class CategorieDb
    {
        private SQLiteConnection database;
        private static object CollisionLock = new object();

        public ObservableCollection<CategorieModel> Categories { get; set; }


        public CategorieDb()
        {
            database = DependencyService.Get<IDbConnection>().DbConnection();
            database.CreateTable<UserModel>();

            this.Categories = new ObservableCollection<CategorieModel>(database.Table<CategorieModel>());
        }

        public CategorieModel GetCategorie(int id)
        {
            lock (CollisionLock)
            {
                return database.Table<CategorieModel>().FirstOrDefault(categorie => categorie.ID == id);
            }
        }

        public int AddCategorie(CategorieModel categorie)
        {
            lock (CollisionLock)
            {
                if (categorie.ID != 0)
                {
                    database.Update(categorie);
                    return categorie.ID;
                }
                else
                {
                    database.Insert(categorie);
                    return categorie.ID;
                }
            }
        }

        public int DeleteCategorie(CategorieModel categorie)
        {
            var id = categorie.ID;
            if (id != 0)
            {
                lock (CollisionLock)
                {
                    database.Delete<CategorieModel>(id);
                }
            }
            this.Categories.Remove(categorie);
            return id;
        }

    }
}
