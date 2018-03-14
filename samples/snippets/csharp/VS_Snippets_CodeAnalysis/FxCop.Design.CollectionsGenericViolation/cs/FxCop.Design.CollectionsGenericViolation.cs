//<Snippet1>
using System;
using System.Collections;

namespace Samples
{
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
}
//</Snippet1>
