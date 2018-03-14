//<snippet2>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
      private Button button1 = new Button();
      private Button button2 = new Button();


    [STAThread]
    static void Main() 
    {
        Application.Run(new Form1());
    }


    public Form1(){
        this.button2.Location = new Point(0, button1.Height + 10);
        this.Click += new EventHandler(this.button2_Click);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.button2);
    }

    // <snippet1>
    private void button2_Click(object sender, System.EventArgs e)
    {
        // Draws a flat button on button1.
        ControlPaint.DrawButton(
        System.Drawing.Graphics.FromHwnd(button1.Handle),0,0,button1.Width,button1.Height,
                ButtonState.Flat);
    }
    // </snippet1>
}
// </snippet2>