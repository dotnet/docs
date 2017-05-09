using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int Loop1;
String[] StateVars = new String[Application.Count];
 
for (Loop1 = 0; Loop1 < Application.Count; Loop1++)
{
   StateVars[Loop1] = Application.GetKey(Loop1);
}   
// </Snippet1>
 }
}
