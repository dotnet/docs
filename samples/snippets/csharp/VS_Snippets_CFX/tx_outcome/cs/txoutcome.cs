using System;
using System.Transactions;

namespace Microsoft.Samples.Transactions.Quickstarts
{
	/// <summary>
	/// Shows how an application can obtain the outcome of a transaction, whether or not it
	/// is the one committing it.
	/// </summary>
	class TxOutcome
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		//<snippet1>
		static void Main(string[] args)
		{
			try
			{
				//Create the transaction scope
				using (TransactionScope scope = new TransactionScope())
				{
					//Register for the transaction completed event for the current transaction
					Transaction.Current.TransactionCompleted += new TransactionCompletedEventHandler(Current_TransactionCompleted);

					//Call complete on the TransactionScope based on console input
					ConsoleKeyInfo c;
					while (true)
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

		//Transaction completed event handler
		static void Current_TransactionCompleted(object sender, TransactionEventArgs e)
		{
			Console.WriteLine("A transaction has completed:");
			Console.WriteLine("ID:             {0}", e.Transaction.TransactionInformation.LocalIdentifier);
			Console.WriteLine("Distributed ID: {0}", e.Transaction.TransactionInformation.DistributedIdentifier);
			Console.WriteLine("Status:         {0}", e.Transaction.TransactionInformation.Status);
			Console.WriteLine("IsolationLevel: {0}", e.Transaction.IsolationLevel);
		}
	//</snippet1>
	}
}