using MVVMonkey.Core.Services;
using Xamarin.Forms;

namespace MVVMonkey.Playground
{
    public partial class App : Application
    {
        public App()
        {
            this.Configure(this.InitializeNavigation);

            MainPage = new NavigationPage(new View.MainView());
        }

        private void InitializeNavigation(INavigationService navigationService)
        {
            navigationService.Configure("MainView", typeof(View.MainView));
            navigationService.Configure("ProductsView", typeof(View.ProductsView));
            navigationService.Configure("DetailsProductView", typeof(View.DetailsProductView));
        }
    }
}