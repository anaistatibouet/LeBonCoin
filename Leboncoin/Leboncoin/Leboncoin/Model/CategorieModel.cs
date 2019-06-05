using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Leboncoin.Model
{
    class CategorieModel
    {
        public int ID { get; set; }
        public string Nom { get; set; }
  


        public static ObservableCollection<CategorieModel> LesAnnonces()
        {
            return ViewModel.CategorieViewModel.GetCategories();
        }
    }
}
