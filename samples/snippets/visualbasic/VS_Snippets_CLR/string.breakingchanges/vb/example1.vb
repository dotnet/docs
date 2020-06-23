' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Enum StringComparisonResult As Integer
    precedes = -1
    equals = 0
    follows = 1
End Enum

Module Example
    Public Sub Main()
        Dim str1 As String = ChrW(&h219) + ChrW(&h21B) + "a"
        Dim str2 As String = "a"

        Console.WriteLine("{0} {1} {2} in the sort order.", _
                          str1, _
                          CType(String.Compare(str1, str2, StringComparison.CurrentCulture), StringComparisonResult), _
                          str2)
    End Sub
End Module
' </Snippet1>
