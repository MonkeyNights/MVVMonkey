using MVVMonkey.Core.ViewModel;
using Xamarin.Forms;

namespace MVVMonkey.Core.View
{
    public abstract class BaseView<TViewModel> : ContentPage where TViewModel : ViewModelBase
    {
        TViewModel vm;
        public TViewModel ViewModel => vm ?? (vm = BindingContext as TViewModel);
    }
}
