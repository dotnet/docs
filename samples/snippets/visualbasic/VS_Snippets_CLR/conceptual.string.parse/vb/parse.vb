' <snippet1>
Class StringParseMethod
    Public Shared Sub Main()
        ' <snippet2>
        Dim MyString1 As String = "A"
        Dim MyChar As Char = Char.Parse(MyString1)
        ' MyChar now contains a Unicode "A" character.
        ' </snippet2>

        ' <snippet3>
        Dim MyString2 As String = "True"
        Dim MyBool As Boolean = Boolean.Parse(MyString2)
        ' MyBool now contains a True Boolean value.
        ' </snippet3>

        ' <snippet4>
        Dim MyString3 As String = "Thursday"
        Dim MyDays As DayOfWeek = CType([Enum].Parse(GetType(DayOfWeek), MyString3), DayOfWeek)
        Console.WriteLine("{0:G}", MyDays)
        ' The result is Thursday.
        ' </snippet4>
    End Sub
End Class
' </snippet1>
