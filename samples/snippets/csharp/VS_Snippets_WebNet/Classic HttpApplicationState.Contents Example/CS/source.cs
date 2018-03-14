using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>

HttpApplicationState AppState2;
 
AppState2 = Application.Contents;
 
String[] StateVars = new String[AppState2.Count];
StateVars = AppState2.AllKeys;

// </Snippet1>
 }
}
