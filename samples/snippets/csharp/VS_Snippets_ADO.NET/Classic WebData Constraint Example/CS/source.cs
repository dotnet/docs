using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    private void GetConstraints(DataTable dataTable)
    {
        Console.WriteLine();

        // Print the table's name.
        Console.WriteLine("TableName: " + dataTable.TableName);

        // Iterate through the collection and 
        // print each name and type value.
        foreach(Constraint constraint in dataTable.Constraints ) 
        {
            Console.WriteLine("Constraint Name: " 
                + constraint.ConstraintName);
            Console.WriteLine("Type: " 
                + constraint.GetType().ToString());

            // If the constraint is a UniqueConstraint, 
            // print its properties using a function below.
            if(constraint is UniqueConstraint) 
            {
                PrintUniqueConstraintProperties(constraint);
            }
            // If the constraint is a ForeignKeyConstraint, 
            // print its properties using a function below.
            if(constraint is ForeignKeyConstraint) 
            {
                PrintForeigKeyConstraintProperties(constraint);
            }
        }
    }
 
    private void PrintUniqueConstraintProperties(
        Constraint constraint)
    {
        UniqueConstraint uniqueConstraint;
        uniqueConstraint = (UniqueConstraint) constraint;

        // Get the Columns as an array.
        DataColumn[] columnArray;
        columnArray = uniqueConstraint.Columns;

        // Print each column's name.
        for(int i = 0;i<columnArray.Length ;i++) 
        {
            Console.WriteLine("Column Name: " 
                + columnArray[i].ColumnName);
        }
    }
 
    private void PrintForeigKeyConstraintProperties(
        Constraint constraint)
    {
        ForeignKeyConstraint fkConstraint;
        fkConstraint = (ForeignKeyConstraint) constraint;
 
        // Get the Columns as an array.
        DataColumn[] columnArray;
        columnArray = fkConstraint.Columns;
 
        // Print each column's name.
        for(int i = 0;i<columnArray.Length ;i++) 
        {
            Console.WriteLine("Column Name: " 
                + columnArray[i].ColumnName);
        }
        Console.WriteLine();
 
        // Get the related columns and print each columns name.
        columnArray = fkConstraint.RelatedColumns ;
        for(int i = 0;i<columnArray.Length ;i++) 
        {
            Console.WriteLine("Related Column Name: " 
                + columnArray[i].ColumnName);
        }
        Console.WriteLine();
    }
    // </Snippet1>
}
