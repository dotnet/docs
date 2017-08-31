Option Strict On
Option Explicit On

Class Class037d44784ef3497295a788bcc2432af9
    ' Str Function

    Public Sub Method1()
        ' <snippet1>
        Dim TestString As String
        ' Returns " 459".
        TestString = Str(459)
        ' Returns "-459.65".
        TestString = Str(-459.65)
        ' Returns " 459.001".
        TestString = Str(459.001)
        ' </snippet1>
    End Sub

End Class

Class Class08c52c912d2e4034b853afb28f32d418
    ' Space Function (Visual Basic)

    Public Sub Method2()
        ' <snippet2>
        Dim TestString As String
        ' Returns a string with 10 spaces.
        TestString = Space(10)
        ' Inserts 10 spaces between two strings.
        TestString = "Hello" & Space(10) & "World"
        ' </snippet2>
    End Sub

End Class

Class Class0b1249b845cd439fa490d09c2c347133
    ' FormatDateTime Function (Visual Basic)

    Public Sub Method3()
        ' <snippet3>
        ' English (US) format.
        Dim TestDate As DateTime = #3/12/1999#

        ' FormatDateTime returns "Friday, March 12, 1999".
        ' The time information is neutral (00:00:00) and therefore suppressed.
        Dim TestString As String = FormatDateTime(TestDate, DateFormat.LongDate)
        ' </snippet3>
    End Sub

End Class

Class Class27032bdb6f6048fc84e2c937b06deee8
    ' Replace Function (Visual Basic)

    Public Sub Method4()
        ' <snippet4>
        Dim TestString As String = "Shopping List"
        ' Returns "Shipping List".
        Dim aString As String = Replace(TestString, "o", "i")
        ' </snippet4>
    End Sub

End Class

Class Class2b82d7a896464cb0bec580abc98297bf
    ' Mid Statement

    Public Sub Method5()
        ' <snippet5>
        Dim TestString As String
        ' Initializes string.
        TestString = "The dog jumps"
        ' Returns "The fox jumps".
        Mid(TestString, 5, 3) = "fox"
        ' Returns "The cow jumps".
        Mid(TestString, 5) = "cow"
        ' Returns "The cow jumpe".
        Mid(TestString, 5) = "cow jumped over"
        ' Returns "The duc jumpe".
        Mid(TestString, 5, 3) = "duck"
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
        Dim SearchString As String = "XXpXXpXXPXXP"
        ' Search for "P".
        Dim SearchChar As String = "P"

        Dim TestPos As Integer
        ' A textual comparison starting at position 4. Returns 6.
        TestPos = InStr(4, SearchString, SearchChar, CompareMethod.Text)

        ' A binary comparison starting at position 1. Returns 9.
        TestPos = InStr(1, SearchString, SearchChar, CompareMethod.Binary)

        ' If Option Compare is not set, or set to Binary, return 9.
        ' If Option Compare is set to Text, returns 3.
        TestPos = InStr(SearchString, SearchChar)

        ' Returns 0.
        TestPos = InStr(1, SearchString, "W")
        ' </snippet8>
    End Sub

End Class

Class Class534514e5dee94dfd993bda09731eece5
    ' RSet Function

    Public Sub Method9()
        ' <snippet9>
        Dim TestString As String = "Right"
        ' Returns "      Right"
        Dim rString As String = RSet(TestString, 11)
        ' </snippet9>
    End Sub

End Class

Class Class55eac984f662479f839d16c3822584de
    ' Join Function (Visual Basic)

    Public Sub Method10()
        ' <snippet10>
        Dim TestItem() As String = {"Pickle", "Pineapple", "Papaya"}
        ' Returns "Pickle, Pineapple, Papaya"
        Dim TestShoppingList As String = Join(TestItem, ", ")
        ' </snippet10>
    End Sub

End Class

Class Class591d286c6b7a4350ae7499fee00fd964
    ' LSet Function

    Public Sub Method11()
        ' <snippet11>
        Dim TestString As String = "Left"
        Dim lString As String
        ' Returns "Left      "
        lString = LSet(TestString, 10)
        ' Returns "Le"
        lString = LSet(TestString, 2)
        ' Returns "Left"
        lString = LSet(TestString, 4)
        ' </snippet11>
    End Sub

End Class

Class Class71ca5ff7e45c4bb1a50ee622336771b1
    ' LCase Function (Visual Basic)

    Public Sub Method12()
        ' <snippet12>
        ' String to convert.
        Dim UpperCase As String = "Hello World 1234"
        ' Returns "hello world 1234".
        Dim LowerCase As String = LCase(UpperCase)
        ' </snippet12>
    End Sub

End Class

Class Class7e33b04748fc493bbb8d7d1ac3f90038
    ' Split Function (Visual Basic)

    Public Sub Method13()
        ' <snippet13>
        Dim TestString As String = "Look at these!"
        ' Returns an array containing "Look", "at", and "these!".
        Dim TestArray() As String = Split(TestString)
        ' </snippet13>
    End Sub

    Public Sub Method14()
        ' <snippet14>
        Dim TestString As String = "apple    pear banana  "
        Dim TestArray() As String = Split(TestString)
        ' TestArray holds {"apple", "", "", "", "pear", "banana", "", ""}
        Dim LastNonEmpty As Integer = -1
        For i As Integer = 0 To TestArray.Length - 1
            If TestArray(i) <> "" Then
                LastNonEmpty += 1
                TestArray(LastNonEmpty) = TestArray(i)
            End If
        Next
        ReDim Preserve TestArray(LastNonEmpty)
        ' TestArray now holds {"apple", "pear", "banana"}
        ' </snippet14>
    End Sub

End Class

Class Class7e92f321331a42b89866484bbae2e8ec
    ' FormatNumber Function (Visual Basic)

    Public Sub Method15()
        ' <snippet15>
        Dim TestNumber As Integer = 45600
        ' Returns "45,600.00".
        Dim TestString As String = FormatNumber(TestNumber, 2, , , TriState.True)
        ' </snippet15>
    End Sub

End Class

Class Class8b63e84245b74a48a653fb325b412e97
    ' Hex Function (Visual Basic)

    Public Sub Method16()
        ' <snippet16>
        Dim TestHex As String
        ' Returns 5.
        TestHex = Hex(5)
        ' Returns A.
        TestHex = Hex(10)
        ' Returns 1CB.
        TestHex = Hex(459)
        ' </snippet16>
    End Sub

End Class

Class Class8b6caa3e973a4f18b0e493956a9dee9b
    ' Mid Function (Visual Basic)

    Public Sub Method17()
        ' <snippet17>
        ' Creates text string.
        Dim TestString As String = "Mid Function Demo"
        ' Returns "Mid".
        Dim FirstWord As String = Mid(TestString, 1, 3)
        ' Returns "Demo".
        Dim LastWord As String = Mid(TestString, 14, 4)
        ' Returns "Function Demo".
        Dim MidWords As String = Mid(TestString, 5)
        ' </snippet17>
    End Sub

End Class

Class Class8bcca28e96c84eb19ecf4fba6372c320
    ' Different Formats for Different Numeric Values (Format Function)

    Public Sub Method18()
        ' <snippet18>
        Dim Style1 As String = "$#,##0;($#,##0)"
        ' </snippet18>
        ' <snippet19>
        Dim Style2 As String = "$#,##0;;\Z\e\r\o"
        ' </snippet19>
    End Sub

End Class

Class Classa6832947b87d4bcfbafe15314b41ff89
    ' Left Function (Visual Basic)

    Public Sub Method20()
        ' <snippet20>
        Dim TestString As String = "Hello World!"
        ' Returns "Hello".
        Dim subString As String = Left(TestString, 5)
        ' </snippet20>
    End Sub

