// <snippet1>
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;
    private TabPage tabPage1;

    public void MyTabs()
    {
        // Invokes the TabControl() constructor to create the tabControl1 object.
        this.tabControl1 = new System.Windows.Forms.TabControl();

        // Creates a new tab page and adds it to the tab control
        this.tabPage1 = new TabPage();
                
        this.tabControl1.TabPages.Add(tabPage1);

        // Adds the tab control to the form
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