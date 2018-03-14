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
   	label1.Location = new System.Drawing.Point(80,80);
   	label1.Name = "label1";
   	label1.Size = new System.Drawing.Size(132,80);
   	label1.Text = "Start Position Information";
   	this.Controls.Add(label1);

   	// Changes the border to Fixed3D.
   	FormBorderStyle = FormBorderStyle.Fixed3D;

   	// Displays the border information.
   	label1.Text = "The border is " + FormBorderStyle;	
   }
   // </snippet1>

   public static void Main()
   {
      Application.Run(new TestForm());
   }
}