End Class

Class Classa9a60c3d7a5e4f3e9a92c491105bc88f
    ' Right Function (Visual Basic)

    Public Sub Method21()
        ' <snippet21>
        Dim TestString As String = "Hello World!"
        ' Returns "World!".
        Dim subString As String = Right(TestString, 6)
        ' </snippet21>
    End Sub

End Class

Class Classb0b9cc74369c4f389d3bdf6153e1bf15
    ' StrComp Function (Visual Basic)

    Public Sub Method22()
        ' <snippet22>
        ' Defines variables.
        Dim TestStr1 As String = "ABCD"
        Dim TestStr2 As String = "abcd"
        Dim TestComp As Integer
        ' The two strings sort equally. Returns 0.
        TestComp = StrComp(TestStr1, TestStr2, CompareMethod.Text)
        ' TestStr1 sorts before TestStr2. Returns -1.
        TestComp = StrComp(TestStr1, TestStr2, CompareMethod.Binary)
        ' TestStr2 sorts after TestStr1. Returns 1.
        TestComp = StrComp(TestStr2, TestStr1, CompareMethod.Binary)
        ' </snippet22>
    End Sub

End Class

Class Classb176720d94da4187922597f3bdd94051
    ' GetChar Function

    Public Sub Method23()
        ' <snippet23>
        Dim TestString As String = "ABCDE"
        Dim TestChar As Char
        ' Returns "D"
        TestChar = GetChar(TestString, 4)
        ' </snippet23>
    End Sub

End Class

Class Classb36396da6e6b4bae8b2b11aaee0a0554
    ' Filter Function (Visual Basic)

    Public Sub Method24()
        ' <snippet24>
        Dim TestStrings(2) As String
        TestStrings(0) = "This"
        TestStrings(1) = "Is"
        TestStrings(2) = "It"
        Dim subStrings() As String
        ' Returns ["This", "Is"].
        subStrings = Filter(TestStrings, "is", True, CompareMethod.Text)
        ' Returns ["This"].
        subStrings = Filter(TestStrings, "is", True, CompareMethod.Binary)
        ' Returns ["Is", "It"].
        subStrings = Filter(TestStrings, "is", False, CompareMethod.Binary)
        ' </snippet24>
    End Sub

End Class

Class Classb8d0c10b56664411a16fec2ad6cc082d
    ' Trim, LTrim, and RTrim Functions

    Public Sub Method25()
        ' <snippet25>
        ' Initializes string.
        Dim TestString As String = "  <-Trim->  "
        Dim TrimString As String
        ' Returns "<-Trim->  ".
        TrimString = LTrim(TestString)
        ' Returns "  <-Trim->".
        TrimString = RTrim(TestString)
        ' Returns "<-Trim->".
        TrimString = LTrim(RTrim(TestString))
        ' Using the Trim function alone achieves the same result.
        ' Returns "<-Trim->".
        TrimString = Trim(TestString)
        ' </snippet25>
    End Sub

End Class

Class Classbe7996d57107417f9b3ca63877e7918b
    ' InStrRev Function (Visual Basic)

    Public Sub Method26()
        ' <snippet26>
        Dim TestString As String = "the quick brown fox jumps over the lazy dog"
        Dim TestNumber As Integer
        ' Returns 32.
        TestNumber = InStrRev(TestString, "the")
        ' Returns 1.
        TestNumber = InStrRev(TestString, "the", 16)
        ' </snippet26>
    End Sub

End Class

