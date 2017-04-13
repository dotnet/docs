
Imports System
Public Class SnippetClass
    '<Snippet1>
    Public Sub Method()
        Console.WriteLine("Hello World!")
    End Sub
    '</Snippet1>


    '<Snippet2>
    Public Sub Method(ByVal condition As Boolean)
        If (condition) Then
            Console.WriteLine("Hello World!")
        End If
    End Sub
    '</Snippet2>


    '<Snippet3>

    Public Sub Method(ByVal condition1 As Boolean, ByVal condition2 As Boolean)
        If (condition1 OrElse condition2) Then
            Console.WriteLine("Hello World!")
        End If
    End Sub
    '</Snippet3>


    '<Snippet4>

    Public Sub Method(ByVal day As DayOfWeek)
        Select Case day
            Case DayOfWeek.Monday
                Console.WriteLine("Today is Monday!")
            Case DayOfWeek.Tuesday
                Console.WriteLine("Today is Tuesday!")
            Case DayOfWeek.Wednesday
                Console.WriteLine("Today is Wednesday!")
            Case DayOfWeek.Thursday
                Console.WriteLine("Today is Thursday!")
            Case DayOfWeek.Friday
                Console.WriteLine("Today is Friday!")
            Case DayOfWeek.Saturday
                Console.WriteLine("Today is Saturday!")
            Case DayOfWeek.Sunday
                Console.WriteLine("Today is Sunday!")
        End Select
    End Sub

    '</Snippet4>

End Class

