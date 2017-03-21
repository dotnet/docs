        Dim output As New System.Text.StringBuilder
        ' Iterate through each IGrouping in the Lookup and output the contents.
        For Each packageGroup As IGrouping(Of Char, String) In lookup
            ' Print the key value of the IGrouping.
            output.AppendLine(packageGroup.Key)
            ' Iterate through each value in the IGrouping and print its value.
            For Each str As String In packageGroup
                output.AppendLine(String.Format("    {0}", str))
            Next
        Next

        ' Display the output.
        MsgBox(output.ToString())