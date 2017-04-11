// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;

    public Form1()
    {
        this.tabControl1 = new TabControl();
        TabPage tabPage1 = new TabPage();
        TabPage tabPage2 = new TabPage();
        TabPage tabPage3 = new TabPage();
        TabPage tabPage4 = new TabPage();
        TabPage tabPage5 = new TabPage();

        TabPage[] tabPages = {tabPage1, tabPage2, tabPage3, tabPage4, tabPage5};
        
        // Sizes the tabs so that each row fills the entire width of tabControl1.
        this.tabControl1.SizeMode = TabSizeMode.FillToRight;

        this.tabControl1.Multiline = true;
        this.tabControl1.Padding = new Point(15, 5);
        this.tabControl1.Controls.AddRange(new Control[] {
            tabPage1, tabPage2, tabPage3, tabPage4, tabPage5});
        this.tabControl1.Location = new Point(35, 25);
        this.tabControl1.Size = new Size(220, 220);    

        this.Size = new Size(300, 300);
        this.Controls.Add(tabControl1);
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>