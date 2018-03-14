using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ScrollableControl
{
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button button1;
      private System.ComponentModel.Container components = null;

      public Form1()
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

		#region Windows Form Designer generated code

      private void InitializeComponent()
      {
         this.panel1 = new System.Windows.Forms.Panel();
         this.button1 = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.AutoScroll = true;
         this.panel1.AutoScrollMargin = new System.Drawing.Size(5, 5);
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.button1});
         this.panel1.DockPadding.All = 10;
         this.panel1.Location = new System.Drawing.Point(40, 64);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(272, 104);
         this.panel1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(416, 184);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(104, 40);
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(336, 205);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.panel1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }
		#endregion

      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }

// <snippet1>
private void button1_Click(object sender, EventArgs e)
{
   /* Add a button to top left corner of the 
    * scrollable area, allowing for the offset. */
   panel1.AutoScroll = true;
   Button myButton = new Button();
   myButton.Location = new Point(
      0 + panel1.AutoScrollPosition.X, 
      0 + panel1.AutoScrollPosition.Y);
   panel1.Controls.Add(myButton);
}
// </snippet1>


   }
}
