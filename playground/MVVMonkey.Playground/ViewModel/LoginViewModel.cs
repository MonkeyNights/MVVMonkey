using MVVMonkey.Core.Services;
using MVVMonkey.Core.ViewModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMonkey.Playground.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { this.SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { this.SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; }
        public ICommand ForgotMyPasswordCommand { get; }

        public LoginViewModel()
        {
            this.LoginCommand = new ViewModelCommand(this, () => {
                this.NavigationService.Start<MainViewModel>(new NavigationParameters($"username={this.Username}"));
            });

            this.ForgotMyPasswordCommand = new Command(() =>
            {
                this.NavigationService.ShowPopupAsync<ForgotMyPasswordViewModel>();
            });
        }
    }
}
