using MVVMonkey.Core.ViewModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMonkey.Playground.ViewModel
{
    public class ForgotMyPasswordViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; set; }

        public ForgotMyPasswordViewModel()
        {
            CloseCommand = new Command(async () => {
                await this.NavigationService.GoBackAsync();
            });
        }
    }
}