<EventTrackingEnabled(False)>  _
Public Class EventTrackingEnabledAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the EventTrackingEnabledAttribute applied to the class.
        Dim attribute As EventTrackingEnabledAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(EventTrackingEnabledAttribute), False), EventTrackingEnabledAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("EventTrackingEnabledAttribute.Value: " & attribute.Value)
    
    End Sub 'ValueExample
End Class 'EventTrackingEnabledAttribute_Value