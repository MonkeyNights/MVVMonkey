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
            this.AddToCartCommand = new ViewModelCommand(this, async () => {
                await this.DisplayAlertService.DisplayAlertAsync("Products Show Case", "Done!", new DisplayAlertAction("Ok", async () => {
                    await this.NavigationService.GoAsync("MainView");
                }));
            });
        }

        public void OnNavigate(NavigationParameters navigationParameters)
        {
            this.Product = navigationParameters.GetValue<Model.Product>("product");
            this.Title = this.Product.Name;
        }
    }
}