using MVVMonkey.Core.Application;
using MVVMonkey.Core.Services;

using Xamarin.Forms;

namespace MVVMonkey.Playground
{
    public class App : BaseApplication
    {
        public App()
        {
            this.Configure();

            MainPage = new NavigationPage(new View.MainView());
        }

        protected override void InitializeNavigation(INavigationService navigationService)
        {
            navigationService.Configure("MainView", typeof(View.MainView));
            navigationService.Configure("ProductsView", typeof(View.ProductsView));
            navigationService.Configure("DetailsProductView", typeof(View.DetailsProductView));
        }
    }
}