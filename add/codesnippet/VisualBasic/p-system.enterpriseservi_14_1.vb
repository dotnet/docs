<Transaction(TransactionOption.RequiresNew)>  _
Public Class TransactionAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the TransactionAttribute applied to the class.
        Dim attribute As TransactionAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(TransactionAttribute), False), TransactionAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("TransactionAttribute.Value: " & attribute.Value)
    
    End Sub 'ValueExample
End Class 'TransactionAttribute_Value