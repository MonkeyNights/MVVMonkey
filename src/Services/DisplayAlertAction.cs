using System;

namespace MVVMonkey.Core.Services
{

    public class DisplayAlertAction
    {
        public string Title { get; }
        public Action Action { get; }

        public DisplayAlertAction(string title, Action action)
        {
            this.Title = title;
            this.Action = action;
        }

        public DisplayAlertAction(string title)
        {
            this.Title = title;
        }
    }
}
