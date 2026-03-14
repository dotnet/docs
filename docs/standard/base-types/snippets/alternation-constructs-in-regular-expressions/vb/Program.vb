Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())
        ' <EitherOrCharacterClass>
        Dim pattern1 As String = "\bgr[ae]y\b"
        Dim pattern2 As String = "\bgr(a|e)y\b"

        Dim input As String = "The gray wolf blended in among the grey rocks."
        For Each match As Match In Regex.Matches(input, pattern1)
            Console.WriteLine($"'{match.Value}' found at position {match.Index}")
        Next
        Console.WriteLine()
        For Each match As Match In Regex.Matches(input, pattern2)
            Console.WriteLine($"'{match.Value}' found at position {match.Index}")
        Next
        ' </EitherOrCharacterClass>

        Console.WriteLine()

        ' <EitherOrPatterns>
        Dim eitherOrPattern As String = "\b(\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b"
        Dim eitherOrInput As String = "01-9999999 020-333333 777-88-9999"
        Console.WriteLine($"Matches for {eitherOrPattern}:")
        For Each match As Match In Regex.Matches(eitherOrInput, eitherOrPattern)
            Console.WriteLine($"   {match.Value} at position {match.Index}")
        Next
        ' </EitherOrPatterns>

        Console.WriteLine()

        ' <ConditionalExpression>
        Dim condExprPattern As String = "\b(?(\d{2}-)\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b"
        Dim condExprInput As String = "01-9999999 020-333333 777-88-9999"
        Console.WriteLine($"Matches for {condExprPattern}:")
        For Each match As Match In Regex.Matches(condExprInput, condExprPattern)
            Console.WriteLine($"   {match.Value} at position {match.Index}")
        Next
        ' </ConditionalExpression>

        Console.WriteLine()

        ' <ConditionalNamedGroup>
        Dim namedGroupPattern As String = "\b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b"
        Dim namedGroupInput As String = "01-9999999 020-333333 777-88-9999"
        Console.WriteLine($"Matches for {namedGroupPattern}:")
        For Each match As Match In Regex.Matches(namedGroupInput, namedGroupPattern)
            Console.WriteLine($"   {match.Value} at position {match.Index}")
        Next
        ' </ConditionalNamedGroup>

        Console.WriteLine()

        ' <ConditionalNumberedGroup>
        Dim numberedGroupPattern As String = "\b(\d{2}-)?(?(1)\d{7}|\d{3}-\d{2}-\d{4})\b"
        Dim numberedGroupInput As String = "01-9999999 020-333333 777-88-9999"
        Console.WriteLine($"Matches for {numberedGroupPattern}:")
        For Each match As Match In Regex.Matches(numberedGroupInput, numberedGroupPattern)
            Console.WriteLine($"   {match.Value} at position {match.Index}")
        Next
        ' </ConditionalNumberedGroup>
    End Sub
End Module
