<JustInTimeActivation(False)>  _
Public Class JITAAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the JustInTimeActivationAttribute applied to the class.
        Dim attribute As JustInTimeActivationAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(JustInTimeActivationAttribute), False), JustInTimeActivationAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("JustInTimeActivationAttribute.Value: " & attribute.Value)
    
    End Sub 'ValueExample
End Class 'JITAAttribute_Value