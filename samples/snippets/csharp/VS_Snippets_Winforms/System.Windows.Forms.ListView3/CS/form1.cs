

// The following code example handles the ListView.BeforeLabelEdit event
// and demonstrates the EditLabelEventArgs.Item and CancelEdit properties. 

using System.Windows.Forms;
using System.Drawing;


public class Form1:
	System.Windows.Forms.Form
{
	public Form1() : base()
	{        
		InitializeComponent();
	}

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}

	internal System.Windows.Forms.ListView ListView1;
	internal System.Windows.Forms.Label Label1;

	private void InitializeComponent()
	{
		ListViewItem ListViewItem1 = 
			new ListViewItem("VisualBasic.Net", 0);
		ListViewItem ListViewItem2 = 
			new ListViewItem("Advanced VisualBasic.Net", 1);
		ListViewItem ListViewItem3 = 
			new ListViewItem("Object-Oriented Design");
		ListViewItem ListViewItem4 = 
			new ListViewItem("Design Patterns for VB");
		ListViewItem ListViewItem5 = 
			new ListViewItem("UI Design");
		ListViewItem ListViewItem6 = new ListViewItem("E-Commerce");
		ListViewItem ListViewItem7 = new ListViewItem
			("Software Testing Techniques");
		this.ListView1 = new System.Windows.Forms.ListView();
		this.Label1 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		this.ListView1.Items.AddRange(new ListViewItem[]{ListViewItem1, 
			ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, 
			ListViewItem6, ListViewItem7});
		this.ListView1.LabelEdit = true;
		this.ListView1.Location = new System.Drawing.Point(16, 48);
		this.ListView1.Name = "ListView1";
		this.ListView1.Size = new System.Drawing.Size(248, 120);
		this.ListView1.TabIndex = 0;
		this.ListView1.View = System.Windows.Forms.View.List;
		this.ListView1.BeforeLabelEdit += 
			new LabelEditEventHandler(ListView1_BeforeLabelEdit);
		this.Label1.Location = new System.Drawing.Point(16, 8);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(240, 32);
		this.Label1.TabIndex = 2;
		this.Label1.Text = "Proposed Class Schedule"
			 + " (The first two classes are required):";
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.ListView1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	//<snippet1>
   	private void ListView1_BeforeLabelEdit(object sender, 
		System.Windows.Forms.LabelEditEventArgs e)
	{
		// Allow all but the first two items of the list to 
		// be modified by the user.
		if (e.Item<2)
		{
			e.CancelEdit = true;
		}
	}
	//</snippet1>

}

