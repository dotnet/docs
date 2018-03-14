
        Dim classGrades = New System.Collections.Generic.List(Of Integer) From {63, 68, 71, 75, 68, 92, 75}

        Dim distinctQuery = From grade In classGrades 
                            Select grade Distinct

        Dim sb As New System.Text.StringBuilder("The distinct grades are: ")
        For Each number As Integer In distinctQuery
            sb.Append(number & " ")
        Next

        ' Display the results.
        MsgBox(sb.ToString())

        ' This code produces the following output:

        ' The distinct grades are: 63 68 71 75 92 
