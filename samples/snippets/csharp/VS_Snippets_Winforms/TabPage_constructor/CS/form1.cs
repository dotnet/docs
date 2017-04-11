// <snippet1>
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;
    private TabPage tabPage1;

    public void MyTabs()
    {
        this.tabControl1 = new TabControl();

        // Invokes the TabPage() constructor to create the tabPage1.
        this.tabPage1 = new System.Windows.Forms.TabPage();

        this.tabControl1.Controls.Add(tabPage1);
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