using System.Threading.Tasks;

namespace MVVMonkey.Core.Services
{
    public interface IDisplayAlertService
    {
        Task DisplayActionSheetAsync(string title, DisplayAlertAction cancel, DisplayAlertAction destruction, params DisplayAlertAction[] buttons);
        Task DisplayAlertAsync(string title, string message, DisplayAlertAction cancel);
        Task DisplayAlertAsync(string title, string message, DisplayAlertAction accept, DisplayAlertAction cancel);
    }
}
