// <snippet2>
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Samples.AspNet.CS.Controls
{
  public class MyManagerAuthorize : WebPartManager
  {
    public override bool IsAuthorized(Type type, string path, string authorizationFilter, bool isShared)
    {
      if (!String.IsNullOrEmpty(authorizationFilter))
      {
        if (authorizationFilter == "admin")
          return true;
        else
          return false;
      }
      else
        return true;

    }
  }
}
// </snippet2>