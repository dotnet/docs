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


    public string SessionID
    {
      get { return pId; }
    }


    public bool IsNewSession
    {
      get { return pNewSession; }
    }


    public SessionStateMode Mode
    {
      get { return pMode; }
    }


    public bool IsCookieless
    {
      get { return CookieMode == HttpCookieMode.UseUri; }
    }


    public HttpCookieMode CookieMode
    {
      get { return pCookieMode; }
    }


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

    //
    // Session.LCID exists only to support legacy ASP compatibility. ASP.NET developers should use
    // Page.LCID instead.
    //
    public int LCID
    {
      get { return Thread.CurrentThread.CurrentCulture.LCID; }
      set { Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(new CultureInfo(value)); }
    }


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


    public HttpStaticObjectsCollection StaticObjects
    {
      get { return pStaticObjects; }
    }


    public object this[string name]
    {
      get { return pSessionItems[name]; }
      set { pSessionItems[name] = value; }
    }


    public object this[int index]
    {
      get { return pSessionItems[index]; }
      set { pSessionItems[index] = value; }
    }
        

    public void Add(string name, object value)
    {
      pSessionItems[name] = value;        
    }


    public void Remove(string name)
    {
      pSessionItems.Remove(name);
    }


    public void RemoveAt(int index)
    {
      pSessionItems.RemoveAt(index);
    }


    public void Clear()
    {
      pSessionItems.Clear();
    }

    public void RemoveAll()
    {
        Clear();
    }



    public int Count
    {
      get { return pSessionItems.Count; }
    }



    public NameObjectCollectionBase.KeysCollection Keys
    {
      get { return pSessionItems.Keys; }
    }


    public IEnumerator GetEnumerator()
    {
      return pSessionItems.GetEnumerator();
    }


    public void CopyTo(Array items, int index)
    {
      foreach (object o in items)
        items.SetValue(o, index++);
    }


    public object SyncRoot
    {
        get { return this; }
    }


    public bool IsReadOnly
    {
      get { return pIsReadonly; }
    }


    public bool IsSynchronized
    {
      get { return false; }
    }
  }
}