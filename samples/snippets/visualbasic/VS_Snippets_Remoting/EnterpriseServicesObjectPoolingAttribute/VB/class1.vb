' <snippet0>
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<ObjectPooling(True)>  _
Public Class ObjectPoolingAttribute_Ctor_Bool
    Inherits ServicedComponent
End Class
' </snippet1>

' <snippet2>
<ObjectPooling(True, 1, 10)>  _
Public Class ObjectPoolingAttribute_Ctor_Bool_Int_Int
    Inherits ServicedComponent
End Class
' </snippet2>

' <snippet3>
<ObjectPooling(1, 10)>  _
Public Class ObjectPoolingAttribute_Ctor_Int_Int
    Inherits ServicedComponent
End Class
' </snippet3>

' <snippet4>
<ObjectPooling(False)>  _
Public Class ObjectPoolingAttribute_Enabled
    Inherits ServicedComponent
    
    Public Sub EnabledExample() 
        ' Get the ObjectPoolingAttribute applied to the class.
        Dim attribute As ObjectPoolingAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(ObjectPoolingAttribute), False), ObjectPoolingAttribute)
        
        ' Display the current value of the attribute's Enabled property.
        MsgBox("ObjectPoolingAttribute.Enabled: " & attribute.Enabled)
        
        ' Set the Enabled property value of the attribute.
        attribute.Enabled = True
        
        ' Display the new value of the attribute's Enabled property.
        MsgBox("ObjectPoolingAttribute.Enabled: " & attribute.Enabled)
    
    End Sub
End Class
' </snippet4>

' </snippet0>

' Test client.
Public Class ObjectPoolingAttribute_Example

    Public Shared Sub Main()
        ' Create a new instance of each example class.
        Dim enabledExample As New ObjectPoolingAttribute_Enabled

        ' Demonstrate the ObjectPoolingAttribute properties.
        enabledExample.EnabledExample()

    End Sub
End Class