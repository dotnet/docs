Option Explicit On
Option Strict On

Class Class0bb85ddaa37f4a9799b48b344c5437be

    ' 0bb85dda-a37f-4a97-99b4-8b344c5437be
    ' How to: Search for a String in an Array of Strings (Visual Basic)

    Public Sub Method35()
        ' <snippet35>
        Dim StrArray() As String = {"ABCDEFG", "HIJKLMNOP"}
        Dim FindThisString As String = "JKL"

        For Each Str As String In StrArray
            If Str.Contains(FindThisString) Then
                MsgBox("Found " & FindThisString & " at index " &
                  Str.IndexOf(FindThisString))
            End If
        Next
        ' </snippet35>
    End Sub

    ' 1f28b791-e3d7-44e3-aa09-bccbfbd63543
    ' How to: Remove Parts of a String (Visual Basic)
    Public Sub Method36()
        ' <snippet36>
        Dim withParts As String = "Books and Chapters and Pages"
        Dim withoutParts As String = Replace(withParts, "and ", "")
        ' </snippet36>
    End Sub

    ' 67f9045c-f349-440b-8ed8-b7a07aafa7d2
    ' String Manipulation in Visual Basic
    Public Sub Method44()
        ' <snippet44>
        Dim aString As String = "SomeString"
        Dim bString As String
        ' Assign "meS" to bString.
        bString = Mid(aString, 3, 3)
        ' </snippet44>
    End Sub

    Public Sub Method45()
        ' <snippet45>
        Dim equal As Boolean = (String.Compare("Hello", "Goodbye") = 0)
        ' </snippet45>
    End Sub

    Public Sub Method46()
        ' <snippet46>
        Dim aString As String = "A String"
        Dim bString As String

        ' Assign "String" to bString.
        bString = aString.Substring(2, 6)
        ' </snippet46>
    End Sub

    Public Sub Method47()
        ' <snippet47>
        Dim MyString As String = "This is my string"
        Dim stringLength As Integer

        ' Explicitly set the string to Nothing.
        MyString = Nothing

        ' stringLength = 0
        stringLength = Len(MyString)

        ' This line, however, causes an exception to be thrown.
        stringLength = MyString.Length
        ' </snippet47>
    End Sub

    Public Sub Method48()
        ' <snippet48>
        Dim myString As String = "Alphabetical"
        Dim secondString As String = "Order"
        Dim result As Integer
        result = String.Compare(myString, secondString)
        ' </snippet48>
    End Sub

    Public Sub Method49()
        ' <snippet49>
        Dim myString As String = "ABCDE"
        Dim myChar As Char

        ' Assign "D" to myChar.
        myChar = myString.Chars(3)
        ' </snippet49>
    End Sub

    Public Sub Method50()
        ' <snippet50>
        Dim myString As String = "ABCDE"
        Dim myInteger As Integer

        ' Assign 3 to myInteger.
        myInteger = myString.IndexOf("D")
        ' </snippet50>
    End Sub

    Public Sub Method51()
        ' <snippet51>
        Dim aString As String = "A"
        Dim bString As String = "B"
        Dim cString As String = "C"
        Dim dString As String = "D"
        Dim myString As String

        ' Assign "ABCD" to myString.
        myString = String.Concat(aString, bString, cString, dString)
        ' </snippet51>
    End Sub

    Public Sub Method52()
        ' <snippet52>
        Dim myString As String = "UpPeR oR LoWeR cAsE"
        Dim newString As String

        ' newString = "UPPER OR LOWER CASE"
        newString = UCase(myString)

        ' newString = "upper or lower case"
        newString = LCase(myString)

        ' newString = "UPPER OR LOWER CASE"
        newString = myString.ToUpper

        ' newString = "upper or lower case"
        newString = myString.ToLower
        ' </snippet52>
    End Sub

    Public Sub Method53()
        ' <snippet53>
        Dim spaceString As String =
            "        This string will have the spaces removed        "
        Dim oneString As String
        Dim twoString As String

        ' This removes all trailing and leading spaces.
        oneString = spaceString.Trim

        ' This also removes all trailing and leading spaces.
        twoString = Trim(spaceString)
        ' </snippet53>
    End Sub

    Public Sub Method54()
        ' <snippet54>
        Dim myString As String = "#####Remove those!######"
        Dim oneString As String
        oneString = myString.Trim("#"c)
        ' </snippet54>
    End Sub

    Public Sub Method55()
        ' <snippet55>
        Dim aString As String = "This is My Str@o@o@ing"
        Dim myString As String
        Dim anotherString As String

        ' myString = "This is My String"
        myString = aString.Remove(14, 5)

        ' anotherString = "This is Another String"
        anotherString = myString.Replace("My", "Another")
        ' </snippet55>
    End Sub

    Public Sub Method56()
        ' <snippet56>
        Dim aString As String = "This is My Stng"
        Dim myString As String

        ' Results in a value of "This is My String".
        myString = aString.Insert(13, "ri")
        ' </snippet56>
    End Sub

    Public Sub Method57()
        ' <snippet57>
        Dim shoppingItem(2) As String
        Dim shoppingList As String
        shoppingItem(0) = "Milk"
        shoppingItem(1) = "Eggs"
        shoppingItem(2) = "Bread"
        shoppingList = String.Join(",", shoppingItem)
        ' </snippet57>
    End Sub

    Public Sub Method58()
        ' <snippet58>
        Dim shoppingList As String = "Milk,Eggs,Bread"
        Dim shoppingItem(2) As String
        shoppingItem = shoppingList.Split(","c)
        ' </snippet58>
    End Sub

    Public Sub Method59()
        ' <snippet59>
        Dim aString As String = "Left Center Right"
        Dim rString, lString, mString As String

        ' rString = "Right"
        rString = Mid(aString, 13)

        ' lString = "Left"
        lString = Mid(aString, 1, 4)

        ' mString = "Center"
        mString = Mid(aString, 6, 6)
        ' </snippet59>
    End Sub

    Public Sub Method60()
        ' <snippet60>
        Dim aString As String = "Left Center Right"
        Dim subString As String

        ' subString = "Center"
        subString = aString.Substring(5, 6)
        ' </snippet60>
    End Sub

    ' 69f94e85-d57c-4ccc-a62a-426e829f5c5e
    ' How to: Create a String from An Array of Char Values (Visual Basic)
    ' <snippet61>
    Private Sub MakeStringFromCharacters()
        Dim characters() As Char = {"a"c, "b"c, "c"c, "d"c}
        Dim alphabet As New String(characters)
    End Sub
    ' </snippet61>

    ' 76675807-eadb-4c08-bd50-e6c6ff4b8ced
    ' How to: Convert Hexadecimal Strings to Numbers
    Public Sub Method62()
        ' <snippet62>
        ' Assign the value 49153 to i.
        Dim i As Integer = Convert.ToInt32("c001", 16)
        ' </snippet62>
    End Sub

    ' 7e4c777c-ad69-46e2-8b9e-9be4033b1c96
    ' Strings in Visual Basic
    Public Sub Method63()
        ' <snippet63>
        Dim MyString As String
        MyString = "This is an example of the String data type"
        ' </snippet63>
    End Sub

    Public Sub Method64()
        ' <snippet64>
        Dim OneString As String
        Dim TwoString As String
        OneString = "one, two, three, four, five"

        ' Evaluates to "two".
        TwoString = OneString.Substring(5, 3)
        OneString = "1"

        ' Evaluates to "11".
        TwoString = OneString & "1"
        ' </snippet64>
    End Sub

    Public Sub Method65()
        ' <snippet65>
        Dim myString As String

        ' This line would cause an error.
        ' myString = "He said, "Look at this example!""
        ' </snippet65>

        ' <snippet66>
        ' The value of myString is: He said, "Look at this example!"
        myString = "He said, ""Look at this example!"""
        ' </snippet66>
    End Sub

    Public Sub Method67()
        ' <snippet67>
        Dim myString As String = "ABCDE"
        Dim myChar As Char

        ' The value of myChar is "D".
        myChar = myString.Chars(3)
        ' </snippet67>
    End Sub

    Public Sub Method68()
        ' <snippet68>
        Dim myString As String = "abcdefghijklmnop"
        Dim myArray As Char() = myString.ToCharArray
        ' </snippet68>
    End Sub

    Public Sub Method69()
        ' <snippet69>
        Dim myString As String = "This string is immutable"
        myString = "Or is it?"
        ' </snippet69>
    End Sub

    ' 9c042880-aa16-432e-9ccb-cd00abda9ae3
    ' How to: Create Strings Using a StringBuilder in Visual Basic
    ' <snippet70>
    Private Function StringBuilderTest() As String
        Dim builder As New System.Text.StringBuilder
        For i As Integer = 1 To 1000
            builder.Append("Step " & i & vbCrLf)
        Next
        Return builder.ToString
    End Function
    ' </snippet70>

    ' ae4c79e0-08ea-489f-bdb2-5eb6d355f284
    ' How to: Search within a String (Visual Basic)
    Public Sub Method71()
        ' <snippet71>
        Dim SearchWithinThis As String = "ABCDEFGHIJKLMNOP"
        Dim SearchForThis As String = "DEF"
        Dim FirstCharacter As Integer = SearchWithinThis.IndexOf(SearchForThis)
        ' </snippet71>
    End Sub

    ' d0dc8317-9ab3-4324-99f7-3f5788c0e72a
    ' How to: Convert an Array of Bytes into a String in Visual Basic
    ' <snippet72>
    Private Function UnicodeBytesToString(
        ByVal bytes() As Byte) As String

        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function
    ' </snippet72>

    ' d1a8ccb1-1335-4825-a3dd-8143e68782f3
    ' How to: Generate Multiline String Literals (Visual Basic)
    Public Sub Method73()
        ' <snippet73>
        Dim MyString As String
        MyString = "This is the first line of my string." & VbCrLf &
                   "This is the second line of my string." & VbCrLf &
                   "This is the third line of my string."
        ' </snippet73>
    End Sub

    ' f477d35c-a3fc-4a30-b1d4-cd0d353aae1d
    ' How to: Convert Strings into an Array of Bytes in Visual Basic
    ' <snippet74>
    Private Function UnicodeStringToBytes(
        ByVal str As String) As Byte()

        Return System.Text.Encoding.Unicode.GetBytes(str)
    End Function
    ' </snippet74>

End Class
