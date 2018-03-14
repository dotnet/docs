//<Snippet1>
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
//<Snippet2>
    private bool pDirty = false;

    public bool Dirty
    {
      get { return pDirty; }
      set { pDirty = value; }
    }
//</Snippet2>

//<Snippet3>
    public object this[int index]
    {
      get { return pItems[index]; }
      set
      {
        pItems[index] = value;
        pDirty = true;
      }
    }
//</Snippet3>

//<Snippet4>
    public object this[string name]
    {
      get { return pItems[name]; }
      set
      {
        pItems[name] = value;
        pDirty = true;
      }
    }
//</Snippet4>

//<Snippet5>
    public NameObjectCollectionBase.KeysCollection Keys
    {
      get { return (NameObjectCollectionBase.KeysCollection)pItems.Keys; }
    }
//</Snippet5>

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

//<Snippet6>
    public void Clear()
    {
      pItems.Clear();
      pDirty = true;
    }
//</Snippet6>

//<Snippet7>
    public void Remove(string name)
    {
      pItems.Remove(name);
      pDirty = true;
    }
//</Snippet7>

//<Snippet8>
    public void RemoveAt(int index)
    {
      if (index < 0 || index >= this.Count)
        throw new ArgumentOutOfRangeException("The specified index is not within the acceptable range.");

      pItems.RemoveAt(index);
      pDirty = true;
    }
//</Snippet8>

    public void CopyTo(Array array, int index)
    {
      pItems.CopyTo(array, index);
    }

  }

}
//</Snippet1>


