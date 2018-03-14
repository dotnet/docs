using System;
using System.Data;
using System.Data.SqlTypes;

namespace SqlNullsCS
{
    class Program
    {
        static void Main()
        {
            CompareNulls();
            Console.ReadLine();
        }
        // <Snippet1>
        private static void CompareNulls()
        {
            // Create two new null strings.
            SqlString a = new SqlString();
            SqlString b = new SqlString();

            // Compare nulls using static/shared SqlString.Equals.
            Console.WriteLine("SqlString.Equals shared/static method:");
            Console.WriteLine("  Two nulls={0}", SqlStringEquals(a, b));

            // Compare nulls using instance method String.Equals.
            Console.WriteLine();
            Console.WriteLine("String.Equals instance method:");
            Console.WriteLine("  Two nulls={0}", StringEquals(a, b));

            // Make them empty strings.
            a = "";
            b = "";

            // When comparing two empty strings (""), both the shared/static and
            // the instance Equals methods evaluate to true.
            Console.WriteLine();
            Console.WriteLine("SqlString.Equals shared/static method:");
            Console.WriteLine("  Two empty strings={0}", SqlStringEquals(a, b));

            Console.WriteLine();
            Console.WriteLine("String.Equals instance method:");
            Console.WriteLine("  Two empty strings={0}", StringEquals(a, b));
        }
        
        private static string SqlStringEquals(SqlString string1, SqlString string2)
        {
            // SqlString.Equals uses database semantics for evaluating nulls.
            string returnValue = SqlString.Equals(string1, string2).ToString();
            return returnValue;
        }

        private static string StringEquals(SqlString string1, SqlString string2)
        {
            // String.Equals uses CLR type semantics for evaluating nulls.
            string returnValue = string1.Equals(string2).ToString();
            return returnValue;
        }
    }
    // </Snippet1>
}
