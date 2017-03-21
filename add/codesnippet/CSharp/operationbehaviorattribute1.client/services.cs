// <snippet2>
using System;
using System.ServiceModel;
using System.Transactions;

namespace Microsoft.WCF.Documentation
{
  [ServiceContract(
    Namespace="http://microsoft.wcf.documentation", 
    SessionMode=SessionMode.Required
  )]
  public interface IBehaviorService
  {
    [OperationContract]
    string TxWork(string message);
  }

  // Note: To use the TransactionIsolationLevel property, you 
  // must add a reference to the System.Transactions.dll assembly.
  /* The following service implementation:
   *   -- Processes messages on one thread at a time
   *   -- Creates one service object per session
   *   -- Releases the service object when the transaction commits
   */
  [ServiceBehavior(
    ConcurrencyMode=ConcurrencyMode.Single,
    InstanceContextMode=InstanceContextMode.PerSession,
    ReleaseServiceInstanceOnTransactionComplete=true
  )]
  public class BehaviorService : IBehaviorService, IDisposable
  {
    Guid myID;

    public BehaviorService()
    {
      myID = Guid.NewGuid();
      Console.WriteLine(
        "Object "
        + myID.ToString()
        + " created.");
    }

    /*
     * The following operation-level behaviors are specified:
     *   -- The executing transaction is committed when
     *        the operation completes without an 
     *        unhandled exception
     *   -- Always executes under a flowed transaction.
     */
    [OperationBehavior(
      TransactionAutoComplete = true,
      TransactionScopeRequired = true
    )]
    [TransactionFlow(TransactionFlowOption.Mandatory)]
    public string TxWork(string message)
    {
      // Do some transactable work.
      Console.WriteLine("TxWork called with: " + message);
      // Display transaction information.

      TransactionInformation info = Transaction.Current.TransactionInformation;
      Console.WriteLine("The distributed tx ID: {0}.", info.DistributedIdentifier);
      Console.WriteLine("The tx status: {0}.", info.Status);
      return String.Format("Hello. This was object {0}.",myID.ToString()) ;
    }

    public void Dispose()
    {
      Console.WriteLine(
        "Service "
        + myID.ToString()
        + " is being recycled."
      );
    }
  }
}
// </snippet2>
