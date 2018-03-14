using System;
using System.Reflection;
using System.Windows.Forms;
using System.Security.Policy;


public class Form1: Form
{
 protected Assembly myAssembly;

 protected void Method()
 {
// <Snippet1>
 Hash hash = new Hash ( myAssembly );
 Byte[] hashcode = hash.MD5;
// </Snippet1>

 } 
}
