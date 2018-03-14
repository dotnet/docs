using System.Collections;
//-----------------------------------------------------------------------------
//<Snippet4>
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    public const double SALES_TAX = .086;

    [SqlFunction()]
    public static SqlDouble addTax(SqlDouble originalAmount)
    {
        SqlDouble taxAmount = originalAmount * SALES_TAX;

        return originalAmount + taxAmount;
    }
}
//</Snippet4>


//-----------------------------------------------------------------------------
//<Snippet10>
public partial class UserDefinedFunctions
{
    [SqlFunction(Name="sp_scalarFunc")]
    public static SqlString SampleScalarFunction(SqlString s)
    {
        //...
        return "";
    }
}
//</Snippet10>


//-----------------------------------------------------------------------------
//<Snippet11>
public partial class UserDefinedFunctions
{
    [SqlFunction(Name="sp_tableFunc", TableDefinition="letter nchar(1)")]
    public static IEnumerable SampleTableFunction(SqlString s)
    {
        //...
        return new ArrayList(new char[3] {'a', 'b', 'c'});
    }
}
//</Snippet11>
