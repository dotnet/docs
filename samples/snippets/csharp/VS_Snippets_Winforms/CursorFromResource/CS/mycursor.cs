using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Resources;

namespace MyCursors
{
	public class MyCursor : System.Windows.Forms.Form
	{
		
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button myButton;
		private System.ComponentModel.Container components = null;

		public MyCursor()
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


// <snippet1>
private void SetCursor()
{
   // Display an OpenFileDialog so the user can select a cursor.
   OpenFileDialog openFileDialog1 = new OpenFileDialog();
   openFileDialog1.Filter = "Cursor Files|*.cur";
   openFileDialog1.Title = "Select a Cursor File";
   openFileDialog1.ShowDialog();

   // If a .cur file was selected, open it.
   if(openFileDialog1.FileName != "")
   {
      // Assign the cursor in the stream to the form's Cursor property.
      this.Cursor = new Cursor(openFileDialog1.OpenFile());
   }
}
// </snippet1>

		
// <snippet2>
private void myButton_Click(object sender, System.EventArgs e)
{
   /* Call the CursorFromResource method and 
   display the embedded cursor resource. */
   this.Cursor = CursorFromResource(typeof(MyCursors.MyCursor),
     "MyWaitCursor.cur");
}

private Cursor CursorFromResource(Type type, string resource)
{
   // Create a cursor from the resource.
   try
   {
      return new Cursor(type, resource);
   }

   // If the cursor cannot be created, message the user.
   catch(Exception ex)
   {
      MessageBox.Show(ex.ToString());
      return null;
   }
}
// </snippet2>


// <snippet3>
private void myButton_MouseEnter(object sender, System.EventArgs e)
{
   // Hide the cursor when the mouse pointer enters the button.
   Cursor.Hide();
}

private void myButton_MouseLeave(object sender, System.EventArgs e)
{
   // Show the cursor when the mouse pointer leaves the button.
   Cursor.Show();
}
// </snippet3>


		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.myButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(104, 192);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.myButton.MouseEnter += new System.EventHandler(this.myButton_MouseEnter);
			this.myButton.MouseLeave += new System.EventHandler(this.myButton_MouseLeave);
			// 
			// myButton
			// 
			this.myButton.Location = new System.Drawing.Point(40, 32);
			this.myButton.Name = "myButton";
			this.myButton.TabIndex = 1;
			this.myButton.Text = "myButton";
			this.myButton.Click += new System.EventHandler(this.myButton_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.myButton, this.button1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MyCursor());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.SetCursor();
		}


	} // end class
} // end namespace