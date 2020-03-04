//<snippet2>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private Button _button1 = new Button();
    private Button _button2 = new Button();

    [STAThread]
    static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        _button2.Location = new Point(0, _button1.Height + 10);
        this.Click += Button2_Click;
        this.Controls.Add(_button1);
        this.Controls.Add(_button2);
    }

    // <snippet1>
    private void Button2_Click(object sender, System.EventArgs e)
    {
        // Draws a flat button on button1.
        ControlPaint.DrawButton(
            System.Drawing.Graphics.FromHwnd(_button1.Handle), 0, 0, 
            _button1.Width, _button1.Height,
            ButtonState.Flat);
    }

    // </snippet1>
}
// </snippet2>
