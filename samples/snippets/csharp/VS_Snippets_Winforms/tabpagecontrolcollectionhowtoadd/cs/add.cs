
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    public Form1()
    {
        var tabPage1 = new TabPage();
        
        // <snippet1>
        tabPage1.Controls.Add(new Button());
        // </snippet1>
    }

    static void Main() 
    {
	    Application.Run(new Form1());
    }
}
