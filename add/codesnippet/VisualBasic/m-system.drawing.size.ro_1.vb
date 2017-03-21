    Private Sub TruncateAndRoundSizes()

        ' Create a SizeF.
        Dim theSize As New SizeF(75.9, 75.9)

        ' Round the Size.
        Dim roundedSize As Size = Size.Round(theSize)

        ' Truncate the Size.
        Dim truncatedSize As Size = Size.Truncate(theSize)

        'Print out the values on two labels.
        Label1.Text = "Rounded size = " & roundedSize.ToString()
        Label2.Text = "Truncated size = " & truncatedSize.ToString

    End Sub