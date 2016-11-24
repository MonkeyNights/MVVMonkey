using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVVMonkey.Core.Services
{
    public class NavigationParameters : Dictionary<string, object>
    {
        public NavigationParameters() { }
        public NavigationParameters(string key, object value)
        {
            this.Add(key, value);
        }
        public NavigationParameters(string queryString)
        {
            var parameters = this.ParseQueryString(queryString);
            foreach (var parameter in parameters)
                this.Add(parameter.Key, parameter.Value);
        }

        public T GetValue<T>(string parameterName)
        {
            if (!this.ContainsKey(parameterName))
                return default(T);

            return (T)Convert.ChangeType(this[parameterName], typeof(T));
        }

        private Dictionary<string, string> ParseQueryString(string queryString)
        {
            return Regex.Matches(queryString, "([^?=&]+)(=([^&]*))?")
                        .Cast<Match>()
                        .ToDictionary(x => x.Groups[1].Value, x => x.Groups[3].Value);
        }
    }
}