using System;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
// <Snippet1>
 WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
 String username = wp.Identity.Name;
 
// </Snippet1>

 }
}
