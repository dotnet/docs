        ' This string is made up of a surrogate pair (high surrogate
        ' U+D800 and low surrogate U+DC00) and a combining character 
        ' sequence (the letter "a" with the combining grave accent).
        Dim testString2 As String = ChrW(&HD800) & ChrW(&HDC00) & "a" & ChrW(&H300)

        ' Create and initialize a StringInfo object for the string.
        Dim si As New System.Globalization.StringInfo(testString2)

        ' Create and populate the array.
        Dim unicodeTestArray(si.LengthInTextElements) As String
        For i As Integer = 0 To si.LengthInTextElements - 1
            unicodeTestArray(i) = si.SubstringByTextElements(i, 1)
        Next