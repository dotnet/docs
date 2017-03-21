
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
