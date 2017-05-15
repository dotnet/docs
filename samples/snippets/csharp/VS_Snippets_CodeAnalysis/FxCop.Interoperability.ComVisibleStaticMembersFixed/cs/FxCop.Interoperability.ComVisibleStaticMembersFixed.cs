//<Snippet1>
using System;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

[assembly: ComVisible(false)]

namespace Samples
{
    [ComVisible(true)]
    public class Book
    {
        private Collection<string> _Pages = new Collection<string>();

        public Book()
        {
        }

        public Collection<string> Pages
        {
            get { return _Pages; }
        }

        [ComVisible(false)]
        public static Book FromPages(string[] pages)
        {
            if (pages == null)
                throw new ArgumentNullException("pages");

            Book book = new Book();

            foreach (string page in pages)
            {
                book.Pages.Add(page);
            }

            return book;
        }
    }
}
//</Snippet1>