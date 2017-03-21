<Synchronization(SynchronizationOption.RequiresNew)>  _
Public Class SynchronizationAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the SynchronizationAttribute applied to the class.
        Dim attribute As SynchronizationAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(SynchronizationAttribute), False), SynchronizationAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("SynchronizationAttribute.Value: " & attribute.Value)
    
    End Sub 'ValueExample
End Class 'SynchronizationAttribute_Value