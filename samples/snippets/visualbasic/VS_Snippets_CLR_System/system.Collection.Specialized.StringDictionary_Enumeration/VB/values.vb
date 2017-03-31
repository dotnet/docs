' The following code example enumerates the elements of a StringDictionary.

' <snippet2>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesStringDictionary
    Public Shared Sub Main()
        ' Creates and initializes a new StringDictionary.
        Dim myCol As New StringDictionary()
        myCol.Add( "red", "rojo" )
        myCol.Add( "green", "verde" )
        myCol.Add( "blue", "azul" )

        Console.WriteLine("VALUES")
        For Each val As String In myCol.Values
            Console.WriteLine(val)
        Next val
    End Sub
End Class

' This code produces the following output.
'
' VALUES
' verde
' rojo
' azul
' </snippet2>
