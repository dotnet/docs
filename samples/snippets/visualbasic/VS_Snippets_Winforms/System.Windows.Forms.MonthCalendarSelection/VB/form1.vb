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
        Dim vacationStart = today.AddMonths(1)
        Dim vacationEnd = vacationStart.AddDays(7)

        Me.monthCalendar1.SelectionStart = vacationStart.AddDays(-1)
        Me.monthCalendar1.SelectionEnd = vacationEnd.AddDays(-1)
    End Sub
    '</snippet1>

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class


