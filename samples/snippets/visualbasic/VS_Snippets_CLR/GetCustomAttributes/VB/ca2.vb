' <Snippet2>
Imports System
Imports System.Reflection
Imports System.ComponentModel

' Give the Module some attributes.
<Module: Description("A sample description")> 

' Make the CLSCompliant attribute False.
' The CLSCompliant attribute is applicable for /target:module.
<Module: CLSCompliant(False)> 

Module DemoModule

    Sub Main()
        ' Get the Module type to access its metadata.
        Dim modType As Reflection.Module = GetType(DemoModule).Module
        Dim attr As Attribute
        ' Iterate through all the attributes for the module.
        For Each attr In Attribute.GetCustomAttributes(modType)
            ' Check for the Description attribute.
            If TypeOf attr Is DescriptionAttribute Then
                ' Convert the attribute to access its data.
                Dim descAttr As DescriptionAttribute = _
                    CType(attr, DescriptionAttribute)
                Console.WriteLine("Module {0} has the description ""{1}"".", _
                    modType.Name, descAttr.Description)

            ' Check for the CLSCompliant attribute.
            ElseIf TypeOf attr Is CLSCompliantAttribute Then
                ' Convert the attribute to access its data.
                Dim CLSCompAttr As CLSCompliantAttribute = _
                    CType(attr, CLSCompliantAttribute)
                Dim strCompliant As String
                If CLSCompAttr.IsCompliant Then
                    strCompliant = "is"
                Else
                    strCompliant = "is not"
                End If
                Console.WriteLine("Module {0} {1} CLSCompliant.", _
                    modType.Name, strCompliant)
            End If
        Next
    End Sub
End Module

' Output:
' Module CustAttrs2VB.exe has the description "A sample description".
' Module CustAttrs2VB.exe is not CLSCompliant.
' </Snippet2>
