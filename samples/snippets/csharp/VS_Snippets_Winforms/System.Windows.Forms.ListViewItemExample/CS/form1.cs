using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		InitializeListViewItems();

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
	internal System.Windows.Forms.ListView ListView1;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.ListView1 = new System.Windows.Forms.ListView();
		this.SuspendLayout();
		//
		//ListView1
		//
		this.ListView1.Location = new System.Drawing.Point(120, 72);
		this.ListView1.Name = "ListView1";
		this.ListView1.TabIndex = 0;
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.ListView1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion
	//<snippet1>
	private void InitializeListViewItems()
	{
		ListView1.View = View.List;
		

		Cursor[] favoriteCursors = new Cursor[]{Cursors.Help, 
			Cursors.Hand, Cursors.No, Cursors.Cross};

		// Populate the ListView control with the array of Cursors.
		foreach ( Cursor aCursor in favoriteCursors )
		{

			// Construct the ListViewItem object
			ListViewItem item = new ListViewItem();

			// Set the Text property to the cursor name.
			item.Text = aCursor.ToString();

			// Set the Tag property to the cursor.
			item.Tag = aCursor;

			// Add the ListViewItem to the ListView.
			ListView1.Items.Add(item);
		}
	}
	//</snippet1>

	public static void Main()
	{
		Application.Run(new Form1());
	}

}

