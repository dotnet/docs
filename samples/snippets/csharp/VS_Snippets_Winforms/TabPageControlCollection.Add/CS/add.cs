// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;
    private TabPage tabPage1;
    private Button button1;

    public Form1()
    {
        this.tabControl1 = new TabControl();
        this.tabPage1 = new TabPage();
        this.button1 = new Button();

        this.tabControl1.TabPages.Add(tabPage1);
        this.tabControl1.Location = new Point(25, 25);
        this.tabControl1.Size = new Size(250, 250);

        // Gets the controls collection for tabPage1.
        // Adds button1 to this collection.
        this.tabPage1.Controls.Add(button1);

        this.button1.Text = "button1";
        this.button1.Location = new Point(25, 25);

        this.ClientSize = new Size(300, 300);
        this.Controls.Add(tabControl1);
    }

    static void Main() 
    {
	    Application.Run(new Form1());
    }
}
// </snippet1>