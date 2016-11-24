using MVVMonkey.Core.Services;
using Xamarin.Forms;

namespace MVVMonkey.Core.Application
{
    public abstract class BaseApplication : Xamarin.Forms.Application
    {
        public void Configure()
        {
            this.RegisterServices();
            var navigationService = DependencyService.Get<INavigationService>();
            InitializeNavigation(navigationService);
        }

        protected void RegisterServices()
        {
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IDisplayAlertService, DisplayAlertService>();
        }

        protected abstract void InitializeNavigation(INavigationService navigationService);
    }
}
