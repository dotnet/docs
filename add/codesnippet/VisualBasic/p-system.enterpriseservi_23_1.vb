<Transaction(TransactionOption.Required)>  _
Public Class ContextUtil_TransactionId
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display the ID of the transaction in which the current COM+ context
        ' is enlisted.
        MsgBox("Transaction ID: " & ContextUtil.TransactionId.ToString())

    End Sub 'Example
End Class 'ContextUtil_TransactionId