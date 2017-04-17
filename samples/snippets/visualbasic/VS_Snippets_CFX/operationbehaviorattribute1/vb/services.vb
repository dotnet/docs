' <snippet2>
Imports System.ServiceModel
Imports System.Transactions

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://microsoft.wcf.documentation", SessionMode:=SessionMode.Required)> _
  Public Interface IBehaviorService
	<OperationContract> _
	Function TxWork(ByVal message As String) As String
  End Interface

  ' Note: To use the TransactionIsolationLevel property, you 
  ' must add a reference to the System.Transactions.dll assembly.
'   The following service implementation:
'   *   -- Processes messages on one thread at a time
'   *   -- Creates one service object per session
'   *   -- Releases the service object when the transaction commits
'   
    <ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Single, InstanceContextMode:=InstanceContextMode.PerSession, _
                     ReleaseServiceInstanceOnTransactionComplete:=True)> _
    Public Class BehaviorService
        Implements IBehaviorService, IDisposable
        Private myID As Guid

        Public Sub New()
            myID = Guid.NewGuid()
            Console.WriteLine("Object " & myID.ToString() & " created.")
        End Sub

        '    
        '     * The following operation-level behaviors are specified:
        '     *   -- The executing transaction is committed when
        '     *        the operation completes without an 
        '     *        unhandled exception
        '     *   -- Always executes under a flowed transaction.
        '     
        <OperationBehavior(TransactionAutoComplete:=True, TransactionScopeRequired:=True), TransactionFlow(TransactionFlowOption.Mandatory)> _
        Public Function TxWork(ByVal message As String) As String Implements IBehaviorService.TxWork
            ' Do some transactable work.
            Console.WriteLine("TxWork called with: " & message)
            ' Display transaction information.

            Dim info As TransactionInformation = Transaction.Current.TransactionInformation
            Console.WriteLine("The distributed tx ID: {0}.", info.DistributedIdentifier)
            Console.WriteLine("The tx status: {0}.", info.Status)
            Return String.Format("Hello. This was object {0}.", myID.ToString())
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
            Console.WriteLine("Service " & myID.ToString() & " is being recycled.")
        End Sub
    End Class
End Namespace
' </snippet2>
