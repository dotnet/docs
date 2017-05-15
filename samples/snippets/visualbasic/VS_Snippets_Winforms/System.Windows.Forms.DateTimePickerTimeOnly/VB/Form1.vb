 '<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()
        InitializeTimePicker()

    End Sub
    '<snippet4>
    Private timePicker As DateTimePicker


    Private Sub InitializeTimePicker()
        timePicker = New DateTimePicker()
        '<snippet2>
        timePicker.Format = DateTimePickerFormat.Time
        '</snippet2>
        '<snippet3>
        timePicker.ShowUpDown = True
        '</snippet3>
        timePicker.Location = New Point(10, 10)
        timePicker.Width = 100
        Controls.Add(timePicker)

    End Sub

    '</snippet4>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub
End Class
'</snippet1>