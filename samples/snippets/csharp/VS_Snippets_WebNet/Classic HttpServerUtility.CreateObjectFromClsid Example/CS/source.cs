using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
String ClsidStr;
Object MyObject;

ClsidStr = "42754580-16b7-11ce-80eb-00aa003d7352";
MyObject = Server.CreateObject(ClsidStr);
   
// </Snippet1>
 }
}
