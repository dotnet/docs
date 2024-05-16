using System;
using System.Data;

public static class Program
{
    // <Snippet1>
    static void CreateConstraint(DataSet dataSet,
        string table1, string table2, string column1, string column2)
    {
        // Declare parent column and child column variables.
        DataColumn parentColumn, childColumn;
        ForeignKeyConstraint foreignKeyConstraint;

        // Set parent and child column variables.
        parentColumn = dataSet.Tables[table1]?.Columns[column1] ??
            throw new NullReferenceException($"{nameof(CreateConstraint)}: {table1}.{column1} not found");
        childColumn = dataSet.Tables[table2]?.Columns[column2] ??
            throw new NullReferenceException($"{nameof(CreateConstraint)}: {table2}.{column2} not found");
        foreignKeyConstraint = new ForeignKeyConstraint
           ("SupplierForeignKeyConstraint", parentColumn, childColumn)
        {
            // Set null values when a value is deleted.
            DeleteRule = Rule.SetNull,
            UpdateRule = Rule.Cascade,
            AcceptRejectRule = AcceptRejectRule.None
        };

        // Add the constraint, and set EnforceConstraints to true.
        dataSet.Tables[table1]?.Constraints.Add(foreignKeyConstraint);
        dataSet.EnforceConstraints = true;
    }
    // </Snippet1>
}

public class SuppliersProducts : DataSet { }
