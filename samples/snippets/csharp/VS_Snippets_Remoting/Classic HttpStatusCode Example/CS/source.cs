using System;
using System.Net;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
 HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
 httpReq.AllowAutoRedirect = false;
 
 HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
 
 if (httpRes.StatusCode==HttpStatusCode.Moved) 
 {
    // Code for moved resources goes here.
 }

 // Close the response.
 httpRes.Close();
   
// </Snippet1>
 }
}
