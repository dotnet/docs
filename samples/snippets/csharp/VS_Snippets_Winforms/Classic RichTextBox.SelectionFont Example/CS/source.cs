using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CSExample
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.RichTextBox richTextBox1;
      private System.Windows.Forms.Button button1;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public Form1()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(8, 8);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(256, 24);
         this.richTextBox1.TabIndex = 0;
         this.richTextBox1.Text = "Make me BOLD";
         this.richTextBox1.Enter += new System.EventHandler(this.richTextBox1_Enter);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(8, 40);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(72, 32);
         this.button1.TabIndex = 1;
         this.button1.Text = "Bold";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 117);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.button1,
            this.richTextBox1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }

      private void button1_Click(object sender, System.EventArgs e)
      {
         this.ToggleBold();
      }

      // <Snippet1>
      private void ToggleBold()
      {
         if (richTextBox1.SelectionFont != null)
         {
            System.Drawing.Font currentFont = richTextBox1.SelectionFont;
            System.Drawing.FontStyle newFontStyle;

            if (richTextBox1.SelectionFont.Bold == true)
            {
               newFontStyle = FontStyle.Regular;
            }
            else
            {
               newFontStyle = FontStyle.Bold;
            }

            richTextBox1.SelectionFont = new Font(
               currentFont.FontFamily, 
               currentFont.Size, 
               newFontStyle
            );
         }
      }
      // </Snippet1>

      private void richTextBox1_Enter(object sender, System.EventArgs e)
      {
         richTextBox1.SelectionStart = 8;
         richTextBox1.SelectionLength = 4;
      }
   }
}
