' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Module Example
   Public Sub Main()
      Dim maleNames() As String = { "Adam", "Bartholomew", "Charles", "David", 
                                    "Earl", "Robert", "Stanley", "Wilberforce" }
      Dim selected() As String = Array.FindAll(maleNames, 
                                               Function(name) 
                                                  Dim fLetter As String = name.Substring(0, 1)
                                                  Return fLetter >= "F" And fLetter <= "M"
                                               End Function)                                  
      For ctr As Integer = 0 To selected.Length - 1
         Console.WriteLine(selected(ctr))
      Next
   End Sub
End Module
' The example displays the following output:
'       Unhandled Exception: 
'       System.IndexOutOfRangeException: 
'       Index was outside the bounds of the array.
'       at Example.Main()
' </Snippet9>
