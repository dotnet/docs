// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
	private TabControl tabControl1;
	private TabPage tabPage1;
	private TabPage tabPage2;
	private Button button1;
	private Button button2;

	private void InitializeMyTabs()
	{
		tabControl1 = new System.Windows.Forms.TabControl();
		tabPage1 = new System.Windows.Forms.TabPage();
		tabPage2 = new System.Windows.Forms.TabPage();
		button1 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();

		tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
			tabPage1,
			tabPage2});
		tabControl1.Location = new System.Drawing.Point(40, 24);
		tabControl1.Size = new System.Drawing.Size(216, 216);
		tabControl1.TabIndex = 0;

		tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {button1});
		tabPage1.TabIndex = 0;
		tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {button2});
		tabPage2.TabIndex = 1;

		button1.Location = new System.Drawing.Point(64, 72);
		button2.Location = new System.Drawing.Point(64, 72);
		button2.Text = "button2";

		ClientSize = new System.Drawing.Size(292, 273);
		Controls.AddRange(new System.Windows.Forms.Control[] {tabControl1});

		// Gets the index of the TabPage containing button2.
		// Selects the index of the TabPage containing button2. 
		tabControl1.SelectedIndex = (TabPage.GetTabPageOfComponent(button2)).TabIndex;
	}

	public Form1()
	{
		InitializeMyTabs();
	}

	static void Main() 
	{
		Application.Run(new Form1());
	}
}
// </snippet1>