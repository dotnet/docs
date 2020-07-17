' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim input As String = "Brooklyn Dodgers, National League, 1911, 1912, 1932-1957" + vbCrLf +
                              "Chicago Cubs, National League, 1903-present" + vbCrLf +
                              "Detroit Tigers, American League, 1901-present" + vbCrLf +
                              "New York Giants, National League, 1885-1957" + vbCrLf +
                              "Washington Senators, American League, 1901-1960" + vbCrLf

        Dim basePattern As String = "^((\w+(\s?)){2,}),\s(\w+\s\w+),(\s\d{4}(-(\d{4}|present))?,?)+"
        Dim match As Match

        Dim pattern As String = basePattern + "$"
        Console.WriteLine("Attempting to match the entire input string:")
        match = Regex.Match(input, pattern)
        Do While match.Success
            Console.Write("The {0} played in the {1} in",
                              match.Groups(1).Value, match.Groups(4).Value)
            For Each capture As Capture In match.Groups(5).Captures
                Console.Write(capture.Value)
            Next
            Console.WriteLine(".")
            match = match.NextMatch()
        Loop
        Console.WriteLine()

        Dim teams() As String = input.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        Console.WriteLine("Attempting to match each element in a string array:")
        For Each team As String In teams
            match = Regex.Match(team, pattern)
            If match.Success Then
                Console.Write("The {0} played in the {1} in",
                               match.Groups(1).Value, match.Groups(4).Value)
                For Each capture As Capture In match.Groups(5).Captures
                    Console.Write(capture.Value)
                Next
                Console.WriteLine(".")
            End If
        Next
        Console.WriteLine()

        Console.WriteLine("Attempting to match each line of an input string with '$':")
        match = Regex.Match(input, pattern, RegexOptions.Multiline)
        Do While match.Success
            Console.Write("The {0} played in the {1} in",
                              match.Groups(1).Value, match.Groups(4).Value)
            For Each capture As Capture In match.Groups(5).Captures
                Console.Write(capture.Value)
            Next
            Console.WriteLine(".")
            match = match.NextMatch()
        Loop
        Console.WriteLine()

        pattern = basePattern + "\r?$"
        Console.WriteLine("Attempting to match each line of an input string with '\r?$':")
        match = Regex.Match(input, pattern, RegexOptions.Multiline)
        Do While match.Success
            Console.Write("The {0} played in the {1} in",
                              match.Groups(1).Value, match.Groups(4).Value)
            For Each capture As Capture In match.Groups(5).Captures
                Console.Write(capture.Value)
            Next
            Console.WriteLine(".")

            match = match.NextMatch()
        Loop
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'    Attempting to match the entire input string:
'    
'    Attempting to match each element in a string array:
'    The Brooklyn Dodgers played in the National League in 1911, 1912, 1932-1957.
'    The Chicago Cubs played in the National League in 1903-present.
'    The Detroit Tigers played in the American League in 1901-present.
'    The New York Giants played in the National League in 1885-1957.
'    The Washington Senators played in the American League in 1901-1960.
'    
'    Attempting to match each line of an input string with '$':
'    
'    Attempting to match each line of an input string with '\r?$':
'    The Brooklyn Dodgers played in the National League in 1911, 1912, 1932-1957.
'    The Chicago Cubs played in the National League in 1903-present.
'    The Detroit Tigers played in the American League in 1901-present.
'    The New York Giants played in the National League in 1885-1957.
'    The Washington Senators played in the American League in 1901-1960.
' </Snippet2>
