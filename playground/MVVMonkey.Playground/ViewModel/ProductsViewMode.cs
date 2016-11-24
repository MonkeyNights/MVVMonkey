using MVVMonkey.Core.ViewModel;
using MVVMonkey.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace MVVMonkey.Playground.ViewModel
{
    public class ProductsViewMode : ViewModelBase, INavigationViewModel
    {
        public ICommand RefreshCommand { get; }
        public ObservableCollection<Model.Product> Products { get; } = new ObservableCollection<Model.Product>();

        public ProductsViewMode()
        {
            this.Title = "Products";
            this.RefreshCommand = new ViewModelCommand(this, () =>
            {
                this.Products.Add(new Model.Product {
                    Id = this.Products.Count + 1,
                    Name = DateTime.Now.ToString(),
                    Image = "monkey.png",
                    Price = this.Products.Count + 1
                });
            });
        }

        public void OnNavigate(NavigationParameters navigationParameters)
        {
            var products = navigationParameters.GetValue<List<Model.Product>>("products");
            foreach (var product in products)
                this.Products.Add(product);
        }
    }
}
