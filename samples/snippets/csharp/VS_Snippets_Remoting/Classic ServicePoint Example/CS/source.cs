using System;
using System.Net;
using System.IO;
using System.Windows.Forms;

public class Form1: Form
{
 public void Method()
 {
// <Snippet1>
Uri myUri = new Uri("http://www.contoso.com/");
 
 ServicePoint mySP = ServicePointManager.FindServicePoint(myUri);
   
// </Snippet1>
 }
}
