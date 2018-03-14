' <snippet5>


Imports System
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Transactions

Namespace Microsoft.WCF.Documentation

  Public Class Client
	Public Shared Sub Main()
	  ' Picks up configuration from the config file.
	  Dim wcfClient As New BehaviorServiceClient("NetTcpBinding_IBehaviorService")
	  ' Create a transaction to flow
	  Dim transactionOptions As New TransactionOptions()
	  transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted
	  Using tx As New TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions)
		Try
		  ' Making calls.
		  Console.Write("Enter to send some work: ")
		  Console.ReadLine()
		  Console.WriteLine("The service responded: " & wcfClient.TxWork("Hello from the client."))
		  ' Write the tx information.
		  Dim info As System.Transactions.TransactionInformation = System.Transactions.Transaction.Current.TransactionInformation
		  Console.WriteLine("The distributed tx ID: {0}.", info.DistributedIdentifier)
		  Console.WriteLine("The tx status: {0}.", info.Status)
		  Console.WriteLine("Committing transaction")
		  tx.Complete()
		  Console.WriteLine("Done!")
		  Console.Read()
		Catch e1 As TimeoutException
		  Console.WriteLine("The call failed to complete within the timeout period.")
		  wcfClient.Abort()
		Catch txException As TransactionException
		  If TypeOf txException.InnerException Is TimeoutException Then
			Console.WriteLine("The transaction scope timeout period was exceeded before it was able to commit.")
		  Else
			Console.WriteLine("A transaction problem has occurred: {0}", txException.Message)
		  End If
		  wcfClient.Abort()
		Catch unknown As FaultException
		  Console.WriteLine("Unknown fault exception.")
		  Console.WriteLine(unknown.Message)
		  Console.WriteLine(unknown.StackTrace)
		  wcfClient.Abort()
		Catch commProblem As CommunicationException
		  Console.WriteLine("Something went wrong during communication: {0}", commProblem.Message)
		  wcfClient.Abort()
		Finally
		  Console.WriteLine("Press ENTER to exit:")
		  Console.ReadLine()
		End Try
	  End Using
	End Sub
  End Class
End Namespace
' </snippet5>
