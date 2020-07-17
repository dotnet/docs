//<snippet40>
//<snippet44>
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

public class MyForm : Form
{
    private TextBox box;
    private Button button;

    public MyForm() : base()
    {
        box = new TextBox();
        box.BackColor = System.Drawing.Color.Cyan;
        box.Size = new Size(100,100);
        box.Location = new Point(50,50);
        box.Text = "Hello";

        button = new Button();
        button.Location = new Point(50,100);
        button.Text = "Click Me";

        // To wire the event, create
        // a delegate instance and add it to the Click event.
        button.Click += new EventHandler(this.Button_Click);
        Controls.Add(box);
        Controls.Add(button);
    }

    // The event handler.
    private void Button_Click(object sender, EventArgs e)
    {
        box.BackColor = System.Drawing.Color.Green;
    }

    // The STAThreadAttribute indicates that Windows Forms uses the
    // single-threaded apartment model.
    [STAThread]
    public static void Main()
    {
        Application.Run(new MyForm());
    }
}
//</snippet44>

public class SnippetForm : Form
{
    //<snippet41>
    private Button button;
    //</snippet41>

    //<snippet42>
    private void Button_Click(object sender, EventArgs e)
    {
        //...
    }
    //</snippet42>

    public SnippetForm() : base()
    {
        button = new Button();

        //<snippet43>
        button.Click += new EventHandler(this.Button_Click);
        //</snippet43>
    }
}
#if null
//<snippet45>
csc /r:System.DLL /r:System.Windows.Forms.dll /r:System.Drawing.dll WinEvents.vb
//</snippet45>
#endif
//</snippet40>
