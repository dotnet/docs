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
		this.tabPage1 = new TabPage();

		this.tabControl1.Controls.AddRange(new Control[] {
			this.tabPage1});
		this.tabControl1.Location = new Point(25, 25);
		this.tabControl1.Size = new Size(250, 250);

		// Displays a string, myTabPage, on tabPage1.
		this.tabPage1.Text = "myTabPage";

		this.ClientSize = new Size(300, 300);
		this.Controls.AddRange(new Control[] {
			this.tabControl1});
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