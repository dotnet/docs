using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ca1010
{
    //<snippet1>
    public class Book
    {
        public Book()
        {
        }
    }

    public class BookCollection : CollectionBase
    {
        public BookCollection()
        {
        }

        public void Add(Book value)
        {
            InnerList.Add(value);
        }

        public void Remove(Book value)
        {
            InnerList.Remove(value);
        }

        public void Insert(int index, Book value)
        {
            InnerList.Insert(index, value);
        }

        public Book this[int index]
        {
            get { return (Book)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public bool Contains(Book value)
        {
            return InnerList.Contains(value);
        }

        public int IndexOf(Book value)
        {
            return InnerList.IndexOf(value);
        }

        public void CopyTo(Book[] array, int arrayIndex)
        {
            InnerList.CopyTo(array, arrayIndex);
        }
    }
    //</snippet1>
}

namespace ca1010_fix_1
{
    //<snippet2>  
    public class Book
    {
        public Book()
        {
        }
    }

    public class BookCollection : Collection<Book>
    {
        public BookCollection()
        {
        }
    }
    //</snippet2>
}

namespace ca1010_fix_2
{
    //<snippet3>
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
            get { return (Book)this.List[index]; }
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
    //</snippet3>
}
