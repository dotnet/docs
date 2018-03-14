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
        TabPage tabPage3 = new TabPage();
        TabPage tabPage4 = new TabPage();
        TabPage tabPage5 = new TabPage();
        Label label1= new Label();


        tabControl1.Multiline = true;
        tabControl1.SizeMode = TabSizeMode.FillToRight;
        tabControl1.Padding = new Point(15, 5);
        tabControl1.Controls.AddRange(new Control[] {
            tabPage1, tabPage2, tabPage3, tabPage4, tabPage5});
        tabControl1.Location = new Point(35, 65);
        tabControl1.Size = new Size(220, 180);    

        // Gets the number of tabs currently in the tabControl1 tab strip.
        // Assigns int value to the tabsInTabStrip variable.
        int tabsInTabStrip = tabControl1.TabCount;

        label1.Text = "There are " + tabsInTabStrip.ToString() + 
            " tabs in the tabControl1 tab strip.";
        label1.Location = new Point(35, 25);
        label1.Size = new Size(220, 30);

        Size = new Size(300, 300);
        Controls.AddRange(new Control[] {label1, tabControl1});
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>