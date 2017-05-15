using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
 protected DataSet dataSet1;
// <Snippet1>
 private void AddHandler() {
    GridColumnStylesCollection myGridColumns;
    myGridColumns = dataGrid1.TableStyles[0].GridColumnStyles;
    // Add the handler.
    myGridColumns.CollectionChanged += new 
       CollectionChangeEventHandler(GridCollection_Changed);
 }
 
 private void GridCollection_Changed
   (object sender, CollectionChangeEventArgs e) {
    GridColumnStylesCollection myGridColumns;
    myGridColumns = (GridColumnStylesCollection) sender;
    Console.WriteLine(myGridColumns.Count);
 }       
// </Snippet1>
}
