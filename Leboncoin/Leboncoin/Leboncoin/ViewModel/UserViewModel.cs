using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.ViewModel
{
    class UserViewModel
    {
        private static ObservableCollection<Model.UserModel> _listuser;
        public static ObservableCollection<Model.UserModel> ListUser { get; set; }


        private int _id;
        private string _nom;
        private string _prenom;
        private string _login;
        private int _password;
        //pour l'instant on stock les id avant de creer les objets en entier et de les stocker



        public UserViewModel()
        {


        }
        public static void AddUser(int id, string nom, string prenom, string pseudo, int password)
        {
            Model.UserModel useradd = new Model.UserModel();
            useradd.ID = id;
            useradd.Nom = nom;
            useradd.Prenom = prenom;
            useradd.Login = pseudo;
            useradd.Password = password;

            ListUser.Add(useradd);
        }

        public static Model.UserModel GetUserCo(string login, int password)
        {
            Model.UserModel usr = new Model.UserModel();
            ObservableCollection<Model.UserModel> AllUsers = GetUsers();
            foreach(Model.UserModel item in AllUsers) //parmis tous les users
            {
                if(item.Login==login && item.Password == password) //si le login et mdp correspondent 
                {
                    usr = item;
                }
            }
            return usr;
        }


        
        public static Model.UserModel GetUserParId(int id)
        {
            Model.UserModel us = new Model.UserModel();
            ObservableCollection<Model.UserModel> users = new ObservableCollection<Model.UserModel>();
            users = GetUsers();
            //on parcourt toutes les categories
            foreach (Model.UserModel item in users)
            {
                //si on a un id egal a celui qu'on a en param
                if (item.ID == id)
                {
                    us = item; //cat vaut l'objet en question
                }
            }
            return us;
        }
        
        //Methode qui recupere toute les categories
        public static ObservableCollection<Model.UserModel> GetUsers()
        {
            ObservableCollection<Model.UserModel> deuxusers = new ObservableCollection<Model.UserModel>();
            

            //requete a la bdd 
            Model.UserModel u = new Model.UserModel()
            {
                ID = 1,
                Nom = "Breton",
                Prenom ="Bryan",
                Login = "bryb44",
                Password = 123456


            };
            Model.UserModel u2 = new Model.UserModel()
            {
                ID = 2,
                Nom = "Tatibouet",
                Prenom = "Anais",
                Login = "atat44",
                Password = 123456

            };
            deuxusers.Add(u);
            deuxusers.Add(u2);
            return deuxusers;

        }
    }
}
