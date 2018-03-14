    Private Sub TestParameters()
        ' Call the procedure with its arguments passed by position,
        studentInfo("Mary", 19, #9/21/1981#)

        ' Omit one optional argument by holding its place with a comma.
        studentInfo("Mary", , #9/21/1981#)

        ' Call the procedure with its arguments passed by name.
        studentInfo(age:=19, birth:=#9/21/1981#, name:="Mary")

        ' Supply an argument by position and an argument by name.
        studentInfo("Mary", birth:=#9/21/1981#)
    End Sub

    Private Sub studentInfo(ByVal name As String,
       Optional ByVal age As Short = 0,
       Optional ByVal birth As Date = #1/1/2000#)

        Console.WriteLine("name: " & name)
        Console.WriteLine("age: " & age)
        Console.WriteLine("birth date: " & birth)
        Console.WriteLine()
    End Sub