//<Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;

namespace Samples
{
    public class Book
    {
        public Book()
        {
        }
    }

    public class BookCollection : CollectionBase, IList<Book>
    {
        public BookCollection()
        {
        }

        int IList<Book>.IndexOf(Book item)
        {
            return this.List.IndexOf(item);
        }

        void IList<Book>.Insert(int location, Book item)
        {
        }

        Book IList<Book>.this[int index]
        {
            get { return (Book) this.List[index]; }
            set { }
        }

        void ICollection<Book>.Add(Book item)
        {
        }

        bool ICollection<Book>.Contains(Book item)
        {
            return true;
        }

        void ICollection<Book>.CopyTo(Book[] array, int arrayIndex)
        {
        }

        bool ICollection<Book>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<Book>.Remove(Book item)
        {
            if (InnerList.Contains(item))
            {
                InnerList.Remove(item);
                return true;
            }
            return false;
        }

        IEnumerator<Book> IEnumerable<Book>.GetEnumerator()
        {
            return new BookCollectionEnumerator(InnerList.GetEnumerator());
        }

        private class BookCollectionEnumerator : IEnumerator<Book>
        {
            private IEnumerator _Enumerator;

            public BookCollectionEnumerator(IEnumerator enumerator)
            {
                _Enumerator = enumerator;
            }

            public Book Current
            {
                get { return (Book)_Enumerator.Current; }
            }

            object IEnumerator.Current
            {
                get { return _Enumerator.Current; }
            }

            public bool MoveNext()
            {
                return _Enumerator.MoveNext();
            }

            public void Reset()
            {
                _Enumerator.Reset();
            }

            public void Dispose()
            {
            }
        }
    }
}
//</Snippet1>
