' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Reflection

<Assembly: AssemblyVersion("1.0.0.0")>

Public Class StringLibrary
   Public Shared Function SubstringStartsAt(fullString As String, substr As String) As Integer
      Return fullString.IndexOf(substr, StringComparison.Ordinal)
   End Function
End Class
' </Snippet4>

' <Snippet5>
Public Module Example4
    Public Sub Main()
        Dim value As String = "The archaeologist"
        Dim substring As String = "archæ"
        Dim position As Integer = StringLibrary.SubstringStartsAt(value, substring)
        If position >= 0 Then
            Console.WriteLine("'{0}' found in '{1}' starting at position {2}",
                        substring, value, position)
        Else
            Console.WriteLine("'{0}' not found in '{1}'", substring, value)
        End If
    End Sub
End Module
' The example displays the following output:
'       'archæ' not found in 'The archaeologist'
' </Snippet5>
