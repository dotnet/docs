// <snippet1>
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private Rectangle tabArea;
    private RectangleF tabTextArea;

    public Form1()
    {
        TabControl tabControl1 = new TabControl();
        TabPage tabPage1 = new TabPage();

        // Allows access to the DrawItem event. 
        tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

        tabControl1.SizeMode = TabSizeMode.Fixed;
        tabControl1.Controls.Add(tabPage1);
        tabControl1.ItemSize = new Size(80, 30);
        tabControl1.Location = new Point(25, 25);
        tabControl1.Size = new Size(250, 250);
        tabPage1.TabIndex = 0;
        ClientSize = new Size(300, 300);
        Controls.Add(tabControl1);

        tabArea = tabControl1.GetTabRect(0);
        tabTextArea = (RectangleF)tabControl1.GetTabRect(0);

        // Binds the event handler DrawOnTab to the DrawItem event 
        // through the DrawItemEventHandler delegate.
        tabControl1.DrawItem += new DrawItemEventHandler(DrawOnTab);
    }

    // Declares the event handler DrawOnTab which is a method that
    // draws a string and Rectangle on the tabPage1 tab.
    private void DrawOnTab(object sender, DrawItemEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen p = new Pen(Color.Blue);
        Font font = new Font("Arial", 10.0f);
        SolidBrush brush = new SolidBrush(Color.Red);

        g.DrawRectangle(p, tabArea);
        g.DrawString("tabPage1", font, brush, tabTextArea);
    }

    static void Main() 
    {
        Application.Run(new Form1());
    }
}
// </snippet1>
