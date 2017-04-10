<%@ Page language="VB" Transaction="Required" %>
<% @ Import Namespace = "System.EnterpriseServices"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="VB" runat="server">

'    System.Web.UI.TemplateControl.OnAbortTransaction;System.Web.UI.TemplateControl.OnCommitTransaction;
'    System.Web.UI.TemplateControl.AbortTransaction;System.Web.UI.TemplateControl.CommitTransaction

'   The following example demonstrates the methods 'OnAbortTransaction','OnCommitTransaction' and
'   events 'AbortTransaction' and 'CommitTransaction' of class 'TemplateControl'.
   
'   Note that since 'TemplateControl' is abstract,this example uses 'Page' class which derives from 'TemplateControl'
'   class. When the page load event occurs two event handlers are added to handle the  'AbortTransaction' and 
'   'CommitTransaction' events raised by  'OnAbortTransaction'  and 'OnCommitTransaction' methods respectively.
'   Account is a dummy class that supports a Debit operation which is transactional and has to execute as 
'   an atomic operation. If any exception is raised during this operation the transaction is aborted.

     public class Account 

   Sub New()

   End Sub
           
   
   public Sub Debit(Amount As Integer) 
   
      ' Do some database work. Any exception thrown here aborts the transaction; 
      ' otherwise, transaction commits.
      
      ' Some error occured, throw an exception.
      throw new Exception()
      ' Comment the above line of code to commit the transaction.
   End Sub
   End Class

' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>

   private Sub Page_Load(Sender As Object, e As EventArgs)

   AddHandler Me.myCommitTransaction,AddressOf Sub_CommitTransaction
   AddHandler Me.myAbortTransaction,AddressOf Sub_AbortTransaction

      try
   
      Dim myAccount As Account = New Account()
      Dim someAmount As Integer = 500
      myAccount.Debit(someAmount)
      ContextUtil.SetComplete()
   
   catch e1 As Exception
         ContextUtil.SetAbort()
   End Try
  End Sub

Public event myCommitTransaction As System.EventHandler 
 Public event myAbortTransaction As System.EventHandler
 
 protected overrides Sub  OnCommitTransaction(e As EventArgs )
  
       RaiseEvent myCommitTransaction(Me ,e)
       Response.Write("<br /><br />The 'OnCommitTransaction()' method is used to raise the 'CommitTransaction' event." )

End Sub
  
  protected  overrides Sub OnAbortTransaction(e As EventArgs)
       RaiseEvent myAbortTransaction(Me ,e)
       Response.Write("<br /><br />The 'OnAbortTransaction()' method is used to raise the 'AbortTransaction' event." )
  End Sub

private Sub Sub_AbortTransaction(Sender As Object, e As EventArgs)
  ' Code for RollBack activity goes here.
   Response.Write("Transaction Aborted")
End Sub

private Sub Sub_CommitTransaction(Sender As Object, e As EventArgs)
  ' Code for Commit Activity goes here.
   Response.Write("Transaction Commited")
End Sub

' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>            
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
   </head>
   <body></body>
</html>
