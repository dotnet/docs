		static private void CreateOdbcConnection()
		{
			string connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\\Samples\\Northwind.mdb";

			using (OdbcConnection connection = new OdbcConnection(connectionString))
			{
				connection.Open();
			}
		}