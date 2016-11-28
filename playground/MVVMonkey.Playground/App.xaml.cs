using MVVMonkey.Core.Services;
using Xamarin.Forms;

namespace MVVMonkey.Playground
{
    public partial class App : Application
    {
        public App()
        {
            this.Configure(InitializeNavigation);
        }

        private void InitializeNavigation(INavigationService navigationService)
        {
            navigationService.Configure<View.LoginView, ViewModel.LoginViewModel>();
            navigationService.Configure<View.ForgotMyPasswordView, ViewModel.ForgotMyPasswordViewModel>();
            navigationService.Configure<View.MainView, ViewModel.MainViewModel>();
            navigationService.Configure<View.ProductsView, ViewModel.ProductsViewModel>();
            navigationService.Configure<View.DetailsProductView, ViewModel.DetailsProductViewModel>();

            navigationService.Start<ViewModel.LoginViewModel>(navigationPage: false);
        }
    }
}