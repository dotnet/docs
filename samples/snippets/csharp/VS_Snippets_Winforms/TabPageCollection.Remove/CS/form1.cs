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

        // Populates the tabControl1 with three tab pages.
        this.tabControl1.TabPages.AddRange(new TabPage[] {
            tabPage1, tabPage2, tabPage3});

        // Gets the tabControl1 controls collection.
        // Removes the tabPage2 from the collection.
        this.tabControl1.TabPages.Remove(tabPage2);

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
