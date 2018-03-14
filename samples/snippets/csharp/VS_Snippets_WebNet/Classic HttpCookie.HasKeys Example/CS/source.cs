using System;
using System.Web;
using System.Web.UI;

using System.Collections.Specialized;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpCookieCollection MyCookieCollection = Request.Cookies;
 for(int loop1 = 0; loop1 < MyCookieCollection.Count; loop1++)
 {
    HttpCookie MyCookie = MyCookieCollection[loop1];

    if ( MyCookie.HasKeys )
    {
      NameValueCollection MyCookieValues =
          new NameValueCollection(MyCookie.Values);
      String[] MyKeyNames = MyCookieValues.AllKeys;
      foreach(string KeyName in MyKeyNames)
          {
              String[] MyValues = 
                  MyCookieValues.GetValues(KeyName);
          }
    }
 }

// </Snippet1>
 }
}
