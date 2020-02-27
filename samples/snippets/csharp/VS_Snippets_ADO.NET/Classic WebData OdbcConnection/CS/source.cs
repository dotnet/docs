using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace Classic_WebData_OdbcConnectionCS
{
	class Program
	{
		static void Main()
		{
			string connectionString;
			connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Samples\\Northwind.mdb";

			InsertRow(connectionString);
		}

		// <Snippet1>
		static private void InsertRow(string connectionString)
		{
			string queryString = 
                "INSERT INTO Customers (CustomerID, CompanyName) Values('NWIND', 'Northwind Traders')";
			OdbcCommand command = new OdbcCommand(queryString);

			using (OdbcConnection connection = new OdbcConnection(connectionString))
			{
				command.Connection = connection;
				connection.Open();
				command.ExecuteNonQuery();

                // The connection is automatically closed at 
                // the end of the Using block.
			}
		}
		// </Snippet1>
	}
}
