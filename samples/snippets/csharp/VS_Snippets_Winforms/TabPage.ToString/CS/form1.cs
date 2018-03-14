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

        this.tabControl1.Controls.Add(tabPage1);
        this.tabControl1.Location = new Point(25, 25);
        this.tabControl1.Size = new Size(250, 250);
        this.tabControl1.ShowToolTips = true;

        this.tabPage1.Text = "myTabPage1";

        // Creates a string showing the Text value for tabPage1. 
        // Then assigns the string to ToolTipText.  
        this.tabPage1.ToolTipText = tabPage1.ToString();

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