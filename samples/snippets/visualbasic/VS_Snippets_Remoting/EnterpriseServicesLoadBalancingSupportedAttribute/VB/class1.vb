' <snippet0>
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<LoadBalancingSupported()>  _
Public Class LoadBalancingSupportedAttribute_Ctor
    Inherits ServicedComponent
End Class
' </snippet1>

' <snippet2>
<LoadBalancingSupported(False)>  _
Public Class LoadBalancingSupportedAttribute_Ctor_Bool
    Inherits ServicedComponent
End Class
' </snippet2>

' <snippet3>
<LoadBalancingSupported(False)>  _
Public Class LoadBalancingSupportedAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the LoadBalancingSupportedAttribute applied to the class.
        Dim attribute As LoadBalancingSupportedAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(LoadBalancingSupportedAttribute), False), LoadBalancingSupportedAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("LoadBalancingSupportedAttribute.Value: " & attribute.Value)
    
    End Sub
End Class
' </snippet3>

' </snippet0>

' Test client.
Public Class LoadBalancingSupportedAttribute_Example

    Public Shared Sub Main()
        ' Create a new instance of each example class.
        Dim valueExample As New LoadBalancingSupportedAttribute_Value

        ' Demonstrate the LoadBalancingSupportedAttribute properties.
        valueExample.ValueExample()

    End Sub
End Class