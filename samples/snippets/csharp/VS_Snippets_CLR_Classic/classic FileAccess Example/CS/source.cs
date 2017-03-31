using System;
using System.IO;
using System.Windows.Forms;


public class Form1: Form
{
 protected void Method(string name)
 {
// <Snippet1>
FileStream s2 = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read);
// </Snippet1>

 } 
}
