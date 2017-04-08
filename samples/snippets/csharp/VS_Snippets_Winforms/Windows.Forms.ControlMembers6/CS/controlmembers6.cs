using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ControlMembers6
{
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button button4;
      private System.ComponentModel.Container components = null;

      public Form1()
      {
         InitializeComponent();
         textBox1.Enabled = checkBox1.Checked;
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
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.button2 = new System.Windows.Forms.Button();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.button3 = new System.Windows.Forms.Button();
         this.button4 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(48, 40);
         this.button1.Name = "button1";
         this.button1.TabIndex = 0;
         this.button1.Text = "Focus";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(48, 88);
         this.textBox1.Name = "textBox1";
         this.textBox1.TabIndex = 1;
         this.textBox1.Text = "textBox1";
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(160, 40);
         this.button2.Name = "button2";
         this.button2.TabIndex = 2;
         this.button2.Text = "Select";
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // checkBox1
         // 
         this.checkBox1.Location = new System.Drawing.Point(160, 88);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.TabIndex = 3;
         this.checkBox1.Text = "Enabled";
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // button3
         // 
         this.button3.Location = new System.Drawing.Point(216, 248);
         this.button3.Name = "button3";
         this.button3.TabIndex = 4;
         this.button3.Text = "button3";
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // button4
         // 
         this.button4.Location = new System.Drawing.Point(0, 248);
         this.button4.Name = "button4";
         this.button4.TabIndex = 5;
         this.button4.Text = "button4";
         this.button4.Click += new System.EventHandler(this.button4_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button4,
                                                                      this.button3,
                                                                      this.checkBox1,
                                                                      this.button2,
                                                                      this.textBox1,
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

      private void button1_Click(object sender, System.EventArgs e)
      {
         this.ControlSetFocus(this.textBox1);         
      }

//<snippet1>
public void ControlSetFocus(Control control)
{
   // Set focus to the control, if it can receive focus.
   if(control.CanFocus)
   {
      control.Focus();
   }
}
//</snippet1>


//<snippet2>
public void ControlSelect(Control control)
{
   // Select the control, if it can be selected.
   if(control.CanSelect)
   {
      control.Select();
   }
}
//</snippet2>


      



      private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
      {
         textBox1.Enabled = checkBox1.Checked;
      }

      private void button2_Click(object sender, System.EventArgs e)
      {
         this.ControlSelect(this.textBox1);    
      }

//<snippet3>
public void EnableDoubleBuffering()
{
   // Set the value of the double-buffering style bits to true.
   this.SetStyle(ControlStyles.DoubleBuffer | 
      ControlStyles.UserPaint | 
      ControlStyles.AllPaintingInWmPaint,
      true);
   this.UpdateStyles();
}
// </snippet3>

// <snippet4>
public bool DoubleBufferingEnabled()
{
   // Get the value of the double-buffering style bits.
   return this.GetStyle(ControlStyles.DoubleBuffer | 
      ControlStyles.UserPaint | 
      ControlStyles.AllPaintingInWmPaint);
}
// </snippet4>



      private void button4_Click(object sender, System.EventArgs e)
      {
         this.EnableDoubleBuffering();
      }

      private void button3_Click(object sender, System.EventArgs e)
      {
         MessageBox.Show(this.DoubleBufferingEnabled().ToString() );
         this.ScaleChildControls();
      }


// <snippet5>
public void ScaleChildControlsEqually()
{
   // Resize all child controls to 1.5 
   // times their current size.
   for(int i = 0; i < this.Controls.Count; i++)
   {
      this.Controls[i].Scale(1.5f);
   }
}
// </snippet5>


// <snippet6>
public void ScaleChildControls()
{
   // Resize all child controls to 1.5 times their current
   // height while, maintaining their current width.
   for(int i = 0; i < this.Controls.Count; i++)
   {
      this.Controls[i].Scale(1.0f, 1.5f);
   }
}
// </snippet6>


   }
}
