Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        ShowAWeeksVacationOneMonthFromToday()
    End Sub

    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar

    Private Sub InitializeComponent()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.SuspendLayout()
        Me.MonthCalendar1.Location = New System.Drawing.Point(56, 32)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub

    '<snippet1>

    ' Computes a week one month from today.
    Private Sub ShowAWeeksVacationOneMonthFromToday()
         
        Dim today As Date = monthCalendar1.TodayDate
        Dim vacationMonth As Integer = today.Month + 1
        Dim vacationYear As Integer = today.Year
        If (today.Month = 12) Then
            vacationYear += 1
            vacationMonth = 1
        End If

        Me.monthCalendar1.SelectionStart = _
            New Date(vacationYear, vacationMonth, today.Day - 1)
        Me.monthCalendar1.SelectionEnd = _
            New Date(vacationYear, vacationMonth, today.Day + 6)
    End Sub
    '</snippet1>

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class


