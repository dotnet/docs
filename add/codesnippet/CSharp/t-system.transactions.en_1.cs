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