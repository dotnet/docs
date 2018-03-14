Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    ' <Snippet1>
    Public Sub CreateMyDateTimePicker()
        ' Create a new DateTimePicker control and initialize it.
        Dim dateTimePicker1 As New DateTimePicker()
        
        ' Set the MinDate and MaxDate.
        dateTimePicker1.MinDate = New DateTime(1985, 6, 20)
        dateTimePicker1.MaxDate = DateTime.Today
        
        ' Set the CustomFormat string.
        dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"
        dateTimePicker1.Format = DateTimePickerFormat.Custom
        
        ' Show the CheckBox and display the control as an up-down control.
        dateTimePicker1.ShowCheckBox = True
        dateTimePicker1.ShowUpDown = True
    End Sub 'CreateMyDateTimePicker
    ' </Snippet1>
End Class 'Form1 

