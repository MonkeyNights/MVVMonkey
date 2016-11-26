using Xamarin.Forms;

namespace MVVMonkey.Playground.View
{
    public partial class DetailsProductView : ContentPage
    {
        public DetailsProductView()
        {
            InitializeComponent();

            BindingContext = new ViewModel.DetailsProductViewModel();
        }
    }
}
