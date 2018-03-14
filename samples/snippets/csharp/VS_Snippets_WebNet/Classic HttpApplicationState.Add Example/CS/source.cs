using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 protected Object MyObject1;
 protected Object MyObject2;
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
Application.Add("MyAppVar1", MyObject1);
Application.Add("MyAppVar2", MyObject2);  
// </Snippet1>
 }
}
