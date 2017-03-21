
    ' When the calendar drops down, display a MessageBox indicating 
    ' that DateTimePicker will not accept dates before MinDateTime or 
    ' after MaxDateTime. Use a StringBuilder object to build the string
    ' for efficiency.
    Private Sub DateTimePicker1_DropDown(ByVal sender As Object, _
        ByVal e As EventArgs) Handles DateTimePicker1.DropDown

        Dim messageBuilder As New System.Text.StringBuilder
        messageBuilder.Append("Choose a date after: ")
        messageBuilder.Append(DateTimePicker.MinDateTime.ToShortDateString)
        messageBuilder.Append(" and a date before: ")
        messageBuilder.Append(DateTimePicker.MaxDateTime.ToShortDateString)
        MessageBox.Show(messageBuilder.ToString())
    End Sub