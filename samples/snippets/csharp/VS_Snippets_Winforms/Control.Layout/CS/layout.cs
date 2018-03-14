using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class MyForm : System.Windows.Forms.Form
{
   private System.Windows.Forms.Button button1;
   private System.ComponentModel.Container components = null;

   public MyForm()
   {
      InitializeComponent();
   }

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

   private void InitializeComponent()
   {
      this.button1 = new System.Windows.Forms.Button();
	  this.SuspendLayout();
	  // 
	  // button1
	  // 
	  this.button1.Location = new System.Drawing.Point(48, 56);
	  this.button1.Name = "button1";
	  this.button1.TabIndex = 0;
	  this.button1.Text = "button1";
	  // 
	  // Form1
	  // 
	  this.ClientSize = new System.Drawing.Size(292, 273);
	  this.Controls.AddRange(new System.Windows.Forms.Control[] {this.button1});
      this.Name = "MyForm";
	  this.Text = "MyForm";
	  this.Layout += new System.Windows.Forms.LayoutEventHandler(this.MyForm_Layout);
	  this.ResumeLayout(false);
   }

   [STAThread]
   static void Main() 
   {
      Application.Run(new MyForm());
   }

   // <snippet1>
   private void MyForm_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
   {
      // Center the Form on the user's screen everytime it requires a Layout.
      this.SetBounds((Screen.GetBounds(this).Width/2) - (this.Width/2),
          (Screen.GetBounds(this).Height/2) - (this.Height/2),
		  this.Width, this.Height, BoundsSpecified.Location);	
   }
   // </snippet1>
}
