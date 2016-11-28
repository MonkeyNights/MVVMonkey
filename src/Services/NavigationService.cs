using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMonkey.Core.Services
{
    public class NavigationService : INavigationService
    {
        private Dictionary<string, ViewViewModel> _viewsDictionary = new Dictionary<string, ViewViewModel>();

        private Page CurrentPage => Application.Current.MainPage;

        public void Configure<View, ViewModel>()
        {
            var viewType = typeof(View);
            var viewModelType = typeof(ViewModel);
            _viewsDictionary.Add(viewModelType.Name, new ViewViewModel(viewType, viewModelType));
        }

        public async Task GoBackAsync(NavigationParameters parameters = null)
        {
            Page page;
            if (CurrentPage.Navigation.ModalStack.Count > 0)
                page = await CurrentPage.Navigation.PopModalAsync();
            else
                page = await CurrentPage.Navigation.PopAsync();

            if (parameters != null)
                this.ConfigureNavigation(page, parameters);
        }

        public async Task GoAsync<ViewModel>(NavigationParameters parameters = null, NavigationBehavior navigationBehavior = NavigationBehavior.Default)
        {
            var newInstacePage = CreateNewInstacePage<ViewModel>(parameters);
            if (navigationBehavior == NavigationBehavior.ClearBackstak)
                this.ClearBackstak(newInstacePage);
            else
                await CurrentPage.Navigation.PushAsync(newInstacePage);
        }

        public async Task ShowPopupAsync<ViewModel>(NavigationParameters parameters = null)
        {
            var newInstacePage = CreateNewInstacePage<ViewModel>(parameters);
            await CurrentPage.Navigation.PushModalAsync(newInstacePage);
        }

        public void Start<ViewModel>(NavigationParameters parameters = null, bool navigationPage = true)
        {
            var newInstacePage = CreateNewInstacePage<ViewModel>(parameters);
            if (navigationPage)
                Application.Current.MainPage = new NavigationPage(newInstacePage);
            else
                Application.Current.MainPage = newInstacePage;
        }

        private void ClearBackstak(Page page)
        {
            CurrentPage.Navigation.InsertPageBefore(page, CurrentPage.Navigation.NavigationStack.FirstOrDefault());
            foreach (var stack in CurrentPage.Navigation.NavigationStack)
                CurrentPage.Navigation.RemovePage(stack);
        }

        private Page CreateNewInstacePage<ViewModel>(NavigationParameters parameters = null)
        {
            string pageKey = typeof(ViewModel).Name;

            if (!_viewsDictionary.ContainsKey(pageKey))
                throw new ArgumentException($"Page : {pageKey} not found!", nameof(pageKey));

            var viewViewModel = _viewsDictionary[pageKey];
            var newInstanceView = Activator.CreateInstance(viewViewModel.View) as Page;
            if (newInstanceView == null)
                throw new ArgumentException($"Cannot create a new instance of View {pageKey}", nameof(pageKey));

            var newInstanceViewModel = Activator.CreateInstance(viewViewModel.ViewModel);
            if (newInstanceViewModel == null)
                throw new ArgumentException($"Cannot create a new instance of ViewModel to View {pageKey}", nameof(pageKey));

            newInstanceView.BindingContext = newInstanceViewModel;

            this.ConfigureNavigation(newInstanceView, parameters);

            return newInstanceView;
        }

        private void ConfigureNavigation(Page page, NavigationParameters parameters = null)
        {
            page.AddNavigationArgs(parameters);
            var viewmodel = page.BindingContext as INavigationViewModel;
            if (viewmodel != null)
                viewmodel.OnNavigate(parameters);
        }

        private class ViewViewModel
        {
            public Type View { get; }
            public Type ViewModel { get; }

            public ViewViewModel(Type view, Type viewModel)
            {
                this.View = view;
                this.ViewModel = viewModel;
            }
        }
    }
}
