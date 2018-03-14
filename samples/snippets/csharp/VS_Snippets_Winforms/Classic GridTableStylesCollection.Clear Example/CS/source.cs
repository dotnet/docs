using System;
using System.Windows.Forms;

public class Form1 : Form {

protected DataGrid dataGrid1;
public static void Main()
{}

// <Snippet1>
private void ClearAndAdd()
{
   GridTableStylesCollection gts = dataGrid1.TableStyles;
   gts.Clear();
}
// </Snippet1>

}
