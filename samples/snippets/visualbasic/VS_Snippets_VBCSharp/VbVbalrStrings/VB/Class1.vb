Option Strict On
Option Explicit On

Class Class037d44784ef3497295a788bcc2432af9
    ' Str Function

    Public Sub Method1()
        ' <snippet1>
        Dim testString As String
        ' Returns " 459".
        testString = Str(459)
        ' Returns "-459.65".
        testString = Str(-459.65)
        ' Returns " 459.001".
        testString = Str(459.001)
        ' </snippet1>
    End Sub

End Class

Class Class08c52c912d2e4034b853afb28f32d418
    ' Space Function (Visual Basic)

    Public Sub Method2()
        ' <snippet2>
        Dim testString As String
        ' Returns a string with 10 spaces.
        testString = Space(10)
        ' Inserts 10 spaces between two strings.
        testString = "Hello" & Space(10) & "World"
        ' </snippet2>
    End Sub

End Class

Class Class0b1249b845cd439fa490d09c2c347133
    ' FormatDateTime Function (Visual Basic)

    Public Sub Method3()
        ' <snippet3>
        ' English (US) format.
        Dim testDate As DateTime = #3/12/1999#

        ' FormatDateTime returns "Friday, March 12, 1999".
        ' The time information is neutral (00:00:00) and therefore suppressed.
        Dim testString As String = FormatDateTime(testDate, DateFormat.LongDate)
        ' </snippet3>
    End Sub

End Class

Class Class27032bdb6f6048fc84e2c937b06deee8
    ' Replace Function (Visual Basic)

    Public Sub Method4()
        ' <snippet4>
        Dim testString As String = "Shopping List"
        ' Returns "Shipping List".
        Dim aString As String = Replace(testString, "o", "i")
        ' </snippet4>
    End Sub

End Class

Class Class2b82d7a896464cb0bec580abc98297bf
    ' Mid Statement

    Public Sub Method5()
        ' <snippet5>
        Dim testString As String
        ' Initializes string.
        testString = "The dog jumps"
        ' Returns "The fox jumps".
        Mid(testString, 5, 3) = "fox"
        ' Returns "The cow jumps".
        Mid(testString, 5) = "cow"
        ' Returns "The cow jumpe".
        Mid(testString, 5) = "cow jumped over"
        ' Returns "The duc jumpe".
        Mid(testString, 5, 3) = "duck"
        ' </snippet5>
    End Sub

End Class

Class Class31ceb44b005b455fb3449dd06efbf660
    ' StrConv Function

    Public Sub Method6()
        ' <snippet6>
        Dim sText As String = "Hello World"
        ' Returns "hello world".
        Dim sNewText As String = StrConv(sText, VbStrConv.LowerCase)
        ' </snippet6>
    End Sub

End Class

Class Class37f3c7078a6f4c519b029e634c4299ab
    ' Chr, ChrW Functions

    Public Sub Method7()
        ' <snippet7>
        Dim associatedChar As Char
        ' Returns "A".
        associatedChar = Chr(65)
        ' Returns "a".
        associatedChar = Chr(97)
        ' Returns ">".
        associatedChar = Chr(62)
        ' Returns "%".
        associatedChar = Chr(37)
        ' </snippet7>
    End Sub

End Class

Class Class4f6b0e28ab9349c1ae98193223b5ba4f
    ' InStr Function (Visual Basic)

    Public Sub Method8()
        ' <snippet8>
        ' String to search in.
        Dim searchString As String = "XXpXXpXXPXXP"
        ' Search for "P".
        Dim searchChar As String = "P"

        Dim testPos As Integer
        ' A textual comparison starting at position 4. Returns 6.
        testPos = InStr(4, searchString, searchChar, CompareMethod.Text)

        ' A binary comparison starting at position 1. Returns 9.
        testPos = InStr(1, SearchString, SearchChar, CompareMethod.Binary)

        ' If Option Compare is not set, or set to Binary, return 9.
        ' If Option Compare is set to Text, returns 3.
        testPos = InStr(searchString, searchChar)

        ' Returns 0.
        testPos = InStr(1, searchString, "W")
        ' </snippet8>
    End Sub

