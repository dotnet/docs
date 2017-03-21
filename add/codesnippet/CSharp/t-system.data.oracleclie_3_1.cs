		private void GetOracleBFile(string connectionString)
		{
			//Create and open the connection.
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				connection.Open();

				//Create and execute the commands.
				OracleCommand command = connection.CreateCommand();
				command.CommandText = "CREATE OR REPLACE DIRECTORY TestDir AS 'c:\\bfiles'";
				command.ExecuteNonQuery();
				command.CommandText = "CREATE TABLE TestTable(col1 number, col2 BFILE)";
				command.ExecuteNonQuery();
				command.CommandText = "INSERT INTO TestTable VALUES ('2', BFILENAME('TESTDIR', 'File.jpg'))";
				command.ExecuteNonQuery();
				command.CommandText = "SELECT * FROM TestTable";

				//Read the BFile data.
				byte[] buffer = new byte[100];
				OracleDataReader dataReader = command.ExecuteReader();
				using (dataReader)
				{
					if (dataReader.Read())
					{
						OracleBFile BFile = dataReader.GetOracleBFile(1);
						using (BFile)
						{
							BFile.Seek(0, SeekOrigin.Begin);
							BFile.Read(buffer, 0, 100);
						}
					}
				}
			}
			return;
		}