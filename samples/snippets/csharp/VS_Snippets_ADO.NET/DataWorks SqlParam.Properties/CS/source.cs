using System;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main()
    {
    }

    // <Snippet1>
    static void CreateSqlParameterOutput()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.Direction = ParameterDirection.Output;
    }
    // </Snippet1>

    // <Snippet2>
    static void CreateSqlParameterNullable()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.IsNullable = true;
        parameter.Direction = ParameterDirection.Output;
    }
    // </Snippet2>

    // <Snippet3>
    static void CreateSqlParameterOffset()
    {
        SqlParameter parameter = new SqlParameter("pDName", SqlDbType.VarChar);
        parameter.IsNullable = true;
        parameter.Offset = 3;
    }
    // </Snippet3>

    // <Snippet4>
    static void CreateSqlParameterPrecisionScale()
    {
        SqlParameter parameter = new SqlParameter("Price", SqlDbType.Decimal);
        parameter.Value = 3.1416;
        parameter.Precision = 8;
        parameter.Scale = 4;
    }
    // </Snippet4>

    // <Snippet5>
    static void CreateSqlParameterSize()
    {
        string description = "12 foot scarf - multiple colors, one previous owner";
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar);
        parameter.Direction = ParameterDirection.InputOutput;
        parameter.Size = description.Length;
        parameter.Value = description;
    }
    // </Snippet5>

    // <Snippet6>
    static void CreateSqlParameterSourceColumn()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.SourceColumn = "Description";
    }
    // </Snippet6>

    // <Snippet7>
    static void CreateSqlParameterSourceVersion()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.SourceColumn = "Description";
        parameter.SourceVersion = DataRowVersion.Current;
    }
    // </Snippet7>

    // <Snippet8>
    static void CreateSqlParameterVersion()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.Value = "garden hose";
    }
    // </Snippet8>

}
