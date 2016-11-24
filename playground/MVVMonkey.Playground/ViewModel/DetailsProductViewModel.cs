using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;

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

        public void OnNavigate(NavigationParameters navigationParameters)
        {
            this.Product = navigationParameters.GetValue<Model.Product>("product");
            this.Title = this.Product.Name;
        }
    }
}