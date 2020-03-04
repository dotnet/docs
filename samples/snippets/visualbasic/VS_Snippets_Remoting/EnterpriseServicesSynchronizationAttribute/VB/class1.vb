' <snippet0>
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
' This is equivalent to [Synchronization(SynchronizationOption.Required)].
<Synchronization()>  _
Public Class SynchronizationAttribute_Ctor
    Inherits ServicedComponent
End Class
' </snippet1>

' <snippet2>
<Synchronization(SynchronizationOption.Disabled)>  _
Public Class SynchronizationAttribute_Ctor_SynchronizationOption
    Inherits ServicedComponent
End Class
' </snippet2>

' <snippet3>
<Synchronization(SynchronizationOption.RequiresNew)>  _
Public Class SynchronizationAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the SynchronizationAttribute applied to the class.
        Dim attribute As SynchronizationAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(SynchronizationAttribute), False), SynchronizationAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("SynchronizationAttribute.Value: " & attribute.Value)
    
    End Sub
End Class
' </snippet3>

' </snippet0>

' Test client.
Public Class SynchronizationAttribute_Example
    
    Public Shared Sub Main() 
        ' Create a new instance of each example class.
        Dim valueExample As New SynchronizationAttribute_Value()
        
        ' Demonstrate the SynchronizationAttribute properties.
        valueExample.ValueExample()
    
    End Sub
End Class