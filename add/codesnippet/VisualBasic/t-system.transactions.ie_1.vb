		Public Shared Sub Main()
			Try
				Using scope As TransactionScope = New TransactionScope()

					'Create an enlistment object
					Dim myEnlistmentClass As New EnlistmentClass

					'Enlist on the current transaction with the enlistment object
					Transaction.Current.EnlistVolatile(myEnlistmentClass, EnlistmentOptions.None)

					'Perform transactional work here.

					'Call complete on the TransactionScope based on console input
					Dim c As ConsoleKeyInfo
					While (True)
						Console.Write("Complete the transaction scope? [Y|N] ")
						c = Console.ReadKey()
						Console.WriteLine()
						If (c.KeyChar = "Y") Or (c.KeyChar = "y") Then
							scope.Complete()
							Exit While
						ElseIf ((c.KeyChar = "N") Or (c.KeyChar = "n")) Then
							Exit While
						End If
					End While
				End Using
			Catch ex As TransactionException
				Console.WriteLine(ex)
			Catch
				Console.WriteLine("Cannot complete transaction")
				Throw
			End Try
		End Sub
	End Class

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
