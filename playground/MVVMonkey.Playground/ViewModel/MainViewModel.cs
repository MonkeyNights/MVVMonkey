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
            this.ShowAllProductsCommand = new Command(async () =>
            {
                await this.NavigationService.GoAsync("ProductsView", new Core.Services.NavigationParameters("products", products));
            });

            this.Title = "Products Show Case";
            this.Products = new ObservableCollection<Model.Product>();
            foreach (var product in products)
                this.Products.Add(product);
        }
    }
}