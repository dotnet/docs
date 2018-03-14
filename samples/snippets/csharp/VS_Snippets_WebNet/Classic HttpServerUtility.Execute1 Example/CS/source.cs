using System;
using System.IO;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
StringWriter writer = new StringWriter();
Server.Execute("Login.aspx", writer);
Response.Write("<H3>Please Login:</H3><br>"+ writer.ToString());
   
// </Snippet1>
 }
}
