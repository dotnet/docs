<Transaction(Isolation := TransactionIsolationLevel.Serializable)>  _
Public Class TransactionAttribute_Isolation
    Inherits ServicedComponent
    
    Public Sub IsolationExample() 
        ' Get the TransactionAttribute applied to the class.
        Dim attribute As TransactionAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(TransactionAttribute), False), TransactionAttribute)
        
        ' Display the current value of the attribute's Isolation property.
        MsgBox("TransactionAttribute.Isolation: " & attribute.Isolation)
        
        ' Set the Isolation property value of the attribute.
        attribute.Isolation = TransactionIsolationLevel.RepeatableRead
        
        ' Display the new value of the attribute's Isolation property.
        MsgBox("TransactionAttribute.Isolation: " & attribute.Isolation)
    
    End Sub 'IsolationExample
End Class 'TransactionAttribute_Isolation