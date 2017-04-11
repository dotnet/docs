using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
    }
    // <Snippet1>
    private static void TestGetValues(DataTableReader reader)
    {
        // Given a DataTableReader, use the GetValues
        // method to retrieve a full row of data.
        // Test the GetValues method, passing in an array large
        // enough for all the columns.
        Object[] values = new Object[reader.FieldCount];
        int fieldCount = reader.GetValues(values);

        Console.WriteLine("reader.GetValues retrieved {0} columns.",
            fieldCount);
        for (int i = 0; i < fieldCount; i++)
            Console.WriteLine(values[i]);

        Console.WriteLine();

        // Now repeat, using an array that may contain a different 
        // number of columns than the original data. This should work correctly,
        // whether the size of the array is larger or smaller than 
        // the number of columns.

        // Attempt to retrieve three columns of data.
        values = new Object[3];
        fieldCount = reader.GetValues(values);
        Console.WriteLine("reader.GetValues retrieved {0} columns.",
            fieldCount);
        for (int i = 0; i < fieldCount; i++)
            Console.WriteLine(values[i]);
    }
    // </Snippet1>

    // <Snippet2>
    private static void TestGetValues(SqlDataReader reader)
    {
        // Given a SqlDataReader, use the GetValues
        // method to retrieve a full row of data.
        // Test the GetValues method, passing in an array large
        // enough for all the columns.
        Object[] values = new Object[reader.FieldCount];
        int fieldCount = reader.GetValues(values);

        Console.WriteLine("reader.GetValues retrieved {0} columns.",
            fieldCount);
        for (int i = 0; i < fieldCount; i++)
            Console.WriteLine(values[i]);

        Console.WriteLine();

        // Now repeat, using an array that may contain a different 
        // number of columns than the original data. This should work correctly,
        // whether the size of the array is larger or smaller than 
        // the number of columns.

        // Attempt to retrieve three columns of data.
        values = new Object[3];
        fieldCount = reader.GetValues(values);
        Console.WriteLine("reader.GetValues retrieved {0} columns.",
            fieldCount);
        for (int i = 0; i < fieldCount; i++)
            Console.WriteLine(values[i]);
    }
    // </Snippet2>
}

