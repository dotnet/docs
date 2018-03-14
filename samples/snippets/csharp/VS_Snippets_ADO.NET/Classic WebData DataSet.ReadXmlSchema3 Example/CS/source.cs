using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
 private void ReadSchemaFromFile(){
    // Create the DataSet to read the schema into.
    DataSet thisDataSet = new DataSet();

    // Set the file path and name. Modify this for your purposes.
    string filename="Schema.xml";

    // Invoke the ReadXmlSchema method with the file name.
    thisDataSet.ReadXmlSchema(filename);
 }
// </Snippet1>

}
