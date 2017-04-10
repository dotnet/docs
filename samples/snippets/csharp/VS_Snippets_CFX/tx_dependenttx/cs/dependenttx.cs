using System;
using System.Transactions;
using System.Threading;

namespace Microsoft.Samples.Transactions.Quickstarts
{
	/// <summary>
	/// A simple usage of transactions with the using statement
	/// </summary>
	class DependentTx
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		//<snippet1>
		static void Main(string[] args)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{
					// Perform transactional work here.

					//Queue work item
					ThreadPool.QueueUserWorkItem(new WaitCallback(WorkerThread), Transaction.Current.DependentClone(DependentCloneOption.BlockCommitUntilComplete));

					//Display transaction information
					Console.WriteLine("Transaction information:");
					Console.WriteLine("ID:             {0}", Transaction.Current.TransactionInformation.LocalIdentifier);
					Console.WriteLine("status:         {0}", Transaction.Current.TransactionInformation.Status);
					Console.WriteLine("isolationlevel: {0}", Transaction.Current.IsolationLevel);

					//Call Complete on the TransactionScope based on console input
					ConsoleKeyInfo c;
					while (true)
					{
                        			Console.Write("Complete the transaction scope? [Y|N] ");
						c = Console.ReadKey();
						Console.WriteLine();

						if ((c.KeyChar == 'Y') || (c.KeyChar == 'y'))
						{
							//Call complete on the scope
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

		private static void WorkerThread(object transaction)
		{
			//Create a DependentTransaction from the object passed to the WorkerThread
			DependentTransaction dTx = (DependentTransaction)transaction;

			//Sleep for 1 second to force the worker thread to delay
			Thread.Sleep(1000);

			//Pass the DependentTransaction to the scope, so that work done in the scope becomes part of the transaction passed to the worker thread
			using (TransactionScope ts = new TransactionScope(dTx))
			{
				//Perform transactional work here.

				//Call complete on the transaction scope
				ts.Complete();
			}

			//Call complete on the dependent transaction
			dTx.Complete();
		}
	//</snippet1>
	}
}
