<%@ Page language="c#" Transaction="Required" %>
<% @ Import Namespace = "System.EnterpriseServices"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">

/* 
   System.Web.UI.TemplateControl.OnAbortTransaction;System.Web.UI.TemplateControl.OnCommitTransaction;
   System.Web.UI.TemplateControl.AbortTransaction;System.Web.UI.TemplateControl.CommitTransaction
   
    The following example demonstrates the methods 'OnAbortTransaction','OnCommitTransaction' and
   events 'AbortTransaction' and 'CommitTransaction' of class 'TemplateControl'.
   
   Note that since 'TemplateControl' is abstract,this example uses 'Page' class which derives from 'TemplateControl' class
   The above mentioned methods are not called explicitly in the example. They are used internally by the class
   to raise the corresponding event.
   Account is a dummy class that supports a Debit operation which is transactional and has to execute as 
   an atomic operation. If any exception is raised during this operation the transaction is aborted.
*/
public class Account 
 {
    public Account(){}
    
    public void Debit(int amount) 
    {
       // Do some database work.Exception thrown here aborts the transaction ,else commits transaction.
       
       // Some error occured, throw an exception.
       throw new Exception();
       // Comment the above line of code to commit the transaction.
    }
 }
 
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>

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
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>    
 </script>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>ASP.NET Example</title>
  </head>
  <body></body>
</html>
