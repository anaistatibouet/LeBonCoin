using Leboncoin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using SQLite;
using System.Linq;


namespace Leboncoin.DAL
{
    public class AnnoncesDb
    {
        private SQLiteConnection database;
        private static object CollisionLock = new object();

        public ObservableCollection<AnnonceModel> Annonces { get; set; }

        public AnnoncesDb()
        {
            database = DependencyService.Get<IDbConnection>().DbConnection();
            database.CreateTable<AnnonceModel>();

            this.Annonces = new ObservableCollection<AnnonceModel>(database.Table<AnnonceModel>());
        }

        public AnnonceModel GetAnnonce(int id)
        {
            lock (CollisionLock)
            {
                return database.Table<AnnonceModel>().FirstOrDefault(annonce => annonce.ID == id);
            }
        }

        public int AddAnnonce(AnnonceModel annonce)
        {
            lock (CollisionLock)
            {
                if (annonce.ID != 0)
                {
                    database.Update(annonce);
                    return annonce.ID;
                }
                else
                {
                    database.Insert(annonce);
                    return annonce.ID;
                }
            }
        }

        public int DeleteAnnonce(AnnonceModel annonce)
        {
            var id = annonce.ID;
            if (id != 0)
            {
                lock (CollisionLock)
                {
                    database.Delete<AnnonceModel>(id);
                }
            }
            this.Annonces.Remove(annonce);
            return id;
        }

        // Gérer filtre Annonces User
    }
}
