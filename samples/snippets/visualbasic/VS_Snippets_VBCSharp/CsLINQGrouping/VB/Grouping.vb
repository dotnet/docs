Module Grouping
    Sub Main(ByVal args As String())
        GroupBy()
    End Sub

    Sub GroupBy()
        ' <Snippet1>

        Dim numbers As New System.Collections.Generic.List(Of Integer)(
             New Integer() {35, 44, 200, 84, 3987, 4, 199, 329, 446, 208})

        Dim query = From number In numbers 
                    Group By Remainder = (number Mod 2) Into Group

        Dim sb As New System.Text.StringBuilder()
        For Each group In query
            sb.AppendLine(If(group.Remainder = 0, vbCrLf & "Even numbers:", vbCrLf & "Odd numbers:"))
            For Each num In group.Group
                sb.AppendLine(num)
            Next
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' Odd numbers:
        ' 35
        ' 3987
        ' 199
        ' 329

        ' Even numbers:
        ' 44
        ' 200
        ' 84
        ' 4
        ' 446
        ' 208

        ' </Snippet1>

    End Sub
End Module