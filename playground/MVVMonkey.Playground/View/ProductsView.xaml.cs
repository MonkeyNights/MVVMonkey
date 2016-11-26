using Xamarin.Forms;

namespace MVVMonkey.Playground.View
{
    public partial class ProductsView : ContentPage
    {
        private readonly ViewModel.ProductsViewModel _viewModel = new ViewModel.ProductsViewModel();

        public ProductsView()
        {
            InitializeComponent();
            
            BindingContext = _viewModel;
            listView.ItemSelected += async (sender, e) =>
            {
                var parameter = new Core.Services.NavigationParameters("product", e.SelectedItem as Model.Product);
                await _viewModel.NavigationService.GoAsync("DetailsProductView", parameter);
            };
        }

        protected void AddToCartClicked(object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            _viewModel.AddToCartCommand.Execute(menuItem.CommandParameter as Model.Product);
        }
    }
}