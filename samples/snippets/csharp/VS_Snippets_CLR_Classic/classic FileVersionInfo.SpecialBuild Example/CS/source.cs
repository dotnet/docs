using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1: Form
{
    protected TextBox textBox1;
    
    // <Snippet1>
    private void GetSpecialBuild()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the special build information.
        textBox1.Text = "Special build information: " + myFileVersionInfo.SpecialBuild;
    }
    // </Snippet1>
}
 