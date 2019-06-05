using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.Model
{
    class UserModel
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }


        public static ObservableCollection<UserModel> LesUsers()
        {
            return ViewModel.UserViewModel.GetUsers();
        }
    }
}
