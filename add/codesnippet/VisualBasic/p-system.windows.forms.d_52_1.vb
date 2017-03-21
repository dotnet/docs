   Public Sub New()
      ' Create a new DateTimePicker.
      Dim dateTimePicker1 As New DateTimePicker()
      Controls.AddRange(New Control() {dateTimePicker1})
      dateTimePicker1.CalendarFont = New Font("Courier New", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CType(0, [Byte]))
   End Sub