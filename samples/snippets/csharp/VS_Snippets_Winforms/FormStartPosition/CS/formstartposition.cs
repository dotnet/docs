using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

public class Form1: Form
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

	// Moves the start position to the center of the screen.
	StartPosition = FormStartPosition.CenterScreen;
	// Displays the position information.
	label1.Text = "The start position is " + StartPosition;	
}
// </snippet1>

static void Main() 
{
	Application.Run(new Form1());
}
}

