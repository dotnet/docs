using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void GetFileMajorPart() {
    // Get the file version for the notepad.
    FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo("%systemroot%\\Notepad.exe");
 
    // Print the file major part number.
    textBox1.Text = "File major part number: " + myFileVersionInfo.FileMajorPart;
 }
    
// </Snippet1>
}
