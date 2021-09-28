Module Module1

    Sub Main()
        ' Passing arguments by position.
        ' <Snippet2>
        StudentInfo.Display("Mary", 19, #9/21/1998#)
        ' </Snippet2>

        ' Passing arguments by position and omitting optional arguments.
        ' <Snippet3>
        StudentInfo.Display("Mary",, #9/21/1998#)
        ' </Snippet3>

        ' Passing arguments by name.
        ' <Snippet4>
        StudentInfo.Display(age:=19, birth:=#9/21/1998#, name:="Mary")
        ' </Snippet4>

        ' Passing arguments by name and position.
        ' <Snippet5>
        StudentInfo.Display("Mary", birth:=#9/21/1998#)
        ' </Snippet5>

        ' Passing arguments by name and position with an ending positional argument.
        ' <Snippet6>
        StudentInfo.Display("Mary", age:=19, #9/21/1998#)
        ' </Snippet6>

        ' <Snippet8>
        Dim p = New Person("Mary", father:=Nothing, mother:=Nothing, #9/21/1998#)
        ' </Snippet8>
        Console.ReadLine()
    End Sub

End Module

' <Snippet1>
Public Class StudentInfo
    Shared Sub Display(name As String,
                Optional age As Short = 0,
                Optional birth As Date = #1/1/2000#)

        Console.WriteLine($"Name = {name}; age = {age}; birth date = {birth:d}")
    End Sub
End Class
' </Snippet1>

Public Class Person
    ' <Snippet7>
    Public Sub New(name As String, father As Person, mother As Person, dateOfBirth As Date)
        ' </Snippet7>

    End Sub
End Class

