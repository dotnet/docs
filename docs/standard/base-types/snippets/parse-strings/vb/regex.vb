' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

Module RegExExamples
    Public Sub Example1()
        ' <Snippet1>
        Dim expressions() As String = {"16 + 21", "31 * 3", "28 / 3",
                                      "42 - 18", "12 * 7",
                                      "2, 4, 6, 8"}

        Dim pattern As String = "(\d+)\s+([-+*/])\s+(\d+)"
        For Each expression In expressions
            For Each m As Match In Regex.Matches(expression, pattern)
                Dim value1 As Integer = Int32.Parse(m.Groups(1).Value)
                Dim value2 As Integer = Int32.Parse(m.Groups(3).Value)
                Select Case m.Groups(2).Value
                    Case "+"
                        Console.WriteLine("{0} = {1}", m.Value, value1 + value2)
                    Case "-"
                        Console.WriteLine("{0} = {1}", m.Value, value1 - value2)
                    Case "*"
                        Console.WriteLine("{0} = {1}", m.Value, value1 * value2)
                    Case "/"
                        Console.WriteLine("{0} = {1:N2}", m.Value, value1 / value2)
                End Select
            Next
        Next

        ' The example displays the following output:
        '       16 + 21 = 37
        '       31 * 3 = 93
        '       28 / 3 = 9.33
        '       42 - 18 = 24
        '       12 * 7 = 84
        ' </Snippet1>
    End Sub

    Public Sub Example2()
        ' <Snippet2>
        Dim input As String = String.Format("[This is captured{0}text.]" +
                                          "{0}{0}[{0}[This is more " +
                                          "captured text.]{0}{0}" +
                                          "[Some more captured text:" +
                                          "{0}   Option1" +
                                          "{0}   Option2][Terse text.]",
                                          vbCrLf)
        Dim pattern As String = "\[([^\[\]]+)\]"
        Dim ctr As Integer = 0
        For Each m As Match In Regex.Matches(input, pattern)
            ctr += 1
            Console.WriteLine("{0}: {1}", ctr, m.Groups(1).Value)
        Next

        ' The example displays the following output:
        '       1: This is captured
        '       text.
        '       2: This is more captured text.
        '       3: Some more captured text:
        '          Option1
        '          Option2
        '       4: Terse text.
        ' </Snippet2>
    End Sub


    Public Sub Example3()
        ' <Snippet3>
        Dim input As String = "abacus -- alabaster - * - atrium -+- " +
                            "any -*- actual - + - armoire - - alarm"
        Dim pattern As String = "\s-\s?[+*]?\s?-\s"
        Dim elements() As String = Regex.Split(input, pattern)
        For Each element In elements
            Console.WriteLine(element)
        Next

        ' The example displays the following output:
        '       abacus
        '       alabaster
        '       atrium
        '       any
        '       actual
        '       armoire
        '       alarm
        ' </Snippet3>
    End Sub
End Module

