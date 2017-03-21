   Public Sub New()
      ' Create a new DateTimePicker
      Dim dateTimePicker1 As New DateTimePicker()
      Controls.AddRange(New Control() {dateTimePicker1})
      MessageBox.Show(dateTimePicker1.Value.ToString())
      
      dateTimePicker1.Value = DateTime.Now.AddDays(1)
      MessageBox.Show(dateTimePicker1.Value.ToString())
   End Sub 'New