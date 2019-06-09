using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.Model
{
    [Table("User")]
    public class UserModel
    {
        private int _id;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nom;

        [MaxLength(30), NotNull]
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _prenom;
        [MaxLength(30), NotNull]
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        private string _login;
        [MaxLength(30), NotNull]
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private int _password;

        [MaxLength(6), NotNull]
        public int Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public static ObservableCollection<UserModel> LesUsers()
        {
            return ViewModel.UserViewModel.GetUsers();
        }
    }
}
