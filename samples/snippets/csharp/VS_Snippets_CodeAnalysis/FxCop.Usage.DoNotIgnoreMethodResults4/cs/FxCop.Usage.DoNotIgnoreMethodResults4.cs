//<Snippet1>
using System;

namespace Samples
{
    public class Book
    {
        private readonly string _Title;

        public Book(string title)
        {
            if (title != null)
            {
                title = title.Trim();
            }

            _Title = title;
        }

        public string Title
        {
            get { return _Title; }
        }
    }
}
//</Snippet1>