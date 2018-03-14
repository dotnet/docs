// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;
    private TabPage tabPage1;

    public Form1()
    {
        this.tabControl1 = new TabControl();
        this.tabPage1 = new TabPage("myTabPage");

        this.tabControl1.TabPages.Add(tabPage1);
        this.tabControl1.ShowToolTips = true;
        this.tabControl1.Location = new Point(25, 25);
        this.tabControl1.Size = new Size(250, 250);

        this.tabPage1.ToolTipText = "TabIndex = " +
        	
            // Gets the tabPage1 TabIndex value from the tabControl1 controls collection.
            // Converts the tabPage1 TabIndex value to a string.
            (tabControl1.TabPages.IndexOf(tabPage1)).ToString();

        this.ClientSize = new Size(300, 300);
        this.Controls.Add(tabControl1);
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>
