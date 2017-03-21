Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

Public Class AutoCompleteAttribute_Example
    Inherits ServicedComponent
    
    <AutoComplete()>  _
    Public Sub AutoCompleteAttribute_Ctor() 
    
    End Sub 'AutoCompleteAttribute_Ctor

    <AutoComplete(True)>  _
    Public Sub AutoCompleteAttribute_Ctor_Bool() 
    
    End Sub 'AutoCompleteAttribute_Ctor_Bool

    <AutoComplete(False)>  _
    Public Sub AutoCompleteAttribute_Value() 
        ' Get information on the member.
        Dim memberinfo As System.Reflection.MemberInfo() = Me.GetType().GetMember("AutoCompleteAttribute_Value")
        
        ' Get the AutoCompleteAttribute applied to the member.
        Dim attribute As AutoCompleteAttribute = CType(System.Attribute.GetCustomAttribute(memberinfo(0), GetType(AutoCompleteAttribute), False), AutoCompleteAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("AutoCompleteAttribute.Value: " & attribute.Value)
    
    End Sub 'AutoCompleteAttribute_Value

End Class 'AutoCompleteAttribute_Example
