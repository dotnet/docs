﻿using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
    }
    //<Snippet1>
    public static SqlDataAdapter CreateSqlDataAdapter(SqlConnection connection)
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        // Create the commands.
        adapter.SelectCommand = new SqlCommand(
            "SELECT CustomerID, CompanyName FROM CUSTOMERS", connection);
        adapter.InsertCommand = new SqlCommand(
            "INSERT INTO Customers (CustomerID, CompanyName) " +
            "VALUES (@CustomerID, @CompanyName)", connection);
        adapter.UpdateCommand = new SqlCommand(
            "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " +
            "WHERE CustomerID = @oldCustomerID", connection);
        adapter.DeleteCommand = new SqlCommand(
            "DELETE FROM Customers WHERE CustomerID = @CustomerID", connection);

        // Create the parameters.
        adapter.InsertCommand.Parameters.Add("@CustomerID",
            SqlDbType.Char, 5, "CustomerID");
        adapter.InsertCommand.Parameters.Add("@CompanyName",
            SqlDbType.VarChar, 40, "CompanyName");

        adapter.UpdateCommand.Parameters.Add("@CustomerID",
            SqlDbType.Char, 5, "CustomerID");
        adapter.UpdateCommand.Parameters.Add("@CompanyName",
            SqlDbType.VarChar, 40, "CompanyName");
        adapter.UpdateCommand.Parameters.Add("@oldCustomerID",
            SqlDbType.Char, 5, "CustomerID").SourceVersion =
            DataRowVersion.Original;

        adapter.DeleteCommand.Parameters.Add("@CustomerID",
            SqlDbType.Char, 5, "CustomerID").SourceVersion =
            DataRowVersion.Original;

        return adapter;
    }
    //</Snippet1>
}
