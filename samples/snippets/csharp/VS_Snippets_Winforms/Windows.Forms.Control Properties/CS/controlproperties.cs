using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ControlProperties
{
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.Button button2;
      private System.ComponentModel.IContainer components;

      public Form1()
      {
         InitializeComponent();
         //this.AddMyGroupBox();

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
         this.components = new System.ComponentModel.Container();
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.button2 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // imageList1
         // 
         this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
         this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
         this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(40, 232);
         this.button2.Name = "button2";
         this.button2.TabIndex = 0;
         this.button2.Text = "button1";
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // Form1
         // 
         this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
         this.ClientSize = new System.Drawing.Size(408, 405);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button2});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
#endregion


//<snippet3>
// Add a button to a form and set some of its common properties.
private void AddMyButton()
{
   // Create a button and add it to the form.
   Button button1 = new Button();

   // Anchor the button to the bottom right corner of the form
   button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);

   // Assign a background image.
   button1.BackgroundImage = imageList1.Images[0];

   // Specify the layout style of the background image. Tile is the default.
   button1.BackgroundImageLayout = ImageLayout.Center;
   
   // Make the button the same size as the image.
   button1.Size = button1.BackgroundImage.Size;

   // Set the button's TabIndex and TabStop properties.
   button1.TabIndex = 1;
   button1.TabStop = true;

   // Add a delegate to handle the Click event.
   button1.Click += new System.EventHandler(this.button1_Click);

   // Add the button to the form.
   this.Controls.Add(button1);
}
// </snippet3>

//<snippet2>
// Add a GroupBox to a form and set some of its common properties.
private void AddMyGroupBox()
{
   // Create a GroupBox and add a TextBox to it.
   GroupBox groupBox1 = new GroupBox();
   TextBox textBox1 = new TextBox();
   textBox1.Location = new Point(15, 15);
   groupBox1.Controls.Add(textBox1);

   // Set the Text and Dock properties of the GroupBox.
   groupBox1.Text = "MyGroupBox";
   groupBox1.Dock = DockStyle.Top;

   // Disable the GroupBox (which disables all its child controls)
   groupBox1.Enabled = false;

   // Add the Groupbox to the form.
   this.Controls.Add(groupBox1);
}
// </snippet2>


// <snippet1>
// Reset all the controls to the user's default Control color. 
private void ResetAllControlsBackColor(Control control)
{
   control.BackColor = SystemColors.Control;
   control.ForeColor = SystemColors.ControlText;
   if(control.HasChildren)
   {
      // Recursively call this method for each child control.
      foreach(Control childControl in control.Controls)
      {
         ResetAllControlsBackColor(childControl);
      }
   }
}
// </snippet1>



     [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }

      private void button1_Click(object sender, System.EventArgs e)
      {
         this.ResetAllControlsBackColor(this);
      }

      private void button2_Click(object sender, System.EventArgs e)
      {
         this.AddMyButton();
      }
   }
}
