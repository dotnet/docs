
    ' Declare the DateTimePicker.
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker


    Private Sub InitializeDateTimePicker()

        ' Construct the DateTimePicker.
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker

        'Set size and location.
        Me.DateTimePicker1.Location = New System.Drawing.Point(40, 88)
        Me.DateTimePicker1.Size = New Size(160, 21)
        
        ' Set the alignment of the drop-down MonthCalendar to right.
        Me.DateTimePicker1.DropDownAlign = LeftRightAlignment.Right

        ' Set the Value property to 50 years before today.
        DateTimePicker1.Value = (DateTime.Now.AddYears(-50))

        'Set a custom format containing the string "of the year"
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "MMM dd, 'of the year' yyyy "

        ' Add the DateTimePicker to the form.
        Me.Controls.Add(Me.DateTimePicker1)
    End Sub