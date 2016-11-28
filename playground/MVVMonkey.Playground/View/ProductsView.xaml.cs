using Xamarin.Forms;

namespace MVVMonkey.Playground.View
{
    public partial class ProductsView : ContentPage
    {
        public ViewModel.ProductsViewModel ViewModel { get { return (ViewModel.ProductsViewModel)BindingContext; } }

        public ProductsView()
        {
            InitializeComponent();
            
            listView.ItemSelected += async (sender, e) =>
            {
                var parameter = new Core.Services.NavigationParameters("product", e.SelectedItem as Model.Product);
                await ViewModel.NavigationService.GoAsync<ViewModel.DetailsProductViewModel>(parameter);
            };
        }

        protected void AddToCartClicked(object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            ViewModel.AddToCartCommand.Execute(menuItem.CommandParameter as Model.Product);
        }
    }
}