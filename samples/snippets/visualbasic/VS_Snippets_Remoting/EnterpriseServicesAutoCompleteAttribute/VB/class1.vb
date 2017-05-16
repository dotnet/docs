' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

Public Class AutoCompleteAttribute_Example
    Inherits ServicedComponent
    
    ' <snippet1>
    <AutoComplete()>  _
    Public Sub AutoCompleteAttribute_Ctor() 
    
    End Sub 'AutoCompleteAttribute_Ctor
    ' </snippet1>

    ' <snippet2>
    <AutoComplete(True)>  _
    Public Sub AutoCompleteAttribute_Ctor_Bool() 
    
    End Sub 'AutoCompleteAttribute_Ctor_Bool
    ' </snippet2>

    ' <snippet3>
    <AutoComplete(False)>  _
    Public Sub AutoCompleteAttribute_Value() 
        ' Get information on the member.
        Dim memberinfo As System.Reflection.MemberInfo() = Me.GetType().GetMember("AutoCompleteAttribute_Value")
        
        ' Get the AutoCompleteAttribute applied to the member.
        Dim attribute As AutoCompleteAttribute = CType(System.Attribute.GetCustomAttribute(memberinfo(0), GetType(AutoCompleteAttribute), False), AutoCompleteAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("AutoCompleteAttribute.Value: " & attribute.Value)
    
    End Sub 'AutoCompleteAttribute_Value
    ' </snippet3>

End Class 'AutoCompleteAttribute_Example

' </snippet0>

' Test client.

Public Class TestClient

    Public Shared Sub Main()
        ' Create a new instance of the class.
        'Dim example As New AutoCompleteAttribute_Example

        ' Demonstrate the AutoCompleteAttribute properties.
        'example.AutoCompleteAttribute_Value()

    End Sub 'Main
End Class 'TestClient