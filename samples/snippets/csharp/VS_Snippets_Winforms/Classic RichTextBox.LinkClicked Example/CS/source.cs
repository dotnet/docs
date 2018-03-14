
using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
   private RichTextBox richTextBox1 = new RichTextBox();

   public Form1()
   {
      richTextBox1.LinkClicked += new LinkClickedEventHandler(this.Link_Clicked);

      richTextBox1.SelectedText = "To see Microsoft go to www.microsoft.com";
      richTextBox1.Location = new System.Drawing.Point (10,10);
      richTextBox1.Size = new System.Drawing.Size(100,100);

      this.Controls.Add(richTextBox1);
   }
   // <Snippet1>
   private void Link_Clicked (object sender, System.Windows.Forms.LinkClickedEventArgs e)
   {
      System.Diagnostics.Process.Start(e.LinkText);
   }
   // </Snippet1>

   
   /// <summary>
   /// The main entry point for the application.
   /// </summary>
   [STAThread]
   static void Main() 
   {
      Application.Run(new Form1());
   }

}

