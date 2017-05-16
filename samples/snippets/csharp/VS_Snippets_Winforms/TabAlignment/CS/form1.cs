// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;

    private void MyTabs()
    {
        this.tabControl1 = new TabControl();
        this.tabPage1 = new TabPage();
        this.tabPage2 = new TabPage();
        this.tabPage3 = new TabPage();

        // Positions tabs on the left side of tabControl1.
        this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;

        this.tabControl1.Controls.AddRange(new Control[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
        this.tabControl1.Location = new Point(16, 24);
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new Size(248, 232);
        this.tabControl1.TabIndex = 0;

        this.tabPage1.TabIndex = 0;
        this.tabPage2.TabIndex = 1;
        this.tabPage3.TabIndex = 2;

        this.Size = new Size(300,300);
        this.Controls.AddRange(new Control[] {
            this.tabControl1});
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
