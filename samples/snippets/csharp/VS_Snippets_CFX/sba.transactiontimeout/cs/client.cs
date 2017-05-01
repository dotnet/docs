// <snippet5>
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Transactions;

namespace Microsoft.WCF.Documentation
{

  public class Client
  {
    public static void Main()
    {
      // Picks up configuration from the config file.
      BehaviorServiceClient wcfClient 
        = new BehaviorServiceClient("NetTcpBinding_IBehaviorService");
      // Create a transaction to flow
      TransactionOptions transactionOptions = new TransactionOptions();
      transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
      using (TransactionScope tx 
        = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions)
      )
      {
        try
        {
          // Making calls.
          Console.Write("Enter to send some work: ");
          Console.ReadLine();
          Console.WriteLine("The service responded: " + wcfClient.TxWork("Hello from the client."));
          // Write the tx information.
          System.Transactions.TransactionInformation info 
            = System.Transactions.Transaction.Current.TransactionInformation;
          Console.WriteLine("The distributed tx ID: {0}.", info.DistributedIdentifier);
          Console.WriteLine("The tx status: {0}.", info.Status);
          Console.WriteLine("Committing transaction");
          tx.Complete();
          Console.WriteLine("Done!");
          Console.Read();
        }
        catch (TimeoutException)
        {
          Console.WriteLine("The call failed to complete within the timeout period.");
          wcfClient.Abort();
        }
        catch (TransactionException txException)
        {
          if (txException.InnerException is TimeoutException)
            Console.WriteLine("The transaction scope timeout period was exceeded before it was able to commit.");
          else
            Console.WriteLine("A transaction problem has occurred: {0}", txException.Message);
          wcfClient.Abort();
        }
        catch (FaultException unknown)
        {
          Console.WriteLine("Unknown fault exception.");
          Console.WriteLine(unknown.Message);
          Console.WriteLine(unknown.StackTrace);
          wcfClient.Abort();
        }
        catch (CommunicationException commProblem)
        {
          Console.WriteLine("Something went wrong during communication: {0}", commProblem.Message);
          wcfClient.Abort();
        }
        finally
        {
          Console.WriteLine("Press ENTER to exit:");
          Console.ReadLine();
        }
      }
    }
  }
}
// </snippet5>
