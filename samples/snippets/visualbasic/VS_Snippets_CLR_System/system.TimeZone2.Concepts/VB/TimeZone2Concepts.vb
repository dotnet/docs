' Visual Basic .NET Document
' TimeZone concepts
Option Strict On

Imports System.Collections.ObjectModel
Imports System.Security

' Note that this source code file includes a code module (modMain) and
' a WinForm. 
<Assembly: CLSCompliant(True)>
Module modMain

    Public Sub Main()
        '      IterateTimeZones()
        '      SelectTimeZone()
        ShowDaylightStatus()
        Console.WriteLine(vbCrLf & "ShowLocalAndUtcTime:")
        ShowLocalAndUtcTime()
        ConvertToArbitraryTime()
        Console.WriteLine("ConvertToUtc:")
        ConvertToUtc()
        Console.WriteLine()
        Console.WriteLine("ConvertEasternToUtc:")
        ConvertEasternToUtc()
        Console.WriteLine(vbCrLf & "ConvertUtcToCentral:")
        ConvertUtcToCentral()
        Console.WriteLine(vbCrLf & "ConvertHawaiianToLocal:")
        ConvertHawaiianToLocal()
        Console.WriteLine("Resolving ambiguous times:")
        Console.WriteLine(ResolveAmbiguousTime(#10/29/2006 2:03:15AM#))
        Console.WriteLine(ResolveAmbiguousTime(Date.Now))
        Console.WriteLine()
        Console.WriteLine("GetUserDateInput:")
        GetUserDateInput()
    End Sub

    Private Sub IterateTimeZones
        ' Iterate the time zones found on a system
        ' <Snippet1>
        Dim tzCollection As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones
        ' </Snippet1>   

        Console.WriteLine("Listing {0} time zones found on the system:", tzCollection.Count)
        ' <Snippet12>
        For Each timeZone As TimeZoneInfo In tzCollection
            Console.WriteLine("   {0}: {1}", timeZone.Id, timeZone.DisplayName)
        Next
        ' </Snippet12>
    End Sub

    Private Sub SelectTimeZone()
        Dim frm As New TZListForm()
        frm.ShowDialog()
    End Sub

    Private Sub ShowDaylightStatus()
        ' 
        ' <Snippet3>
        Dim dateToday As Date = Date.Now
        Dim differenceFromUtc As TimeSpan = TimeZoneInfo.Local.GetUtcOffset(dateToday)
        Console.WriteLine("The time is {0:t} in {1} time, {2:##.0} hours {3} universal time", _
                          dateToday, _
                          IIf(TimeZoneInfo.Local.IsDaylightSavingTime(dateToday), "daylight saving", "standard"), _
                          Math.Abs(differenceFromUtc.TotalHours), _
                          IIf(differenceFromUtc.Hours > 0, "after", "earlier than"))
        ' </Snippet3>
    End Sub

    Private Sub ShowLocalAndUtcTime
        ' <Snippet4>
        Dim timeNow As Date = Date.Now
        Console.WriteLine("It is now {0:t} {1}, or {2:t} {3}.", _
                          timeNow, _
                          IIf(TimeZoneInfo.Local.IsDaylightSavingTime(timeNow), _
                              TimeZoneInfo.Local.DaylightName, TimeZoneInfo.Local.StandardName), _
                          TimeZoneInfo.ConvertTime(timeNow, TimeZoneInfo.Local, TimeZoneInfo.Utc), _
                          TimeZoneInfo.Utc.StandardName)
        ' </Snippet4>                        
    End Sub

    Private Sub ConvertToArbitraryTime()
        ' <Snippet5>
        Dim timeNow As Date = Date.Now
        Try
            Dim easternZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
            Dim easternTimeNow As Date = TimeZoneInfo.ConvertTime(timeNow, TimeZoneInfo.Local, easternZone)
            Console.WriteLine("{0} {1} corresponds to {2} {3}.", _
                              timeNow, _
                              IIf(TimeZoneInfo.Local.IsDaylightSavingTime(timeNow), _
                                  TimeZoneInfo.Local.DaylightName, TimeZoneInfo.Local.StandardName), _
                              easternTimeNow, _
                              IIf(easternZone.IsDaylightSavingTime(easternTimeNow), _
                                  easternZone.DaylightName, easternZone.StandardName))
            ' Handle exception
            '
            ' As an alternative to simply displaying an error message, an alternate Eastern
            ' Standard Time TimeZoneInfo object could be instantiated here either by restoring
            ' it from a serialized string or by providing the necessary data to the
            ' CreateCustomTimeZone method.
        Catch e As TimeZoneNotFoundException
            Console.WriteLine("The Eastern Standard Time Zone cannot be found on the local system.")
        Catch e As InvalidTimeZoneException
            Console.WriteLine("The Eastern Standard Time Zone contains invalid or missing data.")
        Catch e As SecurityException
            Console.WriteLine("The application lacks permission to read time zone information from the registry.")
        Catch e As OutOfMemoryException
            Console.WriteLine("Not enough memory is available to load information on the Eastern Standard Time zone.")
            ' If we weren't passing FindSystemTimeZoneById a literal string, we also 
            ' would handle an ArgumentNullException.
        End Try
        ' </Snippet5>
    End Sub

    Private Sub ConvertToUtc()
        ' <Snippet6>
        Dim dateNow As Date = Date.Now
        Console.WriteLine("The date and time are {0} UTC.", _
                          TimeZoneInfo.ConvertTimeToUtc(dateNow))
        ' </Snippet6>
    End Sub

    Private Sub ConvertEasternToUtc()
        ' <Snippet7>
        Dim easternTime As New Date(2007, 01, 02, 12, 16, 00)
        Dim easternZoneId As String = "Eastern Standard Time"
        Try
            Dim easternZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId)
            Console.WriteLine("The date and time are {0} UTC.", _
                              TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone))
        Catch e As TimeZoneNotFoundException
            Console.WriteLine("Unable to find the {0} zone in the registry.", _
                              easternZoneId)
        Catch e As InvalidTimeZoneException
            Console.WriteLine("Registry data on the {0} zone has been corrupted.", _
                              easternZoneId)
        End Try
        ' </Snippet7>
    End Sub

    Private Sub ConvertUtcToCentral()
        ' <Snippet8>
        Dim timeUtc As Date = Date.UtcNow
        Try
            Dim cstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
            Dim cstTime As Date = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone)
            Console.WriteLine("The date and time are {0} {1}.", _
                              cstTime, _
                              IIf(cstZone.IsDaylightSavingTime(cstTime), _
                                  cstZone.DaylightName, cstZone.StandardName))
        Catch e As TimeZoneNotFoundException
            Console.WriteLine("The registry does not define the Central Standard Time zone.")
        Catch e As InvalidTimeZoneException
            Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.")
        End Try
        ' </Snippet8>
    End Sub

    Private Sub ConvertHawaiianToLocal()
        ' <Snippet9>
        Dim hwTime As Date = #2/01/2007 8:00:00 AM#
        Try
            Dim hwZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time")
            Console.WriteLine("{0} {1} is {2} local time.", _
                              hwTime, _
                              IIf(hwZone.IsDaylightSavingTime(hwTime), hwZone.DaylightName, hwZone.StandardName), _
                              TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local))
        Catch e As TimeZoneNotFoundException
            Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.")
        Catch e As InvalidTimeZoneException
            Console.WriteLine("Registry data on the Hawaiian Standard Time zone has been corrupted.")
        End Try
        ' </Snippet9>
    End Sub

    Private Sub IllustrateUtcAndLocal()
        ' Create Eastern Standard Time value and TimeZoneInfo object      
        Dim estTime As Date = #01/01/2007 00:00:00#
        Dim est As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")

        ' Convert EST to local time
        Dim localTime As Date = TimeZoneInfo.ConvertTime(estTime, est, TimeZoneInfo.Local)
        Console.WriteLine("At {0} {1}, the local time is {2} {3}.", _
                estTime, _
                est, _
                localTime, _
                IIf(TimeZoneInfo.Local.IsDaylightSavingTime(localTime), _
                    TimeZoneInfo.Local.DaylightName, _
                    TimeZoneInfo.Local.StandardName))

        ' Convert EST to UTC
        Dim utcTime As Date = TimeZoneInfo.ConvertTime(estTime, est, TimeZoneInfo.Utc)
        Console.WriteLine("At {0} {1}, the time is {2} {3}.", _
                estTime, _
                est, _
                utcTime, _
                TimeZoneInfo.Utc.StandardName)
    End Sub

    ' Map an ambiguous time to the time zone's standard time
    ' <Snippet10>
    Private Function ResolveAmbiguousTime(ambiguousTime As Date) As Date
        ' Time is not ambiguous
        If Not TimeZoneInfo.Local.IsAmbiguousTime(ambiguousTime) Then
            Return TimeZoneInfo.ConvertTimeToUtc(ambiguousTime)
            ' Time is ambiguous
        Else
            Dim utcTime As Date = DateTime.SpecifyKind(ambiguousTime - TimeZoneInfo.Local.BaseUtcOffset, DateTimeKind.Utc)
            Console.WriteLine("{0} local time corresponds to {1} {2}.", ambiguousTime, utcTime, utcTime.Kind.ToString())
            Return utcTime
        End If
    End Function
    ' </Snippet10>

    ' Allow the user to resolve an ambiguous time
    ' <Snippet11>
    Private Sub GetUserDateInput()
        ' Get date and time from user
        Dim inputDate As Date = GetUserDateTime()
        Dim utcDate As Date

        ' Exit if date has no significant value
        If inputDate = Date.MinValue Then Exit Sub

        If TimeZoneInfo.Local.IsAmbiguousTime(inputDate) Then
            Console.WriteLine("The date you've entered is ambiguous.")
            Console.WriteLine("Please select the correct offset from Universal Coordinated Time:")
            Dim offsets() As TimeSpan = TimeZoneInfo.Local.GetAmbiguousTimeOffsets(inputDate)
            For ctr As Integer = 0 to offsets.Length - 1
                Dim zoneDescription As String
                If offsets(ctr).Equals(TimeZoneInfo.Local.BaseUtcOffset) Then
                    zoneDescription = TimeZoneInfo.Local.StandardName
                Else
                    zoneDescription = TimeZoneInfo.Local.DaylightName
                End If
                Console.WriteLine("{0}.) {1} hours, {2} minutes ({3})", _
                                  ctr, offsets(ctr).Hours, offsets(ctr).Minutes, zoneDescription)
            Next
            Console.Write("> ")
            Dim selection As Integer = CInt(Console.ReadLine())

            ' Convert local time to UTC, and set Kind property to DateTimeKind.Utc
            utcDate = Date.SpecifyKind(inputDate - offsets(selection), DateTimeKind.Utc)

            Console.WriteLine("{0} local time corresponds to {1} {2}.", inputDate, utcDate, utcDate.Kind.ToString())
        Else
            utcDate = inputDate.ToUniversalTime()
            Console.WriteLine("{0} local time corresponds to {1} {2}.", inputDate, utcDate, utcDate.Kind.ToString())
        End If
    End Sub

    Private Function GetUserDateTime() As Date
        Dim exitFlag As Boolean = False            ' flag to exit loop if date is valid
        Dim dateString As String
        Dim inputDate As Date = Date.MinValue

        Console.Write("Enter a local date and time: ")
        Do While Not exitFlag
            dateString = Console.ReadLine()
            If dateString.ToUpper = "E" Then exitFlag = True
            If Date.TryParse(dateString, inputDate) Then
                exitFlag = true
            Else
                Console.Write("Enter a valid date and time, or enter 'e' to exit: ")
            End If
        Loop

        Return inputDate
    End Function
    ' </Snippet11>
End Module

Public Class TZListForm : Inherits System.Windows.Forms.Form

    Friend WithEvents timeZoneList As System.Windows.Forms.ListBox
    Friend WithEvents OkButton As System.Windows.Forms.Button

    Public Sub New()
        Me.timeZoneList = New System.Windows.Forms.ListBox
        Me.OkButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'timeZoneList
        '
        Me.timeZoneList.FormattingEnabled = True
        Me.timeZoneList.Location = New System.Drawing.Point(21, 12)
        Me.timeZoneList.Name = "timeZoneList"
        Me.timeZoneList.Size = New System.Drawing.Size(239, 212)
        Me.timeZoneList.TabIndex = 0
        '
        'OkButton
        '
        Me.OkButton.Location = New System.Drawing.Point(185, 231)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 1
        Me.OkButton.Text = "&OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.timeZoneList)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub

    ' Display all time zones in a list box that is assigned the object collection
    ' <Snippet2>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tzCollection As ReadOnlyCollection(Of TimeZoneInfo)
        tzCollection = TimeZoneInfo.GetSystemTimeZones()
        Me.timeZoneList.DataSource = tzCollection
    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        Dim selectedTimeZone As TimeZoneInfo = DirectCast(Me.timeZoneList.SelectedItem(), TimeZoneInfo)
        MsgBox("You selected the " & selectedTimeZone.ToString() & " time zone.")
    End Sub
    ' </Snippet2>

    Public Sub ShowLocalAndUtc()
        ' <Snippet13>
        ' Create Eastern Standard Time value and TimeZoneInfo object      
        Dim estTime As Date = #01/01/2007 00:00:00#
        Dim timeZoneName As String = "Eastern Standard Time"
        Try
            Dim est As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName)

            ' Convert EST to local time
            Dim localTime As Date = TimeZoneInfo.ConvertTime(estTime, est, TimeZoneInfo.Local)
            Console.WriteLine("At {0} {1}, the local time is {2} {3}.", _
                    estTime, _
                    est, _
                    localTime, _
                    IIf(TimeZoneInfo.Local.IsDaylightSavingTime(localTime), _
                        TimeZoneInfo.Local.DaylightName, _
                        TimeZoneInfo.Local.StandardName))

            ' Convert EST to UTC
            Dim utcTime As Date = TimeZoneInfo.ConvertTime(estTime, est, TimeZoneInfo.Utc)
            Console.WriteLine("At {0} {1}, the time is {2} {3}.", _
                    estTime, _
                    est, _
                    utcTime, _
                    TimeZoneInfo.Utc.StandardName)
        Catch e As TimeZoneNotFoundException
            Console.WriteLine("The {0} zone cannot be found in the registry.", _
                              timeZoneName)
        Catch e As InvalidTimeZoneException
            Console.WriteLine("The registry contains invalid data for the {0} zone.", _
                              timeZoneName)
        End Try
        ' </Snippet13>
    End Sub
End Class
