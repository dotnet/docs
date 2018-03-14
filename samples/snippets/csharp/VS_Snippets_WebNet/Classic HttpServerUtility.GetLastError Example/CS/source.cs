using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
Exception LastError;
String ErrMessage;
 
LastError = Server.GetLastError();

if (LastError != null)
   ErrMessage = LastError.Message;
else
   ErrMessage = "No Errors";

Response.Write("Last Error = " + ErrMessage);
   
// </Snippet1>
 }
}
