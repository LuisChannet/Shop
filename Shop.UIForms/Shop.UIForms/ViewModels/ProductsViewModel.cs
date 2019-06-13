
namespace Shop.UIForms.ViewModels
{
    using Shop.Common.Models;
    using Shop.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> products;
        private readonly ApiService apiService;
        private bool isRefreshing;
        public ObservableCollection<Product> Products { get => products; set => SetValue(ref products, value); }

        public bool IsRefreshing { get => isRefreshing; set => SetValue(ref isRefreshing, value); }
        public ProductsViewModel()
        {
            apiService = new ApiService();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            this.isRefreshing = true;
            var response = await apiService.GetListAsync<Product>("http://azul.inteligenciatotal.com", "/api", "/Products");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var myProducts = (List<Product>)response.Result;
            Products = new ObservableCollection<Product>();
            this.isRefreshing = false;
        }
    }
}
