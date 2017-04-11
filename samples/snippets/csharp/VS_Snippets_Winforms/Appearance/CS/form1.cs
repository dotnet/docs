// <snippet1>
using System.Windows.Forms;

public class Form1 : Form
{
    public Form1()
    {
        string[] tabText = {"tabPage1", "tabPage2"};
        TabControl tabControl1 = new TabControl();
        TabPage tabPage1 = new TabPage(tabText[0]);
        TabPage tabPage2 = new TabPage(tabText[1]);

        // Sets the tabs to appear as buttons.
        tabControl1.Appearance = TabAppearance.Buttons;

        tabControl1.Controls.AddRange(new TabPage[] {tabPage1, tabPage2});
        Controls.Add(tabControl1);
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>