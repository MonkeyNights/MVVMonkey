using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMonkey.Core.Services
{
    public class NavigationService : INavigationService
    {
        private Dictionary<string, Type> _pagesDictionary = new Dictionary<string, Type>();

        public Page CurrentPage
            => Xamarin.Forms.Application.Current.MainPage;

        public void Configure(string key, Type pageType)
            => _pagesDictionary[key] = pageType;

        public async Task BackAsync(NavigationParameters parameters = null)
        {
            await CurrentPage.Navigation.PopAsync();
        }

        public async Task GoAsync(string pageKey, NavigationParameters parameters = null, NavigationBehavior navigationBehavior = NavigationBehavior.Default)
        {
            var newInstacePage = this.CreateNewInstacePage(pageKey, parameters);
            if (navigationBehavior == NavigationBehavior.ClearBackstak)
            {
                CurrentPage.Navigation.InsertPageBefore(newInstacePage, CurrentPage.Navigation.NavigationStack.FirstOrDefault());
                foreach (var page in CurrentPage.Navigation.NavigationStack)
                    CurrentPage.Navigation.RemovePage(page);
            }
            else
                await CurrentPage.Navigation.PushAsync(newInstacePage);
        }

        private Page CreateNewInstacePage(string pageKey, NavigationParameters parameters = null)
        {
            if (!_pagesDictionary.ContainsKey(pageKey))
                throw new ArgumentException($"Page : {pageKey} not found!", nameof(pageKey));

            Type pageType = _pagesDictionary[pageKey];
            var newInstacePage = Activator.CreateInstance(pageType) as Page;
            if (newInstacePage == null)
                throw new ArgumentException($"Cannot create a new instance of {pageKey}", nameof(pageKey));

            if (parameters != null)
            {
                newInstacePage.AddNavigationArgs(parameters);
                var viewmodel = newInstacePage.BindingContext as INavigationViewModel;
                if (viewmodel != null)
                    viewmodel.OnNavigate(parameters);
            }

            return newInstacePage;
        }
    }
}
