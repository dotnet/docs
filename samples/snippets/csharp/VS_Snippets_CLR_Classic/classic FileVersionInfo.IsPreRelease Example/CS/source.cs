using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
     protected TextBox textBox1;

     // <Snippet1>
     private void GetIsPreRelease()
     {
         // Get the file version for the notepad.
         FileVersionInfo myFileVersionInfo =
             FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

         // Print whether the file is a prerelease version.
         textBox1.Text = "File is prerelease version " + myFileVersionInfo.IsPreRelease;
    }
    // </Snippet1>
}
