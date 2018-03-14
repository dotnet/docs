'<snippet1>
Imports System
Imports System.Reflection

<Assembly:AssemblyDescriptionAttribute("My Utility")> 

' Note: The suffix "Attribute" can be omitted:
' <Assembly:AssemblyTitle("A title example")>

Public Class Test
    Public Shared Sub Main()

        ' Get the assembly.
        Dim asm As [Assembly] = [Assembly].GetCallingAssembly

        ' Verify that the description is applied.
        Dim aType As Type = GetType(AssemblyDescriptionAttribute)

        Console.WriteLine("Description applied: {0}", _
            asm.IsDefined(aType, False))

    End Sub
End Class

' The output is:
' Description Applied: True
'</snippet1>