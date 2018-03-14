
Imports System.EnterpriseServices

<Assembly: System.Reflection.AssemblyKeyFile("Transaction.snk")> 

' <snippet1>
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

' </snippet1>

'added to make it compile
Public Class Test

    Public Shared Sub Main()

    End Sub 'Main
End Class 'Test
