<Transaction(TransactionOption.Required)>  _
Public Class ContextUtil_DisableCommit
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Set both the consistent bit and the done bit to false for the
        ' current COM+ context.
        ContextUtil.DisableCommit()
    
    End Sub 'Example
End Class 'ContextUtil_DisableCommit