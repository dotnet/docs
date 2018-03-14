// System.Windows.Forms.Control.StyleChanged

/*
   The following example demonstrates the 'StyleChanged' event
   of 'Control' class. This example has the style of the form
   set when the form is loaded. This setting of the style
   raises the 'StyleChanged' event. The event handler associated
   with the 'StyleChanged' event pops a message box indicating
   the same.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;

public class MyForm : Form
{
   private System.Windows.Forms.Button myButton1;

   private Container components = null;

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
      this.myButton1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // Set the properties of the 'myButton1'.
      this.myButton1.Location = new System.Drawing.Point(24, 8);
      this.myButton1.Name = "myButton1";
      this.myButton1.Size = new System.Drawing.Size(192, 48);
      this.myButton1.TabIndex = 0;
      this.myButton1.Text = "button1";
      this.myButton1.Click += new System.EventHandler(this.MyButton1_Click);
      // Set the properties of the 'MyForm'.
      this.ClientSize = new System.Drawing.Size(248, 61);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                   this.myButton1});
      this.Name = "MyForm";
      this.Text = "MyForm";
      this.Load += new EventHandler(MyForm_Load);
      RegisterEventHandler();
      this.ResumeLayout(false);

   }

   [STAThread]
   static void Main()
   {
      Application.Run(new MyForm());
   }

   private void MyButton1_Click(object sender, System.EventArgs e)
   {
      MessageBox.Show("The 'Control' has been clicked");
   }
// <Snippet1>
   // Set the 'FixedHeight' and 'FixedWidth' styles to false.
   private void MyForm_Load(object sender, EventArgs e)
   {
      this.SetStyle(ControlStyles.FixedHeight, false);
      this.SetStyle(ControlStyles.FixedWidth, false);
   }

   private void RegisterEventHandler()
   {
      this.StyleChanged += new EventHandler(MyForm_StyleChanged);
   }

   // Handle the 'StyleChanged' event for the 'Form'.
   private void MyForm_StyleChanged(object sender, EventArgs e)
   {
      MessageBox.Show("The style releated to the 'Form' has been changed");
   }
// </Snippet1>
}
