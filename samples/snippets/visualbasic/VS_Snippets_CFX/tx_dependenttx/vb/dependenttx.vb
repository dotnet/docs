Imports System.Transactions
Imports System
Imports System.Threading

Namespace Microsoft.Samples

	Public NotInheritable Class DependentTx
		'<snippet1>
		Public Shared Sub Main()
			Try
				Using scope As TransactionScope = New TransactionScope()

					'Perform transactional work here.

					'Queue work item
					ThreadPool.QueueUserWorkItem(AddressOf WorkerThread, Transaction.Current.DependentClone(DependentCloneOption.BlockCommitUntilComplete))

					'Display transaction information
					Console.WriteLine("Transaction information:")
					Console.WriteLine("ID:             {0}", Transaction.Current.TransactionInformation.LocalIdentifier)
					Console.WriteLine("status:         {0}", Transaction.Current.TransactionInformation.Status)
					Console.WriteLine("isolationlevel: {0}", Transaction.Current.IsolationLevel)

					'Call Complete on the TransactionScope based on console input
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

		Public Shared Sub WorkerThread(ByVal myTransaction As Object)

			'Create a DependentTransaction from the object passed to the WorkerThread
			Dim dTx As DependentTransaction
			dTx = CType(myTransaction, DependentTransaction)

			'Sleep for 1 second to force the worker thread to delay
			Thread.Sleep(1000)

			'Pass the DependentTransaction to the scope, so that work done in the scope becomes part of the transaction passed to the worker thread
			Using ts As TransactionScope = New TransactionScope(dTx)
				'Perform transactional work here.

				'Call complete on the transaction scope
				ts.Complete()
			End Using

			'Call complete on the dependent transaction
			dTx.Complete()
		End Sub
	'</snippet1>
	End Class
End Namespace