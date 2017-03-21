    <AutoComplete(False)>  _
    Public Sub AutoCompleteAttribute_Value() 
        ' Get information on the member.
        Dim memberinfo As System.Reflection.MemberInfo() = Me.GetType().GetMember("AutoCompleteAttribute_Value")
        
        ' Get the AutoCompleteAttribute applied to the member.
        Dim attribute As AutoCompleteAttribute = CType(System.Attribute.GetCustomAttribute(memberinfo(0), GetType(AutoCompleteAttribute), False), AutoCompleteAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("AutoCompleteAttribute.Value: " & attribute.Value)
    
    End Sub 'AutoCompleteAttribute_Value