End Class

Class Class534514e5dee94dfd993bda09731eece5
    ' RSet Function

    Public Sub Method9()
        ' <snippet9>
        Dim testString As String = "Right"
        ' Returns "      Right"
        Dim rString As String = RSet(testString, 11)
        ' </snippet9>
    End Sub

End Class

Class Class55eac984f662479f839d16c3822584de
    ' Join Function (Visual Basic)

    Public Sub Method10()
        ' <snippet10>
        Dim testItem() As String = {"Pickle", "Pineapple", "Papaya"}
        ' Returns "Pickle, Pineapple, Papaya"
        Dim testShoppingList As String = Join(testItem, ", ")
        ' </snippet10>
    End Sub

End Class

Class Class591d286c6b7a4350ae7499fee00fd964
    ' LSet Function

    Public Sub Method11()
        ' <snippet11>
        Dim testString As String = "Left"
        Dim lString As String
        ' Returns "Left      "
        lString = LSet(testString, 10)
        ' Returns "Le"
        lString = LSet(testString, 2)
        ' Returns "Left"
        lString = LSet(testString, 4)
        ' </snippet11>
    End Sub

End Class

Class Class71ca5ff7e45c4bb1a50ee622336771b1
    ' LCase Function (Visual Basic)

    Public Sub Method12()
        ' <snippet12>
        ' String to convert.
        Dim upperCase As String = "Hello World 1234"
        ' Returns "hello world 1234".
        Dim lowerCase As String = LCase(upperCase)
        ' </snippet12>
    End Sub

End Class

Class Class7e33b04748fc493bbb8d7d1ac3f90038
    ' Split Function (Visual Basic)

    Public Sub Method13()
        ' <snippet13>
        Dim testString As String = "Look at these!"
        ' Returns an array containing "Look", "at", and "these!".
        Dim testArray() As String = Split(testString)
        ' </snippet13>
    End Sub

    Public Sub Method14()
        ' <snippet14>
        Dim testString As String = "apple    pear banana  "
        Dim testArray() As String = Split(testString)
        ' testArray holds {"apple", "", "", "", "pear", "banana", "", ""}
        Dim lastNonEmpty As Integer = -1
        For i As Integer = 0 To testArray.Length - 1
            If testArray(i) <> "" Then
                lastNonEmpty += 1
                testArray(lastNonEmpty) = testArray(i)
            End If
        Next
        ReDim Preserve testArray(lastNonEmpty)
        ' testArray now holds {"apple", "pear", "banana"}
        ' </snippet14>
    End Sub

End Class

Class Class7e92f321331a42b89866484bbae2e8ec
    ' FormatNumber Function (Visual Basic)

    Public Sub Method15()
        ' <snippet15>
        Dim testNumber As Integer = 45600
        ' Returns "45,600.00".
        Dim testString As String = FormatNumber(testNumber, 2, , , TriState.True)
        ' </snippet15>
    End Sub

End Class

Class Class8b63e84245b74a48a653fb325b412e97
    ' Hex Function (Visual Basic)

    Public Sub Method16()
        ' <snippet16>
        Dim testHex As String
        ' Returns 5.
        testHex = Hex(5)
        ' Returns A.
        testHex = Hex(10)
        ' Returns 1CB.
        testHex = Hex(459)
        ' </snippet16>
    End Sub

End Class

Class Class8b6caa3e973a4f18b0e493956a9dee9b
    ' Mid Function (Visual Basic)

    Public Sub Method17()
        ' <snippet17>
        ' Creates text string.
        Dim testString As String = "Mid Function Demo"
        ' Returns "Mid".
        Dim firstWord As String = Mid(testString, 1, 3)
        ' Returns "Demo".
        Dim lastWord As String = Mid(testString, 14, 4)
        ' Returns "Function Demo".
        Dim midWords As String = Mid(testString, 5)
        ' </snippet17>
    End Sub

End Class

