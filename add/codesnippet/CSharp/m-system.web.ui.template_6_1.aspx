
   private void Page_Load(object sender, System.EventArgs e)
   {
       AbortTransaction += new System.EventHandler(Sub_AbortTransaction);
    CommitTransaction += new System.EventHandler(Sub_CommitTransaction);
       try
    {
       Account myAccount = new Account();
       int someAmount = 500;
       myAccount.Debit(someAmount); 
       ContextUtil.SetComplete(); 
    }
    catch(Exception)
    {
       ContextUtil.SetAbort();
    }
   }

 private void Sub_AbortTransaction(object sender,System.EventArgs e)
 {
    // Code for RollBack activity goes here.
    Response.Write("Transaction Aborted");
 }
 private void Sub_CommitTransaction(object sender,System.EventArgs e)
 {
    // Code for Commit Activity goes here.
    Response.Write("Transaction Commited");
 }