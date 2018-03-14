using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
    protected TextBox textBox1;

    // <Snippet1>
    private void GetIsDebug()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print whether the file contains debugging information.
        textBox1.Text = "File contains debugging information: " +
            myFileVersionInfo.IsDebug;
    }
    // </Snippet1>
}
