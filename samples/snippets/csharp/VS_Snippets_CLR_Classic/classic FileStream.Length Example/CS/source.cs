using System;
using System.IO;
using System.Windows.Forms;


public class Form1: Form
{
 protected void Method(FileStream s)
 {
// <Snippet1>
 if( s.Length==s.Position )
 {
    Console.WriteLine("End of file has been reached.");
 }
// </Snippet1>

 } 
}
