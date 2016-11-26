using MVVMonkey.Core.ViewModel;
using MVVMonkey.Core.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace MVVMonkey.Playground.ViewModel
{
    public class ProductsViewModel : ViewModelBase, INavigationViewModel
    {
        public ICommand RefreshCommand { get; }
        public ICommand AddToCartCommand { get; }
        
        public ObservableCollection<Model.Product> Products { get; } = new ObservableCollection<Model.Product>();

        public ProductsViewModel()
        {
            Title = "Products";
            RefreshCommand = new ViewModelCommand(this, () =>
            {
                Products.Add(new Model.Product {
                    Id = Products.Count + 1,
                    Name = DateTime.Now.ToString(),
                    Image = "monkey.png",
                    Price = Products.Count + 1
                });
            });

            AddToCartCommand = new ViewModelCommand<Model.Product>(this, async (product) => {
                var ok = new DisplayAlertAction("Ok", async () => {
                    await NavigationService.GoAsync("MainView");
                });
                await DisplayAlertService.DisplayAlertAsync("Product Show Case", $"Product {product.Name} added successfully", ok);
            });
        }

        public void OnNavigate(NavigationParameters navigationParameters)
        {
            var products = navigationParameters.GetValue<List<Model.Product>>("products");
            foreach (var product in products)
                Products.Add(product);
        }
    }
}
