// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    public Form1()
    {
        TabControl tabControl1 = new TabControl();
        TabPage tabPage1 = new TabPage();
        TabPage tabPage2 = new TabPage();
        Label label1 = new Label();

        // Determines if the tabControl1 controls collection is read-only.
        if (tabControl1.TabPages.IsReadOnly == true)
	        label1.Text = "The tabControl1 controls collection is read-only.";
        else
	        label1.Text = "The tabControl1 controls collection is not read-only.";

        tabControl1.TabPages.AddRange(new TabPage[] {tabPage1, tabPage2});
        tabControl1.Location = new Point(25, 75);
        tabControl1.Size = new Size(250, 200);

        label1.Location = new Point(25, 25);
        label1.Size = new Size(250, 25);

        this.ClientSize = new Size(300, 300);
        this.Controls.AddRange(new Control[] {tabControl1, label1});
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>
