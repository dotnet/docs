				//Create a committable transaction
				tx = new CommittableTransaction();

				SqlConnection myConnection = new SqlConnection("server=(local)\\SQLExpress;Integrated Security=SSPI;database=northwind");
				SqlCommand myCommand = new SqlCommand();

				//Open the SQL connection
				myConnection.Open();

				//Give the transaction to SQL to enlist with
				myConnection.EnlistTransaction(tx);

				myCommand.Connection = myConnection;

				// Restore database to near it's original condition so sample will work correctly.
				myCommand.CommandText = "DELETE FROM Region WHERE (RegionID = 100) OR (RegionID = 101)";
				myCommand.ExecuteNonQuery();

				// Insert the first record.
				myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'MidWestern')";
				myCommand.ExecuteNonQuery();

				// Insert the second record.
				myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (101, 'MidEastern')";
				myCommand.ExecuteNonQuery();

				// Commit or rollback the transaction
				while (true)
				{
					Console.Write("Commit or Rollback? [C|R] ");
					ConsoleKeyInfo c = Console.ReadKey();
					Console.WriteLine();

					if ((c.KeyChar == 'C') || (c.KeyChar == 'c'))
					{
						tx.Commit();
						break;
					}
					else if ((c.KeyChar == 'R') || (c.KeyChar == 'r'))
					{
						tx.Rollback();
						break;
					}
				}
				myConnection.Close();
				tx = null;