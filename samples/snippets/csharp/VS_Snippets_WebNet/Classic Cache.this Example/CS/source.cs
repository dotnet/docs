using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Page1: Page
{
    protected HtmlGenericControl divCacheContents;
    protected TextBox txtName;
    protected TextBox txtValue;
// <Snippet1>
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
void ShowCachedItems()
{
    // Declare variables.
    string strCacheContents;
    string strName;

    // Display all the items stored in the ASP.NET cache.
    strCacheContents = "<b>The ASP.NET application cache contains:</b><br/>";
    foreach(DictionaryEntry objItem in Cache)
    {
        strName = objItem.Key.ToString();
        if(strName.Substring(0, 7) != "System.")
        {
            strCacheContents = strName + " + " + Cache[strName].ToString() + "<br/>";
	    Response.Write(strCacheContents);
        }
    }
   divCacheContents.InnerHtml = strCacheContents;
}
// </Snippet1>
// <Snippet2>
private void cmdAdd_Click(Object objSender, EventArgs objArgs)
{
    if (txtName.Text != "")
    {
        // Add this item to the cache.
        Cache[txtName.Text] = txtValue.Text;
    }
}
        
// </Snippet2>
}
