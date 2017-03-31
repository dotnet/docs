Imports System
Imports System.Collections.Generic

Public Class ProgStubClass
    Shared Sub Main()
' <Snippet1>
        Dim t As Type = GetType(List(Of String)).GetMethod("ConvertAll").GetGenericArguments()(0).DeclaringType
' </Snippet1>
        Console.WriteLine("Declaring type: {0:s}", t.FullName)
	End Sub
End Class