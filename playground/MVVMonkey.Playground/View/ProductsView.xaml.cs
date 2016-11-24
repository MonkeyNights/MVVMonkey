using Xamarin.Forms;

namespace MVVMonkey.Playground.View
{
    public partial class ProductsView : ContentPage
    {
        public ProductsView()
        {
            InitializeComponent();
            var vm = new ViewModel.ProductsViewMode();
            this.BindingContext = vm;
            this.listView.ItemSelected += async (sender, e) =>
            {
                var parameter = new Core.Services.NavigationParameters("product", e.SelectedItem as Model.Product);
                await vm.NavigationService.GoAsync("DetailsProductView", parameter);
            };
        }
    }
}