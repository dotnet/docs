using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int indx;
 
 String[] arr = Request.AcceptTypes;    
 for (indx = 0; indx < arr.Length; indx++) {
    Response.Write("Accept Type " + indx +": " + arr[indx] + "<br>");
 }
   
// </Snippet1>
 }
}
