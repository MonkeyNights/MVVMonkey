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
        public ICommand AddToCartCommand { get; }
        
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

            this.AddToCartCommand = new ViewModelCommand<Model.Product>(this, async (product) => {
                var ok = new DisplayAlertAction("Ok", async () => {
                    await this.NavigationService.GoAsync("MainView");
                });
                await this.DisplayAlertService.DisplayAlertAsync("Product Show Case", $"Product {product.Name} added successfully", ok);
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
