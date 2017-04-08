//-----------------------------------------------------------------------------
//<Snippet1>
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
    [SqlProcedure()]
    public static void InsertCurrency_CS(
        SqlString currencyCode, SqlString name)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            SqlCommand InsertCurrencyCommand = new SqlCommand();
            SqlParameter currencyCodeParam = new SqlParameter("@CurrencyCode", SqlDbType.NVarChar);
            SqlParameter nameParam = new SqlParameter("@Name", SqlDbType.NVarChar);

            currencyCodeParam.Value = currencyCode;
            nameParam.Value = name;

            InsertCurrencyCommand.Parameters.Add(currencyCodeParam);
            InsertCurrencyCommand.Parameters.Add(nameParam);

            InsertCurrencyCommand.CommandText =
                "INSERT Sales.Currency (CurrencyCode, Name, ModifiedDate)" +
                " VALUES(@CurrencyCode, @Name, GetDate())";

            InsertCurrencyCommand.Connection = conn;

            conn.Open();
            InsertCurrencyCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
}
//</Snippet1>


//-----------------------------------------------------------------------------
//<Snippet7>
public partial class StoredProcedures
{
    [SqlProcedure(Name="sp_sqlName")]
    public static void SampleProcedure(SqlString s)
    {
        //...
    }
}
//</Snippet7>
