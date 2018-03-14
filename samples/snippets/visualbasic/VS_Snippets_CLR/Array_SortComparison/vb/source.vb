' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class Example

    Private Shared Function CompareDinosByLength( _
        ByVal x As String, ByVal y As String) As Integer

        If x Is Nothing Then
            If y Is Nothing Then 
                ' If x is Nothing and y is Nothing, they're
                ' equal. 
                Return 0
            Else
                ' If x is Nothing and y is not Nothing, y
                ' is greater. 
                Return -1
            End If
        Else
            ' If x is not Nothing...
            '
            If y Is Nothing Then
                ' ...and y is Nothing, x is greater.
                Return 1
            Else
                ' ...and y is not Nothing, compare the 
                ' lengths of the two strings.
                '
                Dim retval As Integer = _
                    x.Length.CompareTo(y.Length)

                If retval <> 0 Then 
                    ' If the strings are not of equal length,
                    ' the longer string is greater.
                    '
                    Return retval
                Else
                    ' If the strings are of equal length,
                    ' sort them with ordinary string comparison.
                    '
                    Return x.CompareTo(y)
                End If
            End If
        End If

    End Function

    Public Shared Sub Main()

        Dim dinosaurs() As String = { _
            "Pachycephalosaurus", _
            "Amargasaurus", _
            "", _
            Nothing, _
            "Mamenchisaurus", _
            "Deinonychus" }
        Display(dinosaurs)

        Console.WriteLine(vbLf & "Sort with generic Comparison(Of String) delegate:")
        Array.Sort(dinosaurs, AddressOf CompareDinosByLength)
        Display(dinosaurs)

    End Sub

    Private Shared Sub Display(ByVal arr() As String)
        Console.WriteLine()
        For Each s As String In arr
            If s Is Nothing Then
                Console.WriteLine("(Nothing)")
            Else
                Console.WriteLine("""{0}""", s)
            End If
        Next
    End Sub
End Class

' This code example produces the following output:
'
'"Pachycephalosaurus"
'"Amargasaurus"
'""
'(Nothing)
'"Mamenchisaurus"
'"Deinonychus"
'
'Sort with generic Comparison(Of String) delegate:
'
'(Nothing)
'""
'"Deinonychus"
'"Amargasaurus"
'"Mamenchisaurus"
'"Pachycephalosaurus"
' </Snippet1>