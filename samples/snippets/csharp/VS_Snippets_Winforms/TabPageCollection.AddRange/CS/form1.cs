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
        this.tabPage1 = new TabPage();
        this.tabPage2 = new TabPage();
        this.tabPage3 = new TabPage();

        // Gets the controls collection for tabControl1.
        // Adds an array of tab pages to this collection.
        this.tabControl1.Controls.AddRange(new TabPage[] {
            tabPage1, tabPage2, tabPage3});

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
