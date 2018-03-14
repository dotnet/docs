using System;
using System.Data;
using System.Data.Common;

class Program
{
    // <Snippet1>
    static void Main()
    {
        DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
        builder.ConnectionString =
            "Provider=MSDataShape.1;Persist Security Info=false;" +
            "Data Provider=MSDAORA;Data Source=orac;" +
            "user id=username;password=*******";

        foreach (string value in builder.Values)
            Console.WriteLine(value);
    }
    // </Snippet1>
}