Class Class8bcca28e96c84eb19ecf4fba6372c320
    ' Different Formats for Different Numeric Values (Format Function)

    Public Sub Method18()
        ' <snippet18>
        Dim style1 As String = "$#,##0;($#,##0)"
        ' </snippet18>
        ' <snippet19>
        Dim style2 As String = "$#,##0;;\Z\e\r\o"
        ' </snippet19>
    End Sub

End Class

Class Classa6832947b87d4bcfbafe15314b41ff89
    ' Left Function (Visual Basic)

    Public Sub Method20()
        ' <snippet20>
        Dim testString As String = "Hello World!"
        ' Returns "Hello".
        Dim subString As String = Left(testString, 5)
        ' </snippet20>
    End Sub

End Class

Class Classa9a60c3d7a5e4f3e9a92c491105bc88f
    ' Right Function (Visual Basic)

    Public Sub Method21()
        ' <snippet21>
        Dim testString As String = "Hello World!"
        ' Returns "World!".
        Dim subString As String = Right(testString, 6)
        ' </snippet21>
    End Sub

End Class

Class Classb0b9cc74369c4f389d3bdf6153e1bf15
    ' StrComp Function (Visual Basic)

    Public Sub Method22()
        ' <snippet22>
        ' Defines variables.
        Dim testStr1 As String = "ABCD"
        Dim testStr2 As String = "abcd"
        Dim testComp As Integer
        ' The two strings sort equally. Returns 0.
        testComp = StrComp(testStr1, testStr2, CompareMethod.Text)
        ' testStr1 sorts before testStr2. Returns -1.
        testComp = StrComp(testStr1, testStr2, CompareMethod.Binary)
        ' testStr2 sorts after testStr1. Returns 1.
        testComp = StrComp(testStr2, testStr1, CompareMethod.Binary)
        ' </snippet22>
    End Sub

End Class

Class Classb176720d94da4187922597f3bdd94051
    ' GetChar Function

    Public Sub Method23()
        ' <snippet23>
        Dim testString As String = "ABCDE"
        Dim testChar As Char
        ' Returns "D"
        testChar = GetChar(testString, 4)
        ' </snippet23>
    End Sub

End Class

Class Classb36396da6e6b4bae8b2b11aaee0a0554
    ' Filter Function (Visual Basic)

    Public Sub Method24()
        ' <snippet24>
        Dim testStrings(2) As String
        testStrings(0) = "This"
        testStrings(1) = "Is"
        testStrings(2) = "It"
        Dim subStrings() As String
        ' Returns ["This", "Is"].
        subStrings = Filter(testStrings, "is", True, CompareMethod.Text)
        ' Returns ["This"].
        subStrings = Filter(testStrings, "is", True, CompareMethod.Binary)
        ' Returns ["Is", "It"].
        subStrings = Filter(testStrings, "is", False, CompareMethod.Binary)
        ' </snippet24>
    End Sub

End Class

Class Classb8d0c10b56664411a16fec2ad6cc082d
    ' Trim, LTrim, and RTrim Functions

    Public Sub Method25()
        ' <snippet25>
        ' Initializes string.
        Dim testString As String = "  <-Trim->  "
        Dim trimString As String
        ' Returns "<-Trim->  ".
        trimString = LTrim(testString)
        ' Returns "  <-Trim->".
        trimString = RTrim(testString)
        ' Returns "<-Trim->".
        trimString = LTrim(RTrim(testString))
        ' Using the Trim function alone achieves the same result.
        ' Returns "<-Trim->".
        trimString = Trim(testString)
        ' </snippet25>
    End Sub

End Class

Class Classbe7996d57107417f9b3ca63877e7918b
    ' InStrRev Function (Visual Basic)

    Public Sub Method26()
        ' <snippet26>
        Dim testString As String = "the quick brown fox jumps over the lazy dog"
        Dim testNumber As Integer
        ' Returns 32.
        testNumber = InStrRev(testString, "the")
        ' Returns 1.
        testNumber = InStrRev(testString, "the", 16)
        ' </snippet26>
    End Sub

End Class

