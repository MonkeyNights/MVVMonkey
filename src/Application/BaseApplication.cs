using MVVMonkey.Core.Services;
using System;

namespace Xamarin.Forms
{
    public static class BaseApplication
    {
        public static void Configure(this Application application, Action<INavigationService> initializeNavigation)
        {
            if (initializeNavigation == null) throw new ArgumentNullException(nameof(initializeNavigation));
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IDisplayAlertService, DisplayAlertService>();

            var navigationService = DependencyService.Get<INavigationService>();
            initializeNavigation(navigationService);
        }
    }
}
