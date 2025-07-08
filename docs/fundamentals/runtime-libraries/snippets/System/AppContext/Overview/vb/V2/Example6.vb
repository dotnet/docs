' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Reflection

<Assembly: AssemblyVersion("2.0.0.0")>

Public Class StringLibrary
   Public Shared Function SubstringStartsAt(fullString As String, substr As String) As Integer
      Return fullString.IndexOf(substr, StringComparison.CurrentCulture)
   End Function
End Class
' </Snippet6>

' <Snippet7>
Public Module Example6
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
'       'archæ' found in 'The archaeologist' starting at position 4
' </Snippet7>
