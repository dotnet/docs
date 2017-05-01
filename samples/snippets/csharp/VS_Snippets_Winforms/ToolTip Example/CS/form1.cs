using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ToolTipExample
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Button button1;
      /// <summary>
      /// Required designer variable.
      /// </summary>
		
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

		#region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.button1 = new System.Windows.Forms.Button();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(200, 20);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(84, 24);
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         // 
         // checkBox1
         // 
         this.checkBox1.Location = new System.Drawing.Point(204, 60);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.TabIndex = 0;
         this.checkBox1.Text = "checkBox1";
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.checkBox1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
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

      //<snippet1>
      // This example assumes that the Form_Load event handling method
      // is connected to the Load event of the form.
      private void Form1_Load(object sender, System.EventArgs e)
      {
         // Create the ToolTip and associate with the Form container.
         ToolTip toolTip1 = new ToolTip();

         // Set up the delays for the ToolTip.
         toolTip1.AutoPopDelay = 5000;
         toolTip1.InitialDelay = 1000;
         toolTip1.ReshowDelay = 500;
         // Force the ToolTip text to be displayed whether or not the form is active.
         toolTip1.ShowAlways = true;
			
         // Set up the ToolTip text for the Button and Checkbox.
         toolTip1.SetToolTip(this.button1, "My button1");
         toolTip1.SetToolTip(this.checkBox1, "My checkBox1");
      }
      //</snippet1>
   }
}
