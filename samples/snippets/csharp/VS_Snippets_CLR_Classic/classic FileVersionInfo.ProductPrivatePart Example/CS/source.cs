using System;
using System.Windows.Forms;
using System.Diagnostics;

public class Form1 : Form
{
    protected TextBox textBox1;
    
    // <Snippet1>
    private void GetProductPrivatePart()
    {
        // Get the file version for the notepad.
        FileVersionInfo myFileVersionInfo =
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\Notepad.exe");

        // Print the product private part number.
        textBox1.Text = "Product private part number: " + myFileVersionInfo.ProductPrivatePart;
    }
    // </Snippet1>
}
    