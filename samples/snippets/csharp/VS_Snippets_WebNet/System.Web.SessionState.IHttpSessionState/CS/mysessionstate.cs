//<Snippet1>
using System;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Samples.AspNet.SessionState
{
  public sealed class MySessionState : IHttpSessionState
  {
    const int MAX_TIMEOUT = 24 * 60;  // Timeout cannot exceed 24 hours.

    string                      pId;
    ISessionStateItemCollection pSessionItems;
    HttpStaticObjectsCollection pStaticObjects;
    int                         pTimeout;
    bool                        pNewSession;
    HttpCookieMode              pCookieMode;
    SessionStateMode            pMode;
    bool                        pAbandon;
    bool                        pIsReadonly;

    public MySessionState(string                      id, 
                          ISessionStateItemCollection sessionItems,
                          HttpStaticObjectsCollection staticObjects,
                          int                         timeout,
                          bool                        newSession,
                          HttpCookieMode              cookieMode,
                          SessionStateMode            mode,
                          bool                        isReadonly)
    {
      pId            = id;   
      pSessionItems  = sessionItems;
      pStaticObjects = staticObjects;
      pTimeout       = timeout;    
      pNewSession    = newSession; 
      pCookieMode    = cookieMode;
      pMode          = mode;
      pIsReadonly    = isReadonly;
    }


    //<Snippet2>
    public int Timeout
    {
      get { return pTimeout; }
      set
      {
        if (value <= 0)
          throw new ArgumentException("Timeout value must be greater than zero.");

        if (value > MAX_TIMEOUT)
          throw new ArgumentException("Timout cannot be greater than " + MAX_TIMEOUT.ToString());

        pTimeout = value;
      }
    }
    //</Snippet2>


    //<Snippet3>
    public string SessionID
    {
      get { return pId; }
    }
    //</Snippet3>


    //<Snippet4>
    public bool IsNewSession
    {
      get { return pNewSession; }
    }
    //</Snippet4>


    //<Snippet5>
    public SessionStateMode Mode
    {
      get { return pMode; }
    }
    //</Snippet5>


    //<Snippet6>
    public bool IsCookieless
    {
      get { return CookieMode == HttpCookieMode.UseUri; }
    }
    //</Snippet6>


    //<Snippet7>
    public HttpCookieMode CookieMode
    {
      get { return pCookieMode; }
    }
    //</Snippet7>


    //<Snippet8>
    //
    // Abandon marks the session as abandoned. The IsAbandoned property is used by the
    // session state module to perform the abandon work during the ReleaseRequestState event.
    //
    public void Abandon()
    {
      pAbandon = true;
    }

    public bool IsAbandoned
    {
      get { return pAbandon; }
    }
    //</Snippet8>

    //<Snippet9>
    //
    // Session.LCID exists only to support legacy ASP compatibility. ASP.NET developers should use
    // Page.LCID instead.
    //
    public int LCID
    {
      get { return Thread.CurrentThread.CurrentCulture.LCID; }
      set { Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(new CultureInfo(value)); }
    }
    //</Snippet9>


    //<Snippet10>
    //
    // Session.CodePage exists only to support legacy ASP compatibility. ASP.NET developers should use
    // Response.ContentEncoding instead.
    //
    public int CodePage
    {
      get
      { 
        if (HttpContext.Current != null)
          return HttpContext.Current.Response.ContentEncoding.CodePage;
        else
          return Encoding.Default.CodePage;
      }
      set
      { 
        if (HttpContext.Current != null)
          HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding(value);
      }
    }
    //</Snippet10>


    //<Snippet12>
    public HttpStaticObjectsCollection StaticObjects
    {
      get { return pStaticObjects; }
    }
    //</Snippet12>


    //<Snippet13>
    public object this[string name]
    {
      get { return pSessionItems[name]; }
      set { pSessionItems[name] = value; }
    }
    //</Snippet13>


    //<Snippet14>
    public object this[int index]
    {
      get { return pSessionItems[index]; }
      set { pSessionItems[index] = value; }
    }
    //</Snippet14>
        

    //<Snippet15>
    public void Add(string name, object value)
    {
      pSessionItems[name] = value;        
    }
    //</Snippet15>


    //<Snippet16>
    public void Remove(string name)
    {
      pSessionItems.Remove(name);
    }
    //</Snippet16>


    //<Snippet17>
    public void RemoveAt(int index)
    {
      pSessionItems.RemoveAt(index);
    }
    //</Snippet17>


    //<Snippet18>
    public void Clear()
    {
      pSessionItems.Clear();
    }

    public void RemoveAll()
    {
        Clear();
    }
    //</Snippet18>



    //<Snippet19>
    public int Count
    {
      get { return pSessionItems.Count; }
    }
    //</Snippet19>



    //<Snippet20>
    public NameObjectCollectionBase.KeysCollection Keys
    {
      get { return pSessionItems.Keys; }
    }
    //</Snippet20>


    //<Snippet21>
    public IEnumerator GetEnumerator()
    {
      return pSessionItems.GetEnumerator();
    }
    //</Snippet21>


    //<Snippet22>
    public void CopyTo(Array items, int index)
    {
      foreach (object o in items)
        items.SetValue(o, index++);
    }
    //</Snippet22>


    //<Snippet23>
    public object SyncRoot
    {
        get { return this; }
    }
    //</Snippet23>


    //<Snippet24>
    public bool IsReadOnly
    {
      get { return pIsReadonly; }
    }
    //</Snippet24>


    //<Snippet25>
    public bool IsSynchronized
    {
      get { return false; }
    }
    //</Snippet25>
  }
}
//</Snippet1>