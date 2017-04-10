using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
private void Page_Load(Object sender, EventArgs e)
{
// <Snippet1>
Application.Lock();
Application["MyCode"] = 21;
Application["MyCount"] = Convert.ToInt32(Application["MyCount"]) + 1;
Application.UnLock();

// </Snippet1>
}
}
