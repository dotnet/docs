using System.Windows.Forms;
using System.Drawing;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		InitializeOwnerDrawnListBox();
		//Add any initialization after the InitializeComponent() call

	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (components != null)
			{
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{

		this.SuspendLayout();
		//
		//ListBox1
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);

		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion

	//<snippet1>
	internal System.Windows.Forms.ListBox ListBox1;

	private void InitializeOwnerDrawnListBox()
	{
		this.ListBox1 = new System.Windows.Forms.ListBox();

		// Set the location and size.
		ListBox1.Location = new Point(20, 20);
		ListBox1.Size = new Size(240, 240);

		// Populate the ListBox.ObjectCollection property 
		// with several strings, using the AddRange method.
		this.ListBox1.Items.AddRange(new object[]{"System.Windows.Forms", 
			"System.Drawing", "System.Xml", "System.Net", "System.Runtime.Remoting", 
			"System.Web"});

		// Turn off the scrollbar.
		ListBox1.ScrollAlwaysVisible = false;

		// Set the border style to a single, flat border.
		ListBox1.BorderStyle = BorderStyle.FixedSingle;

		// Set the DrawMode property to the OwnerDrawVariable value. 
		// This means the MeasureItem and DrawItem events must be 
		// handled.
		ListBox1.DrawMode = DrawMode.OwnerDrawVariable;
		ListBox1.MeasureItem += 
			new MeasureItemEventHandler(ListBox1_MeasureItem);
		ListBox1.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);
		this.Controls.Add(this.ListBox1);
		
	}


	// Handle the DrawItem event for an owner-drawn ListBox.
	private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
	{

		// If the item is the selected item, then draw the rectangle
		// filled in blue. The item is selected when a bitwise And  
		// of the State property and the DrawItemState.Selected 
		// property is true.
		if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
		{
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
		}
		else
		{
			// Otherwise, draw the rectangle filled in beige.
			e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
		}

		// Draw a rectangle in blue around each item.
		e.Graphics.DrawRectangle(Pens.Blue, e.Bounds);

		// Draw the text in the item.
		e.Graphics.DrawString(ListBox1.Items[e.Index].ToString(),
			this.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);

		// Draw the focus rectangle around the selected item.
		e.DrawFocusRectangle();
	}

	// Handle the MeasureItem event for an owner-drawn ListBox.
	private void ListBox1_MeasureItem(object sender, 
		MeasureItemEventArgs e)
	{

		// Cast the sender object back to ListBox type.
		ListBox theListBox = (ListBox) sender;

		// Get the string contained in each item.
		string itemString = (string) theListBox.Items[e.Index];

		// Split the string at the " . "  character.
		string[] resultStrings = itemString.Split('.');

		// If the string contains more than one period, increase the 
		// height by ten pixels; otherwise, increase the height by 
		// five pixels.
		if (resultStrings.Length>2)
		{
			e.ItemHeight += 10;
		}
		else
		{
			e.ItemHeight += 5;
		}

	}

	//</snippet1>

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}



}

