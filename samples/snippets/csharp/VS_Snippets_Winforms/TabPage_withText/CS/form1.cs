// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
	private TabControl tabControl1;
	private TabPage tabPage1;

	private void MyTabs()
	{
		this.tabControl1 = new TabControl();
		string tabPageName = "myTabPage";

		// Constructs a TabPage with a TabPage.Text value.
		this.tabPage1 = new TabPage(tabPageName);

		this.tabControl1.Controls.Add(tabPage1);
		this.tabControl1.Location = new Point(25, 25);
		this.tabControl1.Size = new Size(250, 250);

		this.ClientSize = new Size(300, 300);
		this.Controls.Add(tabControl1);
	}

	public Form1()
	{
		MyTabs();	
	}

	static void Main() 
	{
		Application.Run(new Form1());
	}
}
// </snippet1>