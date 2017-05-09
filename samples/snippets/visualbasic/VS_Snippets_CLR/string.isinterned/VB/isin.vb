'<snippet1>
' Sample for String.IsInterned(String)
Imports System
Imports System.Text
Imports System.Runtime.CompilerServices

' In the .NET Framework 2.0 the following attribute declaration allows you to 
' avoid the use of the interning when you use NGEN.exe to compile an assembly 
' to the native image cache.
<Assembly: CompilationRelaxations(CompilationRelaxations.NoStringInterning)> 
Class Sample
    Public Shared Sub Main()
        ' String str1 is known at compile time, and is automatically interned.
        Dim str1 As [String] = "abcd"

        ' Constructed string, str2, is not explicitly or automatically interned.
        Dim str2 As [String] = New StringBuilder().Append("wx").Append("yz").ToString()
        Console.WriteLine()
        Test(1, str1)
        Test(2, str2)
    End Sub 'Main

    Public Shared Sub Test(ByVal sequence As Integer, ByVal str As [String])
        Console.Write("{0}) The string, '", sequence)
        Dim strInterned As [String] = [String].IsInterned(str)
        If strInterned Is Nothing Then
            Console.WriteLine("{0}', is not interned.", str)
        Else
            Console.WriteLine("{0}', is interned.", strInterned)
        End If
    End Sub 'Test
End Class 'Sample '

'This example produces the following results:

'1) The string, 'abcd', is interned.
'2) The string, 'wxyz', is not interned.

'If you use NGEN.exe to compile the assembly to the native image cache, this
'example produces the following results:

'1) The string, 'abcd', is not interned.
'2) The string, 'wxyz', is not interned.
'</snippet1>