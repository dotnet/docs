
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dateTimePicker1 As DateTimePicker
    
    ' <Snippet1>
    Public Sub SetMyCustomFormat()
        ' Set the Format type and the CustomFormat string.
        dateTimePicker1.Format = DateTimePickerFormat.Custom
        dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd"
    End Sub 'SetMyCustomFormat
    ' </Snippet1>
End Class 'Form1 

