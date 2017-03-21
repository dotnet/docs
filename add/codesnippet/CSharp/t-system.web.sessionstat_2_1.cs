using System;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using System.Collections.Specialized;


namespace Samples.AspNet.Session
{

  public class MySessionStateItemCollection : ISessionStateItemCollection
  {
    private SortedList pItems = new SortedList();
    private bool pDirty = false;

    public bool Dirty
    {
      get { return pDirty; }
      set { pDirty = value; }
    }

    public object this[int index]
    {
      get { return pItems[index]; }
      set
      {
        pItems[index] = value;
        pDirty = true;
      }
    }

    public object this[string name]
    {
      get { return pItems[name]; }
      set
      {
        pItems[name] = value;
        pDirty = true;
      }
    }

    public NameObjectCollectionBase.KeysCollection Keys
    {
      get { return (NameObjectCollectionBase.KeysCollection)pItems.Keys; }
    }

    public int Count
    {
      get { return pItems.Count; }
    }

    public Object SyncRoot
    {
      get { return this; }
    }

    public bool IsSynchronized
    {
      get { return false; }
    }

    public IEnumerator GetEnumerator()
    {
      return pItems.GetEnumerator(); 
    }

    public void Clear()
    {
      pItems.Clear();
      pDirty = true;
    }

    public void Remove(string name)
    {
      pItems.Remove(name);
      pDirty = true;
    }

    public void RemoveAt(int index)
    {
      if (index < 0 || index >= this.Count)
        throw new ArgumentOutOfRangeException("The specified index is not within the acceptable range.");

      pItems.RemoveAt(index);
      pDirty = true;
    }

    public void CopyTo(Array array, int index)
    {
      pItems.CopyTo(array, index);
    }

  }

}