Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' This is equivalent to [Synchronization(SynchronizationOption.Required)].
<Synchronization()>  _
Public Class SynchronizationAttribute_Ctor
    Inherits ServicedComponent
End Class 'SynchronizationAttribute_Ctor

<Synchronization(SynchronizationOption.Disabled)>  _
Public Class SynchronizationAttribute_Ctor_SynchronizationOption
    Inherits ServicedComponent
End Class 'SynchronizationAttribute_Ctor_SynchronizationOption

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
