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
        // Check the ShouldSerializeRelations methods 
        // before invoking Reset.
        if(!this.ShouldSerializeRelations())
        {
            this.Reset();
        }
    }
}
// </Snippet1>
