' <Snippet1>
Imports System.Reflection

<Assembly: AssemblyTitle("CustAttrs1VB")> 
<Assembly: AssemblyDescription("GetCustomAttributes() Demo")> 
<Assembly: AssemblyCompany("Microsoft")> 

Module Example
    Sub Main()
        ' Get the Assembly type to access its metadata.
        Dim assy As Reflection.Assembly = GetType(Example).Assembly

        ' Iterate through all the attributes for the assembly.
        For Each attr As Attribute In Attribute.GetCustomAttributes(assy)
            ' Check for the AssemblyTitle attribute.
            If TypeOf attr Is AssemblyTitleAttribute Then
                ' Convert the attribute to access its data.
                Dim attrTitle As AssemblyTitleAttribute = _
                    CType(attr, AssemblyTitleAttribute)
                Console.WriteLine("Assembly title is ""{0}"".", _
                    attrTitle.Title)

            ' Check for the AssemblyDescription attribute.
            ElseIf TypeOf attr Is AssemblyDescriptionAttribute Then
                ' Convert the attribute to access its data.
                Dim attrDesc As AssemblyDescriptionAttribute = _
                    CType(attr, AssemblyDescriptionAttribute)
                Console.WriteLine("Assembly description is ""{0}"".", _
                    attrDesc.Description)

            ' Check for the AssemblyCompany attribute.
            ElseIf TypeOf attr Is AssemblyCompanyAttribute Then
                ' Convert the attribute to access its data.
                Dim attrComp As AssemblyCompanyAttribute = _
                    CType(attr, AssemblyCompanyAttribute)
                Console.WriteLine("Assembly company is {0}.", _
                    attrComp.Company)
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'     Assembly company is Microsoft.
'     Assembly description is "GetCustomAttributes() Demo".
'     Assembly title is "CustAttrs1VB".
' </Snippet1>
