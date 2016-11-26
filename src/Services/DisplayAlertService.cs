using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMonkey.Core.Services
{
    public class DisplayAlertService : IDisplayAlertService
    {
        public Page CurrentPage
            => Application.Current.MainPage;


        public async Task DisplayActionSheetAsync(string title, DisplayAlertAction cancel, DisplayAlertAction destruction, params DisplayAlertAction[] buttons)
        {
            var result = await CurrentPage.DisplayActionSheet(title, cancel.Title, destruction?.Title, buttons.Select(b => b.Title).ToArray());
            if (result.Equals(cancel.Title))
                cancel?.Action?.Invoke();
            if (destruction != null && result.Equals(destruction.Title))
                destruction?.Action?.Invoke();
            else
            {
                var action = buttons.FirstOrDefault(b => b.Title.Equals(result));
                action?.Action?.Invoke();
            }
        }

        public async Task DisplayAlertAsync(string title, string message, DisplayAlertAction cancel)
        {
            await CurrentPage.DisplayAlert(title, message, cancel.Title);
            cancel?.Action?.Invoke();
        }

        public async Task DisplayAlertAsync(string title, string message, DisplayAlertAction accept, DisplayAlertAction cancel)
        {
            var result = await CurrentPage.DisplayAlert(title, message, accept.Title, cancel.Title);
            if (result.Equals(accept.Title))
                accept?.Action?.Invoke();
            if (result.Equals(cancel.Title))
                cancel?.Action?.Invoke();
        }
    }

}
