using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1 : Form
{
    protected TextBox textBox1;
    
    // <Snippet1>
    private void GetCopyright()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the copyright notice.
        textBox1.Text = "Copyright notice: " + myFileVersionInfo.LegalCopyright;
    }
    // </Snippet1>
}
 