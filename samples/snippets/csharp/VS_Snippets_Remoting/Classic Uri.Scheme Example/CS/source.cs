using System;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
Uri baseUri = new Uri("http://www.contoso.com/");
 Uri myUri = new Uri(baseUri, "catalog/shownew.htm?date=today");
 
 Console.WriteLine(myUri.Scheme);
   
// </Snippet1>
 }
}
