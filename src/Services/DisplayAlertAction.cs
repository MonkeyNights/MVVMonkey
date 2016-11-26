using System;

namespace MVVMonkey.Core.Services
{

    public class DisplayAlertAction
    {
        public string Title { get; }
        public Action Action { get; }

        public DisplayAlertAction(string title, Action action)
        {
            Title = title;
            Action = action;
        }

        public DisplayAlertAction(string title)
        {
            Title = title;
        }
    }
}
