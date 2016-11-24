using Xamarin.Forms;

namespace MVVMonkey.Playground.View
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.MainViewModel();
        }
    }
}
