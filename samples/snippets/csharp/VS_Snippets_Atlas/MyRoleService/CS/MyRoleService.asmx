<%-- <Snippet1> --%>
<%@ WebService Language="C#" Class="MyRoleService" %>

using System.Web.Services;
using System.Web.Script.Services;

[ScriptService]
public class MyRoleService  : System.Web.Services.WebService 
{
    [WebMethod]
    public string[] GetRolesForCurrentUser()
    {
        //Place code here.
        return null;
    }

    [WebMethod]
    public bool IsCurrentUserInRole(string role) 
    {
        //Place code here.
      return false;
    }  
}
// </Snippet1>