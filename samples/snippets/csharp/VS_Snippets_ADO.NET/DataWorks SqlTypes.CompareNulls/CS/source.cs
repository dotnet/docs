using System;
using System.Data.SqlTypes;

namespace SqlNullsCS;

static class Program
{
    static void Main()
    {
        CompareNulls();
        Console.ReadLine();
    }
    // <Snippet1>
    static void CompareNulls()
    {
        // Create two new null strings.
        SqlString a = new();
        SqlString b = new();

        // Compare nulls using static/shared SqlString.Equals.
        Console.WriteLine("SqlString.Equals shared/static method:");
        Console.WriteLine($"  Two nulls={SqlStringEquals(a, b)}");

        // Compare nulls using instance method String.Equals.
        Console.WriteLine();
        Console.WriteLine("String.Equals instance method:");
        Console.WriteLine($"  Two nulls={StringEquals(a, b)}");

        // Make them empty strings.
        a = "";
        b = "";

        // When comparing two empty strings (""), both the shared/static and
        // the instance Equals methods evaluate to true.
        Console.WriteLine();
        Console.WriteLine("SqlString.Equals shared/static method:");
        Console.WriteLine($"  Two empty strings={SqlStringEquals(a, b)}");

        Console.WriteLine();
        Console.WriteLine("String.Equals instance method:");
        Console.WriteLine($"  Two empty strings={StringEquals(a, b)}");
    }

    static string SqlStringEquals(SqlString string1, SqlString string2)
    {
        // SqlString.Equals uses database semantics for evaluating nulls.
        var returnValue = SqlString.Equals(string1, string2).ToString();
        return returnValue;
    }

    static string StringEquals(SqlString string1, SqlString string2)
    {
        // String.Equals uses CLR type semantics for evaluating nulls.
        var returnValue = string1.Equals(string2).ToString();
        return returnValue;
    }
}
// </Snippet1>
