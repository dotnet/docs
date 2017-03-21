Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

<LoadBalancingSupported()>  _
Public Class LoadBalancingSupportedAttribute_Ctor
    Inherits ServicedComponent
End Class 'LoadBalancingSupportedAttribute_Ctor

<LoadBalancingSupported(False)>  _
Public Class LoadBalancingSupportedAttribute_Ctor_Bool
    Inherits ServicedComponent
End Class 'LoadBalancingSupportedAttribute_Ctor_Bool

<LoadBalancingSupported(False)>  _
Public Class LoadBalancingSupportedAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the LoadBalancingSupportedAttribute applied to the class.
        Dim attribute As LoadBalancingSupportedAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(LoadBalancingSupportedAttribute), False), LoadBalancingSupportedAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("LoadBalancingSupportedAttribute.Value: " & attribute.Value)
    
    End Sub 'ValueExample
End Class 'LoadBalancingSupportedAttribute_Value
