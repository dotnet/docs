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