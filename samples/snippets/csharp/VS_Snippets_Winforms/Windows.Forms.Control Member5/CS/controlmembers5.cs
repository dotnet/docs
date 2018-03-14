using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ControlMembers4
{
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
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
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(40, 48);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(40, 112);
         this.button2.Name = "button2";
         this.button2.TabIndex = 1;
         this.button2.Text = "button2";
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // button3
         // 
         this.button3.Location = new System.Drawing.Point(40, 184);
         this.button3.Name = "button3";
         this.button3.TabIndex = 2;
         this.button3.Text = "button3";
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // Form1
         // 
         this.AutoScroll = true;
         this.ClientSize = new System.Drawing.Size(368, 325);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button3,
                                                                      this.button2,
                                                                      this.button1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
		#endregion

      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }



      private void button3_Click(object sender, System.EventArgs e)
      {
         this.SizeControls();
      }

// Control.Size/Control.ClientSize/Control.SetClientSizeCore
// <snippet3>
private void SizeControls()
{
   // Resize the buttons two different ways.
   button1.Size = new Size(75, 25);
   button2.ClientSize = new Size(100, 50);

   // Resize the form.
   this.SetClientSizeCore(300, 300);
}
// </snippet3>

      private void button1_Click(object sender, System.EventArgs e)
      {
         this.ResizeForm();
      }

/* Control.ClientRectangle/Control.Bounds/Rectangle.Inflate/
 * Control.ScrollControlIntoView/Control.AutoScroll */
// <snippet2>
private void ResizeForm()
{
   // Enable auto-scrolling for the form.
   this.AutoScroll = true;

   // Resize the form.
   Rectangle r = this.ClientRectangle;
   // Subtract 100 pixels from each side of the Rectangle.
   r.Inflate(-100, -100);
   this.Bounds = this.RectangleToScreen(r);

   // Make sure button2 is visible.
   this.ScrollControlIntoView(button2);
}
// </snippet2>

      
      private void button2_Click(object sender, System.EventArgs e)
      {
         this.AutoSizeControl((Control)sender, 5);
      }

/* Control.CreateGraphics/Control.Text/Control.Font/
 * Control.Height/Control.Width/Control.ClientSize */
// <snippet1>
private void AutoSizeControl(Control control, int textPadding)
{
   // Create a Graphics object for the Control.
   Graphics g = control.CreateGraphics();

   // Get the Size needed to accommodate the formatted Text.
   Size preferredSize = g.MeasureString(
      control.Text, control.Font).ToSize();

   // Pad the text and resize the control.
   control.ClientSize = new Size(
      preferredSize.Width + (textPadding * 2), 
      preferredSize.Height+(textPadding * 2) );

   // Clean up the Graphics object.
   g.Dispose();
}
// </snippet1>

   }
}