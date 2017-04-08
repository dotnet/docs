using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected RichTextBox richTextBox1;
// <Snippet1>
public void LoadMyFile()
{
   // Create an OpenFileDialog to request a file to open.
   OpenFileDialog openFile1 = new OpenFileDialog();

   // Initialize the OpenFileDialog to look for RTF files.
   openFile1.DefaultExt = "*.rtf";
   openFile1.Filter = "RTF Files|*.rtf";

   // Determine whether the user selected a file from the OpenFileDialog.
   if(openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
      openFile1.FileName.Length > 0) 
   {
      // Load the contents of the file into the RichTextBox.
      richTextBox1.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
   }
}

// </Snippet1>
}
