using Leboncoin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Leboncoin.DAL
{
    public class UserDb
    {
        private SQLiteConnection database;
        private static object CollisionLock = new object();

        public ObservableCollection<UserModel> Utilisateurs { get; set; }


        public UserDb()
        {
            database = DependencyService.Get<IDbConnection>().DbConnection();
            database.CreateTable<UserModel>();

            this.Utilisateurs = new ObservableCollection<UserModel>(database.Table<UserModel>());
        }

        public UserModel GetUtilisateur(int id)
        {
            lock (CollisionLock)
            {
                return database.Table<UserModel>().FirstOrDefault(utilisateur => utilisateur.ID == id);
            }
        }

        public int AddUtilisateur(UserModel utilisateur)
        {
            lock (CollisionLock)
            {
                if (utilisateur.ID != 0)
                {
                    database.Update(utilisateur);
                    return utilisateur.ID;
                }
                else
                {
                    database.Insert(utilisateur);
                    return utilisateur.ID;
                }
            }
        }

        public int DeleteUtilisateur(UserModel utilisateur)
        {
            var id = utilisateur.ID;
            if (id != 0)
            {
                lock (CollisionLock)
                {
                    database.Delete<UserModel>(id);
                }
            }
            this.Utilisateurs.Remove(utilisateur);
            return id;
        }


    }
}
