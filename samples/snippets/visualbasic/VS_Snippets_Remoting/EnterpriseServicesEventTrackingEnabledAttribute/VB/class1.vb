' <snippet0>
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<EventTrackingEnabled()>  _
Public Class EventTrackingEnabledAttribute_Ctor
    Inherits ServicedComponent
End Class
' </snippet1>

' <snippet2>
<EventTrackingEnabled(False)>  _
Public Class EventTrackingEnabledAttribute_Ctor_Bool
    Inherits ServicedComponent
End Class
' </snippet2>

' <snippet3>
<EventTrackingEnabled(False)>  _
Public Class EventTrackingEnabledAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the EventTrackingEnabledAttribute applied to the class.
        Dim attribute As EventTrackingEnabledAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(EventTrackingEnabledAttribute), False), EventTrackingEnabledAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("EventTrackingEnabledAttribute.Value: " & attribute.Value)
    
    End Sub
End Class
' </snippet3>

' </snippet0>

' Test client.

Public Class EventTrackingEnabledAttribute_Example
    
    Public Shared Sub Main() 
        ' Create a new instance of each example class.
        Dim valueExample As New EventTrackingEnabledAttribute_Value()
        
        ' Demonstrate the EventTrackingEnabledAttribute properties.
        valueExample.ValueExample()
    
    End Sub
End Class