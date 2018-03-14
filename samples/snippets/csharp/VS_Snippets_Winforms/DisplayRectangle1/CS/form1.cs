// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private Rectangle myTabRect;

    public Form1()
    {
        TabControl tabControl1 = new TabControl();
        TabPage tabPage1 = new TabPage();

        tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        tabControl1.Appearance = TabAppearance.Buttons;
        tabControl1.Location = new Point(25, 25);
        tabControl1.Controls.Add(tabPage1);
        Controls.Add(tabControl1);

        // Gets a Rectangle that represents the tab page display area of tabControl1.
        myTabRect = tabControl1.DisplayRectangle;

        myTabRect.Inflate(1, 1); 
        tabControl1.DrawItem += new DrawItemEventHandler(DrawOnTabPage);
    }

    private void DrawOnTabPage(object sender, DrawItemEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen p = new Pen(Color.Blue);
        g.DrawRectangle(p, myTabRect);
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>