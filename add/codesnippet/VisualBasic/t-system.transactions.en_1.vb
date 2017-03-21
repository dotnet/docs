	Public Class EnlistmentClass
		Implements IEnlistmentNotification

		Public Sub Prepare(ByVal myPreparingEnlistment As PreparingEnlistment) Implements System.Transactions.IEnlistmentNotification.Prepare
			Console.WriteLine("Prepare notification received")

			'Perform transactional work
	
			'If work finished correctly, reply with prepared
			myPreparingEnlistment.Prepared()
		End Sub

		Public Sub Commit(ByVal myEnlistment As Enlistment) Implements System.Transactions.IEnlistmentNotification.Commit
			Console.WriteLine("Commit notification received")

			'Do any work necessary when commit notification is received

			'Declare done on the enlistment
			myEnlistment.Done()
		End Sub

		Public Sub Rollback(ByVal myEnlistment As Enlistment) Implements System.Transactions.IEnlistmentNotification.Rollback
			Console.WriteLine("Rollback notification received")

			'Do any work necessary when rollback notification is received

			'Declare done on the enlistment
			myEnlistment.Done()
		End Sub

		Public Sub InDoubt(ByVal myEnlistment As Enlistment) Implements System.Transactions.IEnlistmentNotification.InDoubt
			Console.WriteLine("In doubt notification received")

			'Do any work necessary when indout notification is received

			'Declare done on the enlistment
			myEnlistment.Done()
		End Sub
	End Class