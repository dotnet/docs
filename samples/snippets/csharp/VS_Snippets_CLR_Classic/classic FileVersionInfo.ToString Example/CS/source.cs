using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
    protected TextBox textBox1;

    // <Snippet1>
    private void GetFileVersion2()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print all the version information.
        textBox1.Text = myFileVersionInfo.ToString();
    }
    // </Snippet1>
}
 