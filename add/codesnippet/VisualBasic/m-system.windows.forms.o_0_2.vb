    ' Gets the caret width based upon the operating system or default value.
    Private Function GetCaretWidth() As Integer

        ' Check to see if the operating system supports the caret width metric. 
        If OSFeature.IsPresent(SystemParameter.CaretWidthMetric) Then

            ' If the operating system supports this metric,
            ' return the value for the caret width metric. 

            Return SystemInformation.CaretWidth
        Else

            ' If the operating system does not support this metric,
            ' return a custom default value for the caret width.

            Return 1
        End If
    End Function