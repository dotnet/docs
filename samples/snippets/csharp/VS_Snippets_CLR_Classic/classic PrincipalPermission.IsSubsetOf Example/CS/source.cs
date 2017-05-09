using System;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 
 public void Method()
 {
// <Snippet1>
//Define users and roles.
PrincipalPermission ppBob = new PrincipalPermission("Bob", "Manager");
PrincipalPermission ppLouise = new PrincipalPermission("Louise", "Supervisor");
PrincipalPermission ppGreg = new PrincipalPermission("Greg", "Employee");

//Define groups of users.
PrincipalPermission pp1 = (PrincipalPermission)ppBob.Union(ppLouise);
PrincipalPermission pp2 = (PrincipalPermission)ppGreg.Union(pp1);
// </Snippet1>

 }
}
