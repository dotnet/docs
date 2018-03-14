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
		InitializeLinkLabel();

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
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(272, 266);
		this.Name = "Form1";
		this.Text = "Form1";

	}

	#endregion

	//<snippet1>

	// Declare the LinkLabel object.
	internal System.Windows.Forms.LinkLabel LinkLabel1;

	// Declare keywords array to identify links
	string[] keywords;

	private void InitializeLinkLabel()
	{
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
                this.LinkLabel1.Links.Clear();

		// Set the location, name and size.
		this.LinkLabel1.Location = new System.Drawing.Point(10, 20);
		this.LinkLabel1.Name = "CompanyLinks";
		this.LinkLabel1.Size = new System.Drawing.Size(104, 150);

		// Set the LinkBehavior property to show underline when mouse
		// hovers over the links.
		this.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
		string textString = "For more information see our" +
			" company website or the research page at Contoso Ltd. ";

		// Set the text property.
		this.LinkLabel1.Text = textString;

		// Set the color of the links to black, unless the mouse
		// is hovering over a link.
		this.LinkLabel1.LinkColor = System.Drawing.Color.Black;
		this.LinkLabel1.ActiveLinkColor = System.Drawing.Color.Blue;

		// Associate the event-handling method with the LinkClicked
		// event.
		this.LinkLabel1.LinkClicked += 
			new LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked);

		// Add links to the LinkCollection using starting index and
		// length of keywords.
		keywords = new string[]{"company", "research"};
		foreach ( string keyword in keywords )
		{
			this.LinkLabel1.Links.Add(textString.IndexOf(keyword), keyword.Length);
		}

		// Add the label to the form.
		this.Controls.Add(this.LinkLabel1);
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{

		string url = "";

		// Determine which link was clicked and set the appropriate url.
		switch(LinkLabel1.Links.IndexOf(e.Link))
		{
			case 0:
				url = "www.microsoft.com";

				break;
			case 1:
				url = "www.contoso.com/research";
				break;
		}

		// Set the visited property to True. This will change
		// the color of the link.
		e.Link.Visited = true;

		// Open Internet Explorer to the correct url.
		System.Diagnostics.Process.Start("IExplore.exe", url);
	}
	//</snippet1>

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}

}

