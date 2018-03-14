using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
  int Num = 0;
// <Snippet1>
if (Num == 0)
{
   throw new HttpException("No value entered");
}
   
// </Snippet1>
 }
}
