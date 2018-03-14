using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
    protected TextBox textBox1;
    
    // <Snippet1>
    private void GetIsPatched()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print whether the file has a patch installed.
        textBox1.Text = "File has patch installed: " + myFileVersionInfo.IsPatched;
    }
    // </Snippet1>
}
