using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMonkey.Playground.ViewModel
{
    public class MainViewModel : ViewModelBase, INavigationViewModel
    {
        public string _welcomeMessage;
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { this.SetProperty(ref _welcomeMessage, value); }
        }

        public ObservableCollection<Model.Product> Products { get; }

        public ICommand ShowAllProductsCommand { get; }

        public MainViewModel()
        {
            var products = Model.Product.ListAll();
            ShowAllProductsCommand = new Command(async () =>
            {
                var parameters = new NavigationParameters("products", products);
                await NavigationService.GoAsync<ProductsViewModel>(parameters);
            });

            Title = "Products Show Case";
            Products = new ObservableCollection<Model.Product>();
            foreach (var product in products)
                Products.Add(product);
        }

        public void OnNavigate(NavigationParameters navigationParameters)
        {
            var username = navigationParameters.GetValue<string>("username");
            this.WelcomeMessage = $"Hello {username}";
        }
    }
}