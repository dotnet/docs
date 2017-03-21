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