		static void Main(string[] args)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
				
					//Create an enlistment object
					myEnlistmentClass myElistment = new myEnlistmentClass();

					//Enlist on the current transaction with the enlistment object
					Transaction.Current.EnlistVolatile(myElistment, EnlistmentOptions.None);

					//Perform transactional work here.

					//Call complete on the TransactionScope based on console input
	                    			ConsoleKeyInfo c;
					while(true)
	                    			{
						Console.Write("Complete the transaction scope? [Y|N] ");
						c = Console.ReadKey();
						Console.WriteLine();
				
		                        			if ((c.KeyChar == 'Y') || (c.KeyChar == 'y'))
						{
							scope.Complete();
							break;
						}
						else if ((c.KeyChar == 'N') || (c.KeyChar == 'n'))
						{
							break;
						}
					}
				}
			}
			catch (System.Transactions.TransactionException ex)
			{
				Console.WriteLine(ex);
			}
			catch
			{
				Console.WriteLine("Cannot complete transaction");
				throw;
			}
		}

		class myEnlistmentClass : IEnlistmentNotification
		{
			public void Prepare(PreparingEnlistment preparingEnlistment)
			{
				Console.WriteLine("Prepare notification received");

				//Perform transactional work

				//If work finished correctly, reply prepared
				preparingEnlistment.Prepared();

				// otherwise, do a ForceRollback
				preparingEnlistment.ForceRollback();
			}

			public void Commit(Enlistment enlistment)
			{
				Console.WriteLine("Commit notification received");

				//Do any work necessary when commit notification is received

				//Declare done on the enlistment
				enlistment.Done();
			}

			public void Rollback(Enlistment enlistment)
			{
				Console.WriteLine("Rollback notification received");

				//Do any work necessary when rollback notification is received

				//Declare done on the enlistment
				enlistment.Done();
			}

			public void InDoubt(Enlistment enlistment)
			{
				Console.WriteLine("In doubt notification received");

				//Do any work necessary when indout notification is received
				
				//Declare done on the enlistment
				enlistment.Done();
			}
		}