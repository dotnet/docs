// <snippet1>

using System;
using System.Windows.Forms;

public class Form1: Form
{
    public Form1()
    {
        // Create a TextBox control.
        TextBox tb = new TextBox();
        this.Controls.Add(tb);
        tb.KeyPress += new KeyPressEventHandler(keypressed);
    }

    private void keypressed(Object o, KeyPressEventArgs e)
    {
        // The keypressed method uses the KeyChar property to check 
        // whether the ENTER key is pressed. 

        // If the ENTER key is pressed, the Handled property is set to true, 
        // to indicate the event is handled.
        if (e.KeyChar == (char)Keys.Return)
        {
            e.Handled = true;
        }
    }

    public static void Main()
    {
        Application.Run(new Form1());
    }
}
// </snippet1>