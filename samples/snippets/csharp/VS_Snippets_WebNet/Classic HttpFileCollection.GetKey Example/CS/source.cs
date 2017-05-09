using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int loop1;
 HttpFileCollection MyFileColl = Request.Files;
 
 for( loop1 = 0; loop1 < MyFileColl.Count; loop1++)
 {
    if( MyFileColl.GetKey(loop1) == "CustInfo")
    {
       //...
    }
 }
    
// </Snippet1>
 }
}
