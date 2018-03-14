using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1 : Form
{
    protected TextBox textBox1;

    // <Snippet1>
    private void GetIsSpecialBuild()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print whether the file is a special build.
        textBox1.Text = "File is a special build: " + myFileVersionInfo.IsSpecialBuild;
    }
    // </Snippet1>
}
