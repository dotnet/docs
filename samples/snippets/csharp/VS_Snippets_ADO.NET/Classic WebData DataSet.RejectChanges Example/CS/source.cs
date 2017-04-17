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
    private void RejectChangesInDataSet()
    {
        // Instantiate the derived DataSet.
        DerivedDataSet derivedData = new DerivedDataSet();

        // Insert code to change values.
    
        // Invoke the RejectChanges method in the derived class.
        derivedData.RejectDataSetChanges();
    }

    public  class DerivedDataSet:System.Data.DataSet 
    {
        public void RejectDataSetChanges()
        {
            // Invoke the RejectChanges method.
            this.RejectChanges();
        }
    }
    // </Snippet1>
}
 
 


