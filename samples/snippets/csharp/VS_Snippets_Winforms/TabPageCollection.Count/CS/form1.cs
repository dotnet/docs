// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private Label label1;

    public Form1()
    {
        this.tabControl1 = new TabControl();
        this.tabPage1 = new TabPage();
        this.tabPage2 = new TabPage();
        this.tabPage3 = new TabPage();
        this.label1 = new Label();

        this.tabControl1.TabPages.AddRange(new TabPage[] {
	        tabPage1, tabPage2, tabPage3});

        this.tabControl1.Location = new Point(25, 75);
        this.tabControl1.Size = new Size(250, 200);

        // Gets the number of TabPage objects in the tabControl1 controls collection.  
        int tabCount = tabControl1.TabPages.Count;

        this.label1.Location = new Point(25, 25);
        this.label1.Size = new Size(250, 25);
        this.label1.Text = "The TabControl below has " + tabCount.ToString() +
	        " TabPage objects in its controls collection.";

        this.ClientSize = new Size(300, 300);
        this.Controls.AddRange(new Control[] {tabControl1, label1});
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>
