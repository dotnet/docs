' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<JustInTimeActivation()>  _
Public Class JITAAttribute_Ctor
    Inherits ServicedComponent
End Class 'JITAAttribute_Ctor
' </snippet1>

' <snippet2>
<JustInTimeActivation(False)>  _
Public Class JITAAttribute_Ctor_Bool
    Inherits ServicedComponent
End Class 'JITAAttribute_Ctor_Bool
' </snippet2>

' <snippet3>
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
' </snippet3>

' </snippet0>

' Test client.

Public Class JITAAttribute_Example
    
    Public Shared Sub Main() 
        ' Create a new instance of each example class.
        Dim valueExample As New JITAAttribute_Value()
        
        ' Demonstrate the JustInTimeActivationAttribute properties.
        valueExample.ValueExample()
    
    End Sub 'Main
End Class 'JITAAttribute_Example