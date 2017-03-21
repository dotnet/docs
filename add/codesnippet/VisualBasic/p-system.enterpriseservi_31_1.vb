<Transaction(TransactionOption.Required)>  _
Public Class ContextUtil_IsInTransaction
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display whether the current COM+ context is enlisted in a
        ' transaction.
        MsgBox("Current context enlisted in transaction: " & ContextUtil.IsInTransaction)

    End Sub 'Example
End Class 'ContextUtil_IsInTransaction