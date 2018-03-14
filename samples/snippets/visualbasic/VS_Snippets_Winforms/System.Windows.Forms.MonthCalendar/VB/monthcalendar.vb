'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    <System.STAThread()> _
    Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub 'Main

    Public Sub New()
        MyBase.New()

        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(48, 488)
        Me.TextBox1.Multiline = True
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(824, 32)

        ' Create the calendar.
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar

        ' Set the calendar location.
        Me.MonthCalendar1.Location = New System.Drawing.Point(47, 16)

        ' Change the color.
        Me.MonthCalendar1.BackColor = System.Drawing.SystemColors.Info
        Me.MonthCalendar1.ForeColor = System.Drawing.Color.FromArgb( _
                                CType(192, System.Byte), CType(0, System.Byte), CType(192, System.Byte))
        Me.MonthCalendar1.TitleBackColor = System.Drawing.Color.Purple
        Me.MonthCalendar1.TitleForeColor = System.Drawing.Color.Yellow
        Me.MonthCalendar1.TrailingForeColor = System.Drawing.Color.FromArgb( _
                                CType(192, System.Byte), CType(192, System.Byte), CType(0, System.Byte))

        ' Add dates to the AnnuallyBoldedDates array.
        Me.MonthCalendar1.AnnuallyBoldedDates = New System.DateTime() _
                     {New System.DateTime(2002, 4, 20, 0, 0, 0, 0), _
                      New System.DateTime(2002, 4, 28, 0, 0, 0, 0), _
                      New System.DateTime(2002, 5, 5, 0, 0, 0, 0), _
                      New System.DateTime(2002, 7, 4, 0, 0, 0, 0), _
                      New System.DateTime(2002, 12, 15, 0, 0, 0, 0), _ 
                      New System.DateTime(2002, 12, 18, 0, 0, 0, 0)}

        ' Add dates to BoldedDates array.
        Me.MonthCalendar1.BoldedDates = New System.DateTime() {New System.DateTime(2002, 9, 26, 0, 0, 0, 0)}

        ' Add dates to MonthlyBoldedDates array.
        Me.MonthCalendar1.MonthlyBoldedDates = New System.DateTime() _
                     {New System.DateTime(2002, 1, 15, 0, 0, 0, 0), _
                      New System.DateTime(2002, 1, 30, 0, 0, 0, 0)}

        ' Configure the calendar to display 3 rows by 4 columns of months.
        Me.MonthCalendar1.CalendarDimensions = New System.Drawing.Size(4, 3)

        ' Set the week to begin on Monday.
        Me.MonthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday

        ' Sets the maximum visible date on the calendar to 12/31/2010.
        Me.MonthCalendar1.MaxDate = New System.DateTime(2010, 12, 31, 0, 0, 0, 0)

        ' Set the minimum visible date on the calendar to 12/31/2010.
        Me.MonthCalendar1.MinDate = New System.DateTime(1999, 1, 1, 0, 0, 0, 0)

        ' Only allow 21 days to be selected at the same time.
        Me.MonthCalendar1.MaxSelectionCount = 21

        ' Set the calendar to move one month at a time when navigating using the arrows.
        Me.MonthCalendar1.ScrollChange = 1

        ' Do not show the "Today" banner.
        Me.MonthCalendar1.ShowToday = False

        ' Do not circle today's date.
        Me.MonthCalendar1.ShowTodayCircle = False

        ' Show the week numbers to the left of each week.
        Me.MonthCalendar1.ShowWeekNumbers = True

        ' Set up how the form should be displayed and add the controls to the form.
        Me.ClientSize = New System.Drawing.Size(920, 566)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox1, Me.MonthCalendar1})
        Me.Text = "Month Calendar Example"

    End Sub

    Private Sub monthCalendar1_DateSelected(ByVal sender As Object, _
                    ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateSelected

        ' Show the start and end dates in the text box.
        Me.TextBox1.Text = "Date Selected: Start = " + _
                e.Start.ToShortDateString() + " : End = " + e.End.ToShortDateString()
    End Sub

    Private Sub monthCalendar1_DateChanged(ByVal sender As Object, _
                    ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged

        ' Show the start and end dates in the text box.
        Me.TextBox1.Text = "Date Changed: Start = " + _
                e.Start.ToShortDateString() + " : End = " + e.End.ToShortDateString()
    End Sub
End Class
'</Snippet1>
