using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace Classic_OdbcConnection.OdbcConnectionCS
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
			using (OdbcConnection connection = new OdbcConnection())
			{
				connection.ConnectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Samples\\Northwind.mdb";
				connection.Open();
			}
		}
		// </Snippet1>
	}
}

