' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

<Assembly: CLSCompliant(True)>
Module modMain
    Public Sub Main()
        Console.WriteLine("* quantifier:")
        ShowStar()
        Console.WriteLine()
        Console.WriteLine("+ quantifier:")
        ShowPlus()
        Console.WriteLine()
        Console.WriteLine("? quantifier:")
        ShowQuestion()
        Console.WriteLine()
        Console.WriteLine("{n} quantifier:")
        ShowN()
        Console.WriteLine()
        Console.WriteLine("{n,} quantifier:")
        ShowNComma()
        Console.WriteLine()
        Console.WriteLine("{n,m} quantifier:")
        ShowNM()
        Console.WriteLine()
        Console.WriteLine("*? quantifier:")
        ShowLazyStar()
        Console.WriteLine()
        Console.WriteLine("+? quantifier:")
        ShowLazyPlus()
        Console.WriteLine()
        Console.WriteLine("?? quantifier:")
        ShowLazyQuestion()
        Console.WriteLine()
        Console.WriteLine("{n}? quantifier:")
        ShowLazyN()
        Console.WriteLine()
        Console.WriteLine("{n,}? quantifier: NO EXAMPLE")
        ShowLazyNComma()
        Console.WriteLine()
        Console.WriteLine("{n,m}? quantifier:")
        ShowLazyNM()
    End Sub

    Private Sub ShowStar()
        ' <Snippet1>
        Dim pattern As String = "\b91*9*\b"
        Dim input As String = "99 95 919 929 9119 9219 999 9919 91119"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       '99' found at position 0.
        '       '919' found at position 6.
        '       '9119' found at position 14.
        '       '999' found at position 24.
        '       '91119' found at position 33.
        ' </Snippet1>
    End Sub

    Private Sub ShowPlus()
        ' <Snippet2>
        Dim pattern As String = "\ban+\w*?\b"

        Dim input As String = "Autumn is a great time for an annual announcement to all antique collectors."
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       'an' found at position 27.
        '       'annual' found at position 30.
        '       'announcement' found at position 37.
        '       'antique' found at position 57.
        ' </Snippet2>
    End Sub

    Private Sub ShowQuestion()
        ' <Snippet3>
        Dim pattern As String = "\ban?\b"
        Dim input As String = "An amiable animal with a large snout and an animated nose."
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       'An' found at position 0.
        '       'a' found at position 23.
        '       'an' found at position 42.
        ' </Snippet3>
    End Sub

    Private Sub ShowN()
        ' <Snippet4>
        Dim pattern As String = "\b\d+\,\d{3}\b"
        Dim input As String = "Sales totaled 103,524 million in January, " + _
                              "106,971 million in February, but only " + _
                              "943 million in March."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       '103,524' found at position 14.
        '       '106,971' found at position 45.
        ' </Snippet4>
    End Sub

    Private Sub ShowNComma()
        ' <Snippet5>
        Dim pattern As String = "\b\d{2,}\b\D+"
        Dim input As String = "7 days, 10 weeks, 300 years"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       '10 weeks, ' found at position 8.
        '       '300 years' found at position 18.
        ' </Snippet5>
    End Sub

    Private Sub ShowNM()
        ' <Snippet6>
        Dim pattern As String = "(00\s){2,4}"
        Dim input As String = "0x00 FF 00 00 18 17 FF 00 00 00 21 00 00 00 00 00"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       '00 00 ' found at position 8.
        '       '00 00 00 ' found at position 23.
        '       '00 00 00 00 ' found at position 35.
        ' </Snippet6>
    End Sub

    Private Sub ShowLazyStar()
        ' <Snippet7>
        Dim pattern As String = "\b\w*?oo\w*?\b"
        Dim input As String = "woof root root rob oof woo woe"
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       'woof' found at position 0.
        '       'root' found at position 5.
        '       'root' found at position 10.
        '       'oof' found at position 19.
        '       'woo' found at position 23.
        ' </Snippet7>
    End Sub

    Private Sub ShowLazyPlus()
        ' <Snippet8>
        Dim pattern As String = "\b\w+?\b"
        Dim input As String = "Aa Bb Cc Dd Ee Ff"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       'Aa' found at position 0.
        '       'Bb' found at position 3.
        '       'Cc' found at position 6.
        '       'Dd' found at position 9.
        '       'Ee' found at position 12.
        '       'Ff' found at position 15.
        ' </Snippet8>
    End Sub

    Private Sub ShowLazyQuestion()
        ' <Snippet9>
        Dim pattern As String = "^\s*(System.)??Console.Write(Line)??\(??"
        Dim input As String = "System.Console.WriteLine(""Hello!"")" + vbCrLf + _
                              "Console.Write(""Hello!"")" + vbCrLf + _
                              "Console.WriteLine(""Hello!"")" + vbCrLf + _
                              "Console.ReadLine()" + vbCrLf + _
                              "   Console.WriteLine"
        For Each match As Match In Regex.Matches(input, pattern, _
                                                 RegexOptions.IgnorePatternWhitespace Or RegexOptions.IgnoreCase Or RegexOptions.MultiLine)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       'System.Console.Write' found at position 0.
        '       'Console.Write' found at position 36.
        '       'Console.Write' found at position 61.
        '       '   Console.Write' found at position 110.
        ' </Snippet9>
    End Sub

    Private Sub ShowLazyN()
        ' <Snippet10>
        Dim pattern As String = "\b(\w{3,}?\.){2}?\w{3,}?\b"
        Dim input As String = "www.microsoft.com msdn.microsoft.com mywebsite mycompany.com"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       'www.microsoft.com' found at position 0.
        '       'msdn.microsoft.com' found at position 18.
        ' </Snippet10>
    End Sub

    Private Sub ShowLazyNComma()
        ' <Snippet11>
        '        Dim pattern As String = "\b\d{2,}\b\D+"
        '        Dim input As String = "7 days, 10 weeks, 300 years"
        '       For Each match As Match In Regex.Matches(input, pattern)
        '          Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        '       Next
        '       ' The example displays the following output:
        '       '       '10 weeks, ' found at position 8.
        '       '       '300 years' found at position 18.
        ' </Snippet11>
    End Sub

    Private Sub ShowLazyNM()
        ' <Snippet12>
        Dim pattern As String = "\b[A-Z](\w*\s?){1,10}?[.!?]"
        Dim input As String = "Hi. I am writing a short note. Its purpose is " + _
                              "to test a regular expression that attempts to find " + _
                              "sentences with ten or fewer words. Most sentences " + _
                              "in this note are short."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '       'Hi.' found at position 0.
        '       'I am writing a short note.' found at position 4.
        '       'Most sentences in this note are short.' found at position 132.
        ' </Snippet12>
    End Sub
End Module

