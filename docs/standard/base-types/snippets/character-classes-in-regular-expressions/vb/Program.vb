Imports System
Imports System.Text.RegularExpressions

Module Program
    Sub Main(args As String())
        ' Call all the example methods
        PositiveCharacterGroup()
        Console.WriteLine()

        CharacterRange()
        Console.WriteLine()

        NegativeCharacterGroup()
        Console.WriteLine()

        AnyCharacterSingleline()
        Console.WriteLine()

        AnyCharacterMultiline()
        Console.WriteLine()

        UnicodeCategory()
        Console.WriteLine()

        NegativeUnicodeCategory()
        Console.WriteLine()

        WordCharacter()
        Console.WriteLine()

        NonWordCharacter()
        Console.WriteLine()

        WhitespaceCharacter()
        Console.WriteLine()

        NonWhitespaceCharacter()
        Console.WriteLine()

        DigitCharacter()
        Console.WriteLine()

        NonDigitCharacter()
        Console.WriteLine()

        GetUnicodeCategory()
        Console.WriteLine()

        CharacterClassSubtraction()
    End Sub

    ' <PositiveCharacterGroup>
    Sub PositiveCharacterGroup()
        Dim pattern As String = "gr[ae]y\s\S+?[\s\p{P}]"
        Dim input As String = "The gray wolf jumped over the grey wall."
        Dim matches As MatchCollection = Regex.Matches(input, pattern)
        For Each match As Match In matches
            Console.WriteLine($"'{match.Value}'")
        Next
    End Sub
    ' The example displays the following output:
    '       'gray wolf '
    '       'grey wall.'
    ' </PositiveCharacterGroup>

    ' <CharacterRange>
    Sub CharacterRange()
        Dim pattern As String = "\b[A-Z]\w*\b"
        Dim input As String = "A city Albany Zulu maritime Marseilles"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Value)
        Next
    End Sub
    ' The example displays the following output:
    '       A
    '       Albany
    '       Zulu
    '       Marseilles
    ' </CharacterRange>

    ' <NegativeCharacterGroup>
    Sub NegativeCharacterGroup()
        Dim pattern As String = "\bth[^o]\w+\b"
        Dim input As String = "thought thing though them through thus thorough this"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Value)
        Next
    End Sub
    ' The example displays the following output:
    '       thing
    '       them
    '       through
    '       thus
    '       this
    ' </NegativeCharacterGroup>

    ' <AnyCharacterSingleline>
    Sub AnyCharacterSingleline()
        Dim pattern As String = "\b.*[.?!;:](\s|\z)"
        Dim input As String = "this. what: is? go, thing."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Value)
        Next
    End Sub
    ' The example displays the following output:
    '       this. what: is? go, thing.
    ' </AnyCharacterSingleline>

    ' <AnyCharacterMultiline>
    Sub AnyCharacterMultiline()
        Dim pattern As String = "^.+"
        Dim input As String = "This is one line and" + Environment.NewLine + "this is the second."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(Regex.Escape(match.Value))
        Next

        Console.WriteLine()
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.Singleline)
            Console.WriteLine(Regex.Escape(match.Value))
        Next
    End Sub
    ' The example displays the following output:
    '       This\ is\ one\ line\ and\r
    '
    '       This\ is\ one\ line\ and\r\nthis\ is\ the\ second\.
    ' </AnyCharacterMultiline>

    ' <UnicodeCategory>
    Sub UnicodeCategory()
        Dim pattern As String = "\b(\p{IsGreek}+(\s)?)+\p{Pd}\s(\p{IsBasicLatin}+(\s)?)+"
        Dim input As String = "Κατα Μαθθαίον - The Gospel of Matthew"

        Console.WriteLine(Regex.IsMatch(input, pattern))        ' Displays True.
    End Sub
    ' </UnicodeCategory>

    ' <NegativeUnicodeCategory>
    Sub NegativeUnicodeCategory()
        Dim pattern As String = "(\P{Sc})+"

        Dim values() As String = {"$164,091.78", "£1,073,142.68", "73¢", "€120"}
        For Each value As String In values
            Console.WriteLine(Regex.Match(value, pattern).Value)
        Next
    End Sub
    ' The example displays the following output:
    '       164,091.78
    '       1,073,142.68
    '       73
    '       120
    ' </NegativeUnicodeCategory>

    ' <WordCharacter>
    Sub WordCharacter()
        Dim pattern As String = "(\w)\1"
        Dim words() As String = {"trellis", "seer", "latter", "summer",
                                 "hoarse", "lesser", "aardvark", "stunned"}
        For Each word As String In words
            Dim match As Match = Regex.Match(word, pattern)
            If match.Success Then
                Console.WriteLine($"'{match.Value}' found in '{word}' at position {match.Index}.")
            Else
                Console.WriteLine($"No double characters in '{word}'.")
            End If
        Next
    End Sub
    ' The example displays the following output:
    '       'll' found in 'trellis' at position 3.
    '       'ee' found in 'seer' at position 1.
    '       'tt' found in 'latter' at position 2.
    '       'mm' found in 'summer' at position 2.
    '       No double characters in 'hoarse'.
    '       'ss' found in 'lesser' at position 2.
    '       'aa' found in 'aardvark' at position 0.
    '       'nn' found in 'stunned' at position 3.
    ' </WordCharacter>

    ' <NonWordCharacter>
    Sub NonWordCharacter()
        Dim pattern As String = "\b(\w+)(\W){1,2}"
        Dim input As String = "The old, grey mare slowly walked across the narrow, green pasture."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Value)
            Console.Write("   Non-word character(s):")
            Dim captures As CaptureCollection = match.Groups(2).Captures
            For ctr As Integer = 0 To captures.Count - 1
                Console.Write("'{0}' (\u{1}){2}", captures(ctr).Value,
                              Convert.ToUInt16(captures(ctr).Value.Chars(0)).ToString("X4"),
                              If(ctr < captures.Count - 1, ", ", ""))
            Next
            Console.WriteLine()
        Next
    End Sub
    ' The example displays the following output:
    '       The
    '          Non-word character(s):' ' (\u0020)
    '       old,
    '          Non-word character(s):',' (\u002C), ' ' (\u0020)
    '       grey
    '          Non-word character(s):' ' (\u0020)
    '       mare
    '          Non-word character(s):' ' (\u0020)
    '       slowly
    '          Non-word character(s):' ' (\u0020)
    '       walked
    '          Non-word character(s):' ' (\u0020)
    '       across
    '          Non-word character(s):' ' (\u0020)
    '       the
    '          Non-word character(s):' ' (\u0020)
    '       narrow,
    '          Non-word character(s):',' (\u002C), ' ' (\u0020)
    '       green
    '          Non-word character(s):' ' (\u0020)
    '       pasture.
    '          Non-word character(s):'.' (\u002E)
    ' </NonWordCharacter>

    ' <WhitespaceCharacter>
    Sub WhitespaceCharacter()
        Dim pattern As String = "\b\w+(e)?s(\s|$)"
        Dim input As String = "matches stores stops leave leaves"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Value)
        Next
    End Sub
    ' The example displays the following output:
    '       matches
    '       stores
    '       stops
    '       leaves
    ' </WhitespaceCharacter>

    ' <NonWhitespaceCharacter>
    Sub NonWhitespaceCharacter()
        Dim pattern As String = "\b(\S+)\s?"
        Dim input As String = "This is the first sentence of the first paragraph. " +
                              "This is the second sentence." + Environment.NewLine +
                              "This is the only sentence of the second paragraph."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Groups(1))
        Next
    End Sub
    ' The example displays the following output:
    '    This
    '    is
    '    the
    '    first
    '    sentence
    '    of
    '    the
    '    first
    '    paragraph.
    '    This
    '    is
    '    the
    '    second
    '    sentence.
    '    This
    '    is
    '    the
    '    only
    '    sentence
    '    of
    '    the
    '    second
    '    paragraph.
    ' </NonWhitespaceCharacter>

    ' <DigitCharacter>
    Sub DigitCharacter()
        Dim pattern As String = "^(\(?\d{3}\)?[\s-])?\d{3}-\d{4}$"
        Dim inputs() As String = {"111 111-1111", "222-2222", "222 333-444",
                                   "(212) 111-1111", "111-AB1-1111",
                                   "212-111-1111", "01 999-9999"}

        For Each input As String In inputs
            If Regex.IsMatch(input, pattern) Then
                Console.WriteLine(input + ": matched")
            Else
                Console.WriteLine(input + ": match failed")
            End If
        Next
    End Sub
    ' The example displays the following output:
    '       111 111-1111: matched
    '       222-2222: matched
    '       222 333-444: match failed
    '       (212) 111-1111: matched
    '       111-AB1-1111: match failed
    '       212-111-1111: matched
    '       01 999-9999: match failed
    ' </DigitCharacter>

    ' <NonDigitCharacter>
    Sub NonDigitCharacter()
        Dim pattern As String = "^\D\d{1,5}\D*$"
        Dim inputs() As String = {"A1039C", "AA0001", "C18A", "Y938518"}

        For Each input As String In inputs
            If Regex.IsMatch(input, pattern) Then
                Console.WriteLine(input + ": matched")
            Else
                Console.WriteLine(input + ": match failed")
            End If
        Next
    End Sub
    ' The example displays the following output:
    '       A1039C: matched
    '       AA0001: match failed
    '       C18A: matched
    '       Y938518: match failed
    ' </NonDigitCharacter>

    ' <GetUnicodeCategory>
    Sub GetUnicodeCategory()
        Dim chars() As Char = {"a"c, "X"c, "8"c, ","c, " "c, ChrW(9), "!"c}

        For Each ch As Char In chars
            Console.WriteLine("'{0}': {1}", Regex.Escape(ch.ToString()),
                              Char.GetUnicodeCategory(ch))
        Next
    End Sub
    ' The example displays the following output:
    '       'a': LowercaseLetter
    '       'X': UppercaseLetter
    '       '8': DecimalDigitNumber
    '       ',': OtherPunctuation
    '       '\ ': SpaceSeparator
    '       '\t': Control
    '       '!': OtherPunctuation
    ' </GetUnicodeCategory>

    ' <CharacterClassSubtraction>
    Sub CharacterClassSubtraction()
        Dim inputs() As String = {"123", "13579753", "3557798", "335599901"}
        Dim pattern As String = "^[0-9-[2468]]+$"

        For Each input As String In inputs
            Dim match As Match = Regex.Match(input, pattern)
            If match.Success Then Console.WriteLine(match.Value)
        Next
    End Sub
    ' The example displays the following output:
    '       13579753
    '       335599901
    ' </CharacterClassSubtraction>
End Module
