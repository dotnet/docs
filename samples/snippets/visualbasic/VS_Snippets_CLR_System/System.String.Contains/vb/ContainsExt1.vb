' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Runtime.CompilerServices

Module StringExtensions
   <Extension()>
   Public Function Contains(str As String, substring As String, 
                            comp As StringComparison) As Boolean
      If substring Is Nothing Then
         Throw New ArgumentNullException("substring", 
                                         "substring cannot be null.")
      Else If Not [Enum].IsDefined(GetType(StringComparison), comp)
         Throw New ArgumentException("comp is not a member of StringComparison",
                                     "comp")
      End If                               
      Return str.IndexOf(substring, comp) >= 0                      
   End Function
End Module
' </Snippet1>

' <Snippet2>
Public Module Example
   Public Sub Main
      Dim s As String = "This is a string."
      Dim sub1 As String = "this"
      Console.WriteLine("Does '{0}' contain '{1}'?", s, sub1)
      Dim comp As StringComparison = StringComparison.Ordinal
      Console.WriteLine("   {0:G}: {1}", comp, s.Contains(sub1, comp))
      
      comp = StringComparison.OrdinalIgnoreCase
      Console.WriteLine("   {0:G}: {1}", comp, s.Contains(sub1, comp))
   End Sub
End Module
' The example displays the following output:
'       Does 'This is a string.' contain 'this'?
'          Ordinal: False
'          OrdinalIgnoreCase: True
' </Snippet2>