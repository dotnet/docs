using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace Classic_WebData_OdbcConnection.DatabaseCS
{
	class Program
	{
		static void Main(string[] args)
		{
			CreateOdbcConnection();
		}

		// <Snippet1>
		private static void CreateOdbcConnection()
		{
			string connectionString = "Driver={SQL Native Client};Server=(local);Trusted_Connection=Yes;Database=AdventureWorks;";

			using (OdbcConnection connection = new OdbcConnection(connectionString))
			{
				connection.Open();
				Console.WriteLine("ServerVersion: " + connection.ServerVersion
					+ "\nDatabase: " + connection.Database);
				connection.ChangeDatabase("master");
				Console.WriteLine("ServerVersion: " + connection.ServerVersion
					+ "\nDatabase: " + connection.Database);
				Console.ReadLine();
			}
		}
		// </Snippet1>
	}
}
