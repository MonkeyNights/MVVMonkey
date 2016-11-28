using System;
using System.Threading.Tasks;

namespace MVVMonkey.Core.Services
{
    public interface INavigationService
    {
        Task GoAsync<ViewModel>(NavigationParameters parameters = null, NavigationBehavior navigationBehavior = NavigationBehavior.Default);
        Task GoBackAsync(NavigationParameters parameters = null);
        Task ShowPopupAsync<ViewModel>(NavigationParameters parameters = null);
        void Configure<View, ViewModel>();
        void Start<ViewModel>(NavigationParameters parameters = null, bool navigationPage = true);
    }
}