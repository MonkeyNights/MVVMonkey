using MVVMonkey.Core.Services;
using Xamarin.Forms;

namespace MVVMonkey.Core.ViewModel
{
    public abstract class ViewModelBase : NotifyPropertyChangedBase
    {
        public INavigationService NavigationService { get; }
        public IDisplayAlertService DisplayAlertService { get; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public ViewModelBase(string title = "")
        {
            this.NavigationService = DependencyService.Get<INavigationService>();
            this.DisplayAlertService = DependencyService.Get<IDisplayAlertService>();
            Title = title;
        }
    }
}
