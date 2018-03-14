// <snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class Form1 : System.Windows.Forms.Form
{
private System.Windows.Forms.SplitContainer splitContainer1;

// Create an empty Windows form.
public Form1()
	{
	InitializeComponent();
	}
	private void InitializeComponent()
	{
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        splitContainer1.SuspendLayout();
        SuspendLayout();

        // Place a basic SplitContainer control onto Form1.
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Size = new System.Drawing.Size(292, 273);
        splitContainer1.SplitterDistance = 52;
        splitContainer1.SplitterWidth = 6;
        splitContainer1.TabIndex = 0;
        splitContainer1.Text = "splitContainer1";

        // Add the event handler for the SplitterMoved event.
        splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(splitContainer1_SplitterMoved);

        // Add the event handler for the SplitterMoving event.
        splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(splitContainer1_SplitterMoving);
 
        // This is the left panel of the vertical SplitContainer control.
        splitContainer1.Panel1.Name = "splitterPanel1";
 
        // This is the right panel of the vertical SplitContainer control.
        splitContainer1.Panel2.Name = "splitterPanel2";

        // Lay out the basic properties of the form.
        ClientSize = new System.Drawing.Size(292, 273);
        Controls.Add(splitContainer1);
        Name = "Form1";
        Text = "Form1";
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);

    }
	[STAThread]
	static void Main() 
	{
		Application.Run(new Form1());
	}

    private void splitContainer1_SplitterMoved(System.Object sender, System.Windows.Forms.SplitterEventArgs e)
    {
    // Define what happens when the splitter is no longer moving.
    Cursor.Current=System.Windows.Forms.Cursors.Default;
    }

    private void splitContainer1_SplitterMoving(System.Object sender, System.Windows.Forms.SplitterCancelEventArgs e)
    {
    // Define what happens while the splitter is moving.
    Cursor.Current=System.Windows.Forms.Cursors.NoMoveVert;
    }
}
// </snippet1>