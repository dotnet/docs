using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    //<Snippet1>
    private void Current_Changed(object sender, EventArgs e)
    {
        BindingManagerBase bm = (BindingManagerBase) sender;
        /* Check the type of the Current object. If it is not a 
        DataRowView, exit the method. */
        if(bm.Current.GetType() != typeof(DataRowView)) return;

        // Otherwise, print the value of the column named "CustName".
        DataRowView drv = (DataRowView) bm.Current;
        Console.Write("CurrentChanged): ");
        Console.Write(drv["CustName"]);
        Console.WriteLine();
    }
    //</Snippet1>
}
