using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

// <Snippet1>
public  class DerivedDataSet:System.Data.DataSet 
{
    public void ResetDataSetRelations()
    {
        // Check the ShouldPersistTable method 
        // before invoking Reset.
        if(!this.ShouldSerializeTables())
        {
            this.Reset();
        }
    }
}
// </Snippet1>

