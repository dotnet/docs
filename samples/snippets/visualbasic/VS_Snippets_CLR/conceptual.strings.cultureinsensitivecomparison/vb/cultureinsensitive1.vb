' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class CompareSample
    Public Shared Sub Main()
        Dim string1 As String = "file"
        Dim string2 As String = "FILE"
        Dim compareResult As Integer
        
        compareResult = String.Compare(string1, string2, _
                                       StringComparison.Ordinal)   
        Console.WriteLine("{0} comparison of '{1}' and '{2}': {3}", 
                          StringComparison.Ordinal, string1, string2, 
                          compareResult) 

        compareResult = String.Compare(string1, string2, 
                                       StringComparison.OrdinalIgnoreCase)
        Console.WriteLine("{0} comparison of '{1}' and '{2}': {3}", 
                          StringComparison.OrdinalIgnoreCase, string1, string2, 
                          compareResult) 
    End Sub
End Class
' The example displays the following output:
'    Ordinal comparison of 'file' and 'FILE': 32
'    OrdinalIgnoreCase comparison of 'file' and 'FILE': 0
' </Snippet1>

