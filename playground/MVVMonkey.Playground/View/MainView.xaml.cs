using Xamarin.Forms;

namespace MVVMonkey.Playground.View
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            var vm = new ViewModel.MainViewModel();

            this.BindingContext = vm;
            this.carouselView.ItemSelected += async (sender, e) =>
            {
                var parameter = new Core.Services.NavigationParameters("product", e.SelectedItem as Model.Product);
                await vm.NavigationService.GoAsync("DetailsProductView", parameter);
            };
        }
    }
}
