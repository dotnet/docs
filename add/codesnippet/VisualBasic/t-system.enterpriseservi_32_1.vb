<Transaction()>  _
Public Class TransactionalComponent
    Inherits ServicedComponent
    
    
    Public Sub TransactionalMethod(ByVal data As String) 
        
        ContextUtil.DeactivateOnReturn = True
        ContextUtil.MyTransactionVote = TransactionVote.Abort
        
        ' Do work with data. Return if any errors occur.
        ' Vote to commit. If any errors occur, this code will not execute.
        ContextUtil.MyTransactionVote = TransactionVote.Commit
    
    End Sub 'TransactionalMethod 
End Class 'TransactionalComponent
