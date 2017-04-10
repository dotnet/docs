using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{

// <Snippet1>
 private void CreateConstraint(DataSet dataSet, 
     string table1, string table2,string column1, string column2)
 {
    // Declare parent column and child column variables.
    DataColumn parentColumn;
    DataColumn childColumn;
    ForeignKeyConstraint foreignKeyConstraint;

    // Set parent and child column variables.
    parentColumn = dataSet.Tables[table1].Columns[column1];
    childColumn = dataSet.Tables[table2].Columns[column2];
    foreignKeyConstraint = new ForeignKeyConstraint
       ("SupplierForeignKeyConstraint",  parentColumn, childColumn);

    // Set null values when a value is deleted.
    foreignKeyConstraint.DeleteRule = Rule.SetNull;
    foreignKeyConstraint.UpdateRule = Rule.Cascade;
    foreignKeyConstraint.AcceptRejectRule = AcceptRejectRule.None;

    // Add the constraint, and set EnforceConstraints to true.
    dataSet.Tables[table1].Constraints.Add(foreignKeyConstraint);
    dataSet.EnforceConstraints = true;
 }
// </Snippet1>

}

public class SuppliersProducts : DataSet { }
