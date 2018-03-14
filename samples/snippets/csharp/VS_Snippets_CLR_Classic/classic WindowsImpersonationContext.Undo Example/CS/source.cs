using System;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method(IntPtr userToken)
 {
// <Snippet1>
WindowsImpersonationContext ImpersonationCtx = WindowsIdentity.Impersonate(userToken); 
//Do something under the context of the impersonated user.
 ImpersonationCtx.Undo();

// </Snippet1>

 }
}
