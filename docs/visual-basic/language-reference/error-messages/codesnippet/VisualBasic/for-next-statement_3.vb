        For indexA = 1 To 3
            ' Create a new StringBuilder, which is used
            ' to efficiently build strings.
            Dim sb As New System.Text.StringBuilder()

            ' Append to the StringBuilder every third number
            ' from 20 to 1 descending.
            For indexB = 20 To 1 Step -3
                sb.Append(indexB.ToString)
                sb.Append(" ")
            Next indexB

            ' Display the line.
            Debug.WriteLine(sb.ToString)
        Next indexA
        ' Output:
        '  20 17 14 11 8 5 2
        '  20 17 14 11 8 5 2
        '  20 17 14 11 8 5 2