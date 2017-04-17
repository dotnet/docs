using System;
using System.Globalization;
using System.Windows.Forms;

public class Form1:Form{
protected DataGrid myDataGrid;
static void Main()
	{}

	// <Snippet1>
private void ChangeColumnCultureInfo(){
   /* Create a new CultureInfo object using the 
   the locale ID for Italy. */
   System.Globalization.CultureInfo ItalyCultureInfo= 
   new CultureInfo(0x0410);
     
   /* Cast a column that holds numeric values to the   
   DataGridTextBoxColumn type, and set the FormatInfo
   property to the new CultureInfo object. */
   DataGridTextBoxColumn myGridTextBoxColumn = 
   (DataGridTextBoxColumn) myDataGrid.TableStyles["Orders"].
   GridColumnStyles["OrderAmount"];
   myGridTextBoxColumn.FormatInfo = ItalyCultureInfo;
   myGridTextBoxColumn.Format = "c";
}
// </Snippet1>
}

