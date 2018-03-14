//<SNIPPET1>
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedDOMStyles
{
    public class StyleGenerator
    {
        private Dictionary<string, string> styleDB;

        public StyleGenerator()
        {
            styleDB = new Dictionary<string, string>();
        }

        public bool ContainsStyle(string name)
        {
            return(styleDB.ContainsKey(name));
        }

        public string SetStyle(string name, string value)
        {
            string oldValue = "";

            if (!(name.Length > 0))
            {
                throw (new ArgumentException("Parameter name cannot be zero-length."));
            }
            if (!(value.Length > 0))
            {
                throw (new ArgumentException("Parameter value cannot be zero-length."));
            }

            if (styleDB.ContainsKey(name))
            {
                oldValue = styleDB[name];
            }

            styleDB[name] = value;

            return (oldValue);
        }

        public string GetStyle(string name)
        {
            if (!(name.Length > 0))
            {
                throw (new ArgumentException("Parameter name cannot be zero-length."));
            }

            if (styleDB.ContainsKey(name))
            {
                return (styleDB[name]);
            }
            else
            {
                return ("");
            }
        }

        public void RemoveStyle(string name)
        {
            if (styleDB.ContainsKey(name))
            {
                styleDB.Remove(name);
            }
        }

        public string GetStyleString()
        {
            if (styleDB.Count > 0)
            {
                StringBuilder styleString = new StringBuilder("");
                foreach (string key in styleDB.Keys)
                {
                    styleString.Append(String.Format("{0}:{1};", (object)key, (object)styleDB[key]));
                }

                return (styleString.ToString());
            }
            else
            {
                return ("");
            }
        }

        public void ParseStyleString(string styles)
        {
            if (styles.Length > 0)
            {
                string[] stylePairs = styles.Split(new char[] { ';' });
                foreach(string stylePair in stylePairs)
                {
                    if (stylePairs.Length > 0)
                    {
                        string[] styleNameValue = stylePair.Split(new char[] { ':' });
                        if (styleNameValue.Length == 2)
                        {
                            styleDB[styleNameValue[0]] = styleNameValue[1];
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            styleDB.Clear();
        }
    }
}
//</SNIPPET1>