using System;
using System.Xml;
using System.Data;
using System.Data.Common;

public class Form1
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void CreateConstraint(DataSet dataSet, 
        string table1, string table2, string column1, string column2)
    {
        ForeignKeyConstraint idKeyRestraint = new 
            ForeignKeyConstraint(dataSet.Tables[table1].Columns[column1],
            dataSet.Tables[table2].Columns[column2]);

        // Set null values when a value is deleted.
        idKeyRestraint.DeleteRule = Rule.SetNull;
        idKeyRestraint.UpdateRule = Rule.Cascade;

        // Set AcceptRejectRule to cascade changes.
        idKeyRestraint.AcceptRejectRule = AcceptRejectRule.Cascade;
 
        dataSet.Tables[table1].Constraints.Add(idKeyRestraint);
        dataSet.EnforceConstraints = true;
    }
    // </Snippet1>

}

