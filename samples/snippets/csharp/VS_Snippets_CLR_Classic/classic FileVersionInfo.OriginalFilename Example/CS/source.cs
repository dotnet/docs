using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
    protected TextBox textBox1;

    // <Snippet1>
    private void GetOriginalName()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the original file name.
        textBox1.Text = "Original file name: " + myFileVersionInfo.OriginalFilename;
    }
    // </Snippet1>
}
 