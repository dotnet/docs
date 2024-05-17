' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Reflection

<Assembly: AssemblyVersion("2.0.0.0")>

Public Class StringLibrary
   Public Shared Function SubstringStartsAt(fullString As String, substr As String) As Integer
      Dim flag As Boolean
      If AppContext.TryGetSwitch("StringLibrary.DoNotUseCultureSensitiveComparison", flag) AndAlso flag = True Then
         Return fullString.IndexOf(substr, StringComparison.Ordinal)
      Else
         Return fullString.IndexOf(substr, StringComparison.CurrentCulture)
      End If   
   End Function
End Class
' </Snippet8>

' <Snippet9>
Public Module Example8
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
' </Snippet9>
