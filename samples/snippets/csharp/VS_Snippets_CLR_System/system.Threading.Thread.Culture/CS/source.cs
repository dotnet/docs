// <Snippet1>
using System;
using System.Threading;
using System.Windows.Forms;

class UICulture : Form
{
    public UICulture()
    {
        // Set the user interface to display in the
        // same culture as that set in Control Panel.
        Thread.CurrentThread.CurrentUICulture = 
            Thread.CurrentThread.CurrentCulture;

        // Add additional code.
    }

    static void Main()
    {
        Application.Run(new UICulture());
    }
}
// </Snippet1>