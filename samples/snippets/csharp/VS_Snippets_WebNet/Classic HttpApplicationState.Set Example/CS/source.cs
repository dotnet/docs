using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 protected Object MyNewObjectValue;

 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
Application.Set("MyAppVar1", MyNewObjectValue);
   
// </Snippet1>
 }
}
