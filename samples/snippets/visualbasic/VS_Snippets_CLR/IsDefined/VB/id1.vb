'<Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Add an AssemblyDescription attribute.
<Assembly: AssemblyDescription("A sample description")> 

Module DemoModule
    Sub Main()
        ' Get the assembly for this module.
        Dim assy As System.Reflection.Assembly = GetType(DemoModule).Assembly
        ' Store the assembly name.
        Dim assyName As String = assy.GetName().Name
        ' See if the AssemblyDescription attribute is defined.
        If Attribute.IsDefined(assy, GetType(AssemblyDescriptionAttribute)) _
            Then
            ' Affirm that the attribute is defined. Assume the filename of
            ' this code example is "IsDef1VB".
            Console.WriteLine("The AssemblyDescription attribute is " & _
                "defined for assembly {0}.", assyName)
            ' Get the description attribute itself.
            Dim attr As Attribute = Attribute.GetCustomAttribute( _
                assy, GetType(AssemblyDescriptionAttribute))
            ' Display the description.
            If Not attr Is Nothing And _
                TypeOf attr Is AssemblyDescriptionAttribute Then
                Dim adAttr As AssemblyDescriptionAttribute = _
                    CType(attr, AssemblyDescriptionAttribute)
                Console.WriteLine("The description is " & _
                    Chr(34) & "{0}" & Chr(34) & ".", adAttr.Description)
            Else
                Console.WriteLine("The description could not be retrieved.")
            End If
        Else
            Console.WriteLine("The AssemblyDescription attribute is not " & _
                              "defined for assembly {0}.", assyName)
        End If
    End Sub
End Module

' Output:
' The AssemblyDescription attribute is defined for assembly IsDef1VB.
' The description is "A sample description".
'</Snippet1>
