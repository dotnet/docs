'<snippet1>

Imports System
Imports System.Reflection

' Set an assembly attribute.
<Assembly:AssemblyTitleAttribute("A title example")>

' Note that the suffix "Attribute" can be omitted:
' <Assembly:AssemblyTitle("A title examle")>

Public Class Test
    Public Shared Sub Main()

        ' Get the assembly that is executing this method.
        Dim asm As [Assembly] = [Assembly].GetCallingAssembly

        ' Get the attribute type just defined.
        Dim aType As Type = GetType(AssemblyTitleAttribute)

        Console.WriteLine(asm.IsDefined(aType, false))

        ' Try an attribute not defined.
        aType = GetType(AssemblyVersionAttribute)

        Console.WriteLine(asm.IsDefined(aType, false))

    End Sub
End Class

' This code example produces the following output:
' True
' False
'
'</snippet1>