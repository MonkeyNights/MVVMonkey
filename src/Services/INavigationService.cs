using System;
using System.Threading.Tasks;

namespace MVVMonkey.Core.Services
{
    public interface INavigationService
    {
        Task GoAsync(string pageKey, NavigationParameters parameters = null, NavigationBehavior navigationBehavior = NavigationBehavior.Default);
        Task BackAsync(NavigationParameters parameters = null);
        void Configure(string key, Type pageType);
    }
}