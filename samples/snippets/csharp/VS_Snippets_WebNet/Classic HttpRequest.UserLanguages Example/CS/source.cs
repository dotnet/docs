using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int count;
String[] userLang = Request.UserLanguages;    
 
for (count = 0; count < userLang.Length; count++) 
{
   Response.Write("User Language " + count +": " + userLang[count] + "<br>");
}
   
// </Snippet1>
 }
}