Class Classc6f5bddaa7c34f3886cc1cf47aa940b3
    ' Format Function

    Public Sub Method27()
        ' <snippet27>
        Dim TestDateTime As Date = #1/27/2001 5:04:23 PM#
        Dim TestStr As String
        ' Returns current system time in the system-defined long time format.
        TestStr = Format(Now(), "Long Time")
        ' Returns current system date in the system-defined long date format.
        TestStr = Format(Now(), "Long Date")
        ' Also returns current system date in the system-defined long date 
        ' format, using the single letter code for the format.
        TestStr = Format(Now(), "D")

        ' Returns the value of TestDateTime in user-defined date/time formats.
        ' Returns "5:4:23".
        TestStr = Format(TestDateTime, "h:m:s")
        ' Returns "05:04:23 PM".
        TestStr = Format(TestDateTime, "hh:mm:ss tt")
        ' Returns "Saturday, Jan 27 2001".
        TestStr = Format(TestDateTime, "dddd, MMM d yyyy")
        ' Returns "17:04:23".
        TestStr = Format(TestDateTime, "HH:mm:ss")
        ' Returns "23".
        TestStr = Format(23)

        ' User-defined numeric formats.
        ' Returns "5,459.40".
        TestStr = Format(5459.4, "##,##0.00")
        ' Returns "334.90".
        TestStr = Format(334.9, "###0.00")
        ' Returns "500.00%".
        TestStr = Format(5, "0.00%")
        ' </snippet27>
    End Sub

End Class

Class Classc7361de03cee45e584b8b6f7f7e346ce
    ' FormatPercent Function (Visual Basic)

    Public Sub Method28()
        ' <snippet28>
        Dim TestNumber As Single = 0.76
        ' Returns "76.00%".
        Dim TestString As String = FormatPercent(TestNumber)
        ' </snippet28>
    End Sub

End Class

Class Classda935d42187845a6beacde78cc043c67
    ' StrReverse Function (Visual Basic)

    Public Sub Method29()
        ' <snippet29>
        Dim TestString As String = "ABCDEFG"
        ' Returns "GFEDCBA".
        Dim revString As String = StrReverse(TestString)
        ' </snippet29>
    End Sub

End Class

Class Classdfe0f7eee0564e8a905ac78db6294b4a
    ' Oct Function

    Public Sub Method30()
        ' <snippet30>
        Dim TestOct As String
        ' Returns "4".
        TestOct = Oct(4)
        ' Returns "10".
        TestOct = Oct(8)
        ' Returns "713".
        TestOct = Oct(459)
        ' </snippet30>
    End Sub

End Class

Class Classe8309de8b17545fb8eaf5137214504e1
    ' UCase Function (Visual Basic)

    Public Sub Method31()
        ' <snippet31>
        ' String to convert.
        Dim LowerCase As String = "Hello World 1234"
        ' Returns "HELLO WORLD 1234".
        Dim UpperCase As String = UCase(LowerCase)
        ' </snippet31>
    End Sub

End Class

Class Classe98c20f1e99c4788933f9724131fee93
    ' FormatCurrency Function (Visual Basic)

    Public Sub Method32()
        ' <snippet32>
        Dim TestDebt As Double = -4456.43
        Dim TestString As String
        ' Returns "($4,456.43)".
        TestString = FormatCurrency(TestDebt, , , TriState.True, TriState.True)
        ' </snippet32>
    End Sub

End Class

Class Classf627225f0bb446c8ac635a52a928ffd1
    ' Len Function (Visual Basic)

    Public Sub Method33()
        ' <snippet33>
        ' Initializes variable.
        Dim TestString As String = "Hello World"
        ' Returns 11.
        Dim TestLen As Integer = Len(TestString)
        ' </snippet33>
    End Sub

End Class

Class Classf8213da94cb34e35a35523b07f53bd25
    ' StrDup Function

    Public Sub Method34()
        ' <snippet34>
        Dim aString As String = "Wow! What a string!"
        Dim aObject As New Object
        Dim TestString As String
        aObject = "This is a String contained within an Object"
        ' Returns "PPPPP"
        TestString = StrDup(5, "P")
        ' Returns "WWWWWWWWWW"
        TestString = StrDup(10, aString)
        ' Returns "TTTTTT"
        TestString = CStr(StrDup(6, aObject))
        ' </snippet34>
    End Sub

End Class
