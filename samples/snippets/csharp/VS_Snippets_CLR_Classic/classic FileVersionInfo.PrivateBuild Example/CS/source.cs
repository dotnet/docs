using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
    protected TextBox textBox1;
    
    // <Snippet1>
    private void GetPrivateBuild()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the private build number.
        textBox1.Text = "Private build number: " + myFileVersionInfo.PrivateBuild;
    }
    // </Snippet1>
}
 