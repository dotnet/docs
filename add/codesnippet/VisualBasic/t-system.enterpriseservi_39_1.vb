Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

<MustRunInClientContext()>  _
Public Class MustRunInClientContextAttribute_Ctor
    Inherits ServicedComponent
End Class 'MustRunInClientContextAttribute_Ctor

<MustRunInClientContext(False)>  _
Public Class MustRunInClientContextAttribute_Ctor_Bool
    Inherits ServicedComponent
End Class 'MustRunInClientContextAttribute_Ctor_Bool

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
