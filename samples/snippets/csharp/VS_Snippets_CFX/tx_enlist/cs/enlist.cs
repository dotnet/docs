//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
//
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Transactions;

namespace Microsoft.Samples.Transactions.Quickstarts
{
	// A simple usage of transactions with the using statement
	class VolatileEnlist
	{
		//<snippet1>
		static void Main(string[] args)
		{
			try
			{
				using (TransactionScope scope = new TransactionScope())
				{

					//Create an enlistment object
					myEnlistmentClass myEnlistment = new myEnlistmentClass();

					//Enlist on the current transaction with the enlistment object
					Transaction.Current.EnlistVolatile(myEnlistment, EnlistmentOptions.None);

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

		//<snippet2>
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

				//Do any work necessary when in doubt notification is received

				//Declare done on the enlistment
				enlistment.Done();
			}
		}
		//</snippet2>
	//</snippet1>
	}
}
