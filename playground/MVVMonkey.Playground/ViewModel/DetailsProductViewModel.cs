using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;
using System.Windows.Input;

namespace MVVMonkey.Playground.ViewModel
{
    public class DetailsProductViewModel : ViewModelBase, INavigationViewModel
    {
        private Model.Product _product;
        public Model.Product Product
        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }

        public ICommand AddToCartCommand { get; }

        public DetailsProductViewModel()
        {
            var ok = new DisplayAlertAction("Ok", async () => {
                await NavigationService.GoAsync<MainViewModel>();
            });

            AddToCartCommand = new ViewModelCommand(this, async () => {
                await DisplayAlertService.DisplayAlertAsync("Products Show Case", $"Product {Product.Name} added successfully", ok);
            });
        }

        public void OnNavigate(NavigationParameters navigationParameters)
        {
            Product = navigationParameters.GetValue<Model.Product>("product");
            Title = Product.Name;
        }
    }
}