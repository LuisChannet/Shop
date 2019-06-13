
namespace Shop.UIForms.ViewModels
{
using System;
using System.Collections.Generic;
using System.Text;
   public  class MainViewModel
    {

        private static MainViewModel instance;

        public LoginViewModel Login { get; set; }
        public ProductsViewModel Products { get; set; }
        public MainViewModel()
        {
            //this.Login = new LoginViewModel();
            instance = this;
        }
        public static MainViewModel GetInstance()
        {
            if (instance == null) { return new MainViewModel(); }
            return instance;
        }
    }
}
