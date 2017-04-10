using System;
using System.Drawing;
using System.Windows.Forms;

class TestForm : Form
{
// <snippet1>
public void InitMyForm()
{
	// Adds a label to the form.
	Label label1 = new Label();
	label1.Location = new System.Drawing.Point(54, 128);
	label1.Name = "label1";
	label1.Size = new System.Drawing.Size(220, 80);
	label1.Text = "Start position information";
	this.Controls.Add(label1);

	// Changes the window state to Maximized.
	WindowState = FormWindowState.Maximized;
	// Displays the state information.
	label1.Text = "The form window is " + WindowState;	
}
// </snippet1>
   public static void Main()
   {
      Application.Run(new TestForm());
   }
}

