using MVVMonkey.Core.Services;
using Xamarin.Forms;

namespace MVVMonkey.Playground
{
    public partial class App : Application
    {
        public App()
        {
            this.Configure(InitializeNavigation);

            MainPage = new NavigationPage(new View.MainView());
        }

        private void InitializeNavigation(INavigationService navigationService)
        {
            navigationService.Configure(nameof(View.MainView), typeof(View.MainView));
            navigationService.Configure(nameof(View.ProductsView), typeof(View.ProductsView));
            navigationService.Configure(nameof(View.DetailsProductView), typeof(View.DetailsProductView));
        }
    }
}