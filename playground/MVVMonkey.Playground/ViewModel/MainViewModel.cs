using MVVMonkey.Core.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMonkey.Playground.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Model.Product> Products { get; }

        public ICommand ShowAllProductsCommand { get; }

        public MainViewModel()
        {
            var products = Model.Product.ListAll();
            ShowAllProductsCommand = new Command(async () =>
            {
                await NavigationService.GoAsync("ProductsView", new Core.Services.NavigationParameters("products", products));
            });

            Title = "Products Show Case";
            Products = new ObservableCollection<Model.Product>();
            foreach (var product in products)
                Products.Add(product);
        }
    }
}