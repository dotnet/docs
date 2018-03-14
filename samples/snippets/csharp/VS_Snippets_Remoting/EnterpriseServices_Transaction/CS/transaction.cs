using System.EnterpriseServices;

[assembly: System.Reflection.AssemblyKeyFile("Transaction.snk")]
// <snippet1>
[Transaction]
public class TransactionalComponent : ServicedComponent
{

    public void TransactionalMethod (string data)
    {

      ContextUtil.DeactivateOnReturn = true;
      ContextUtil.MyTransactionVote = TransactionVote.Abort;

      // Do work with data. Return if any errors occur.

      // Vote to commit. If any errors occur, this code will not execute.
      ContextUtil.MyTransactionVote = TransactionVote.Commit;

    }

}
// </snippet1>
