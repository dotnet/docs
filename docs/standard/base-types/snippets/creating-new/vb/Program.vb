Imports System

' <UsingStringCreate>
Module Program
    Sub Main()
        Dim result As String = String.Create(5, "a"c, Sub(span, firstChar)
                                                           For i As Integer = 0 To span.Length - 1
                                                               span(i) = ChrW(AscW(firstChar) + i)
                                                           Next
                                                       End Sub)

        Console.WriteLine(result) ' abcde
    End Sub
End Module
' </UsingStringCreate>
