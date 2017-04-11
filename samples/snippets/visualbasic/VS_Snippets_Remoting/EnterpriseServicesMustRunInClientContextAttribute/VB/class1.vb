' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<MustRunInClientContext()>  _
Public Class MustRunInClientContextAttribute_Ctor
    Inherits ServicedComponent
End Class 'MustRunInClientContextAttribute_Ctor
' </snippet1>

' <snippet2>
<MustRunInClientContext(False)>  _
Public Class MustRunInClientContextAttribute_Ctor_Bool
    Inherits ServicedComponent
End Class 'MustRunInClientContextAttribute_Ctor_Bool
' </snippet2>

' <snippet3>
<MustRunInClientContext(False)>  _
Public Class MustRunInClientContextAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the MustRunInClientContextAttribute applied to the class.
        Dim attribute As MustRunInClientContextAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(MustRunInClientContextAttribute), False), MustRunInClientContextAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("MustRunInClientContextAttribute.Value: " & attribute.Value)
    
    End Sub 'ValueExample
End Class 'MustRunInClientContextAttribute_Value
' </snippet3>

' </snippet0>

' Test client.

Public Class MustRunInClientContextAttribute_Example
    
    Public Shared Sub Main() 
        ' Create a new instance of each example class.
        Dim valueExample As New MustRunInClientContextAttribute_Value()
        
        ' Demonstrate the MustRunInClientContextAttribute properties.
        valueExample.ValueExample()
    
    End Sub 'Main
End Class 'MustRunInClientContextAttribute_Example