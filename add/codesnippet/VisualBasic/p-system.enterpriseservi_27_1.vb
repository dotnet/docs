<Transaction(Timeout := 30)>  _
Public Class TransactionAttribute_Timeout
    Inherits ServicedComponent
    
    Public Sub TimeoutExample() 
        ' Get the TransactionAttribute applied to the class.
        Dim attribute As TransactionAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(TransactionAttribute), False), TransactionAttribute)
        
        ' Display the current value of the attribute's Timeout property.
        MsgBox("TransactionAttribute.Timeout: " & attribute.Timeout)
        
        ' Set the Timeout property value of the attribute to sixty
        ' seconds.
        attribute.Timeout = 60
        
        ' Display the new value of the attribute's Timeout property.
        MsgBox("TransactionAttribute.Timeout: " & attribute.Timeout)
    
    End Sub 'TimeoutExample
End Class 'TransactionAttribute_Timeout