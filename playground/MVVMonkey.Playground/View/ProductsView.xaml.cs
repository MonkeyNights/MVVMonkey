using Xamarin.Forms;

namespace MVVMonkey.Playground.View
{
    public partial class ProductsView : ContentPage
    {
        public ProductsView()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.ProductsViewMode();
        }
    }
}
