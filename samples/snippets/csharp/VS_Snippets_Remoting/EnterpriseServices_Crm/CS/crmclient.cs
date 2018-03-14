// <snippet30>
using System;

public class CrmClient
{

    public static void Main ()
    {

        // Create a new account object. The object is created in a COM+ server application.
        Account account = new Account();

        // Transactionally debit the account.
        try
        {
            account.Filename = System.IO.Path.GetFullPath("JohnDoe");
            account.AllowCommit = true;
            account.DebitAccount(3);
        }
        finally
        {
            account.Dispose();
        }
          
    }

}
// </snippet30>
