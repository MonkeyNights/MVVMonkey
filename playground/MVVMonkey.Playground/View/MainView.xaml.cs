using Xamarin.Forms;

namespace MVVMonkey.Playground.View
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            var vm = new ViewModel.MainViewModel();

            BindingContext = vm;
            //this.carouselView.PositionSelected += async (sender, e) =>
            //{
            //    var parameter = new Core.Services.NavigationParameters("product", e.SelectedPosition as Model.Product);
            //    await vm.NavigationService.GoAsync("DetailsProductView", parameter);
            //};
        }
    }
}
