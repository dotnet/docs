// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;

    public Form1()
    {
        this.tabControl1 = new TabControl();
        string[] tabText = {"tabPage1", "tabPage2", "tabPage3"};
        this.tabPage1 = new TabPage(tabText[0]);
        this.tabPage2 = new TabPage(tabText[1]);
        this.tabPage3 = new TabPage(tabText[2]);

        // Populates the tabControl1 with two tab pages.
        this.tabControl1.TabPages.AddRange(new TabPage[] {
            tabPage1, tabPage2});

        // Checks the tabControl1 controls collection for tabPage3.
        // Adds tabPage3 to tabControl1 if it is not in the collection.
        if (tabControl1.TabPages.Contains(tabPage3) == false)
            this.tabControl1.TabPages.Add(tabPage3);

        this.tabControl1.Location = new Point(25, 25);
        this.tabControl1.Size = new Size(250, 250);

        this.ClientSize = new Size(300, 300);
        this.Controls.Add(tabControl1);
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>