Class Classc6f5bddaa7c34f3886cc1cf47aa940b3
    ' Format Function

    Public Sub Method27()
        ' <snippet27>
        Dim testDateTime As Date = #1/27/2001 5:04:23 PM#
        Dim testStr As String
        ' Returns current system time in the system-defined long time format.
        testStr = Format(Now(), "Long Time")
        ' Returns current system date in the system-defined long date format.
        testStr = Format(Now(), "Long Date")
        ' Also returns current system date in the system-defined long date 
        ' format, using the single letter code for the format.
        testStr = Format(Now(), "D")

        ' Returns the value of testDateTime in user-defined date/time formats.
        ' Returns "5:4:23".
        testStr = Format(testDateTime, "h:m:s")
        ' Returns "05:04:23 PM".
        testStr = Format(testDateTime, "hh:mm:ss tt")
        ' Returns "Saturday, Jan 27 2001".
        testStr = Format(testDateTime, "dddd, MMM d yyyy")
        ' Returns "17:04:23".
        testStr = Format(testDateTime, "HH:mm:ss")
        ' Returns "23".
        testStr = Format(23)

        ' User-defined numeric formats.
        ' Returns "5,459.40".
        testStr = Format(5459.4, "##,##0.00")
        ' Returns "334.90".
        testStr = Format(334.9, "###0.00")
        ' Returns "500.00%".
        testStr = Format(5, "0.00%")
        ' </snippet27>
    End Sub

End Class

Class Classc7361de03cee45e584b8b6f7f7e346ce
    ' FormatPercent Function (Visual Basic)

    Public Sub Method28()
        ' <snippet28>
        Dim testNumber As Single = 0.76
        ' Returns "76.00%".
        Dim testString As String = FormatPercent(testNumber)
        ' </snippet28>
    End Sub

End Class

Class Classda935d42187845a6beacde78cc043c67
    ' StrReverse Function (Visual Basic)

    Public Sub Method29()
        ' <snippet29>
        Dim testString As String = "ABCDEFG"
        ' Returns "GFEDCBA".
        Dim revString As String = StrReverse(testString)
        ' </snippet29>
    End Sub

End Class

Class Classdfe0f7eee0564e8a905ac78db6294b4a
    ' Oct Function

    Public Sub Method30()
        ' <snippet30>
        Dim testOct As String
        ' Returns "4".
        testOct = Oct(4)
        ' Returns "10".
        testOct = Oct(8)
        ' Returns "713".
        testOct = Oct(459)
        ' </snippet30>
    End Sub

End Class

Class Classe8309de8b17545fb8eaf5137214504e1
    ' UCase Function (Visual Basic)

    Public Sub Method31()
        ' <snippet31>
        ' String to convert.
        Dim lowerCase As String = "Hello World 1234"
        ' Returns "HELLO WORLD 1234".
        Dim upperCase As String = UCase(lowerCase)
        ' </snippet31>
    End Sub

End Class

Class Classe98c20f1e99c4788933f9724131fee93
    ' FormatCurrency Function (Visual Basic)

    Public Sub Method32()
        ' <snippet32>
        Dim testDebt As Double = -4456.43
        Dim testString As String
        ' Returns "($4,456.43)".
        testString = FormatCurrency(testDebt, , , TriState.True, TriState.True)
        ' </snippet32>
    End Sub

End Class

Class Classf627225f0bb446c8ac635a52a928ffd1
    ' Len Function (Visual Basic)

    Public Sub Method33()
        ' <snippet33>
        ' Initializes variable.
        Dim testString As String = "Hello World"
        ' Returns 11.
        Dim testLen As Integer = Len(testString)
        ' </snippet33>
    End Sub

End Class

Class Classf8213da94cb34e35a35523b07f53bd25
    ' StrDup Function

    Public Sub Method34()
        ' <snippet34>
        Dim aString As String = "Wow! What a string!"
        Dim aObject As New Object
        Dim testString As String
        aObject = "This is a String contained within an Object"
        ' Returns "PPPPP"
        testString = StrDup(5, "P")
        ' Returns "WWWWWWWWWW"
        testString = StrDup(10, aString)
        ' Returns "TTTTTT"
        testString = CStr(StrDup(6, aObject))
        ' </snippet34>
    End Sub

End Class
