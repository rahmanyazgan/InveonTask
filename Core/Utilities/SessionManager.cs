using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

namespace Core.Utilities
{
    public partial class SessionManager
    {
        protected HttpSessionState SessionState
        {
            get { return HttpContext.Current.Session; }
        }

        public T Get<T>(string key)
        {
            if (SessionState == null)
            {
                return default(T);
            }
            return (T)SessionState[key];
        }

        public void Set(string key, object data)
        {
            if (SessionState == null)
            {
                return;
            }
            SessionState[key] = data;
        }

        public bool IsSet(string key)
        {
            if (SessionState == null)
            {
                return false;
            }
            return (SessionState[key] != null);
        }

        public void Remove(string key)
        {
            if (SessionState == null)
            {
                return;
            }
            SessionState.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            if (SessionState == null)
            {
                return;
            }

            var enumerator = SessionState.Keys.GetEnumerator();
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(enumerator.Current.ToString()))
                {
                    keysToRemove.Add(enumerator.Current.ToString());
                }
            }

            foreach (string key in keysToRemove)
            {
                SessionState.Remove(key);
            }
        }

        public void Clear()
        {
            if (SessionState == null)
            {
                return;
            }
            SessionState.Clear();
        }
    }
}
