using MVVMonkey.Core.Services;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Xamarin.Forms
{
    //based on https://marcominerva.wordpress.com/2016/07/11/a-simple-navigationservice-for-xamarin-forms/
    public static class NavigationExtensions
    {
        private static ConditionalWeakTable<Page, NavigationParameters> arguments = new ConditionalWeakTable<Page, NavigationParameters>();

        public static IDictionary<string, object> NavigationArgs(this Page page)
        {
            NavigationParameters parameters = null;
            arguments.TryGetValue(page, out parameters);
            return parameters;
        }

        public static void AddNavigationArgs(this Page page, NavigationParameters parameters)
        {
            arguments.Add(page, parameters);
        }
    }
}
