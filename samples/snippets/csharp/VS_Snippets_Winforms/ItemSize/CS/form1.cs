// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;

    public Form1()
    {
        this.tabControl1 = new TabControl();
        this.tabPage1 = new TabPage();
        this.tabPage2 = new TabPage();
        
        // Sizes the tabs of tabControl1.
        this.tabControl1.ItemSize = new Size(90, 50);

        // Makes the tab width definable. 
        this.tabControl1.SizeMode = TabSizeMode.Fixed;

        this.tabControl1.Controls.AddRange(new Control[] {
            tabPage1, tabPage2});
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