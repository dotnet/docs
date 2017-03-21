<Transaction(TransactionOption.Required)>  _
Public Class ContextUtil_EnableCommit
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Set the consistent bit to true and the done bit to false for the
        ' current COM+ context.
        ContextUtil.EnableCommit()
    
    End Sub 'Example
End Class 'ContextUtil_EnableCommit