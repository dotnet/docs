using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace Classic_OdbcConnection.OdbcConnection1CS
{
	class Program
	{
		static void Main(string[] args)
		{
			CreateOdbcConnection();
		}

		// <Snippet1>
		static private void CreateOdbcConnection()
		{
			string connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Samples\\Northwind.mdb";

			using (OdbcConnection connection = new OdbcConnection(connectionString))
			{
				connection.Open();
			}
		}
		// </Snippet1>
	}
}
