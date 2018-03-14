using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Routing;

/// <summary>
/// Summary description for ReportRouteHandler
/// </summary>
public class ReportRouteHandler : System.Web.Routing.IRouteHandler
{
    public ReportRouteHandler()
    {

    }

    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        return null;
    }
}
