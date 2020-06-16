' Visual Basic .NET Document
Option Strict On

Module modMain

    Public Sub Main()
        ShowSchedule()             ' Add method
        Console.WriteLine("----------")
        ShowStartOfWorkWeek()      ' AddDays method
        Console.WriteLine("----------")
        ShowShiftStartTimes()
        Console.WriteLine("----------")
        ShowQuarters()
        Console.WriteLine("----------")
        DisplayTimes()
        Console.WriteLine("----------")
        ShowLegalLicenseAge()
        Console.WriteLine("----------")
        CompareForEquality1()
        Console.WriteLine("----------")
        CompareForEquality2()
        Console.WriteLine("----------")
        CompareForEquality3()
        Console.WriteLine("----------")
        CompareExactly()
        Console.WriteLine("----------")
        Subtract1()
        Console.WriteLine("----------")
        Subtract2()
        Console.WriteLine("----------")
        ConvertToLocal()
        Console.WriteLine("----------")
        ''      ConvertOffsets()
        Console.WriteLine("----------")
        ConvertToUniversal()
        Console.WriteLine("----------")

    End Sub

    Private Sub ShowSchedule()
        ' <Snippet1>
        Dim takeOff As New DateTimeOffset(#6/1/2007 7:55AM#, _
                                          New TimeSpan(-5, 0, 0))
        Dim currentTime As DateTimeOffset = takeOff
        Dim flightTimes() As TimeSpan = New TimeSpan() _
                          {New TimeSpan(2, 25, 0), New TimeSpan(1, 48, 0)}
        Console.WriteLine("Takeoff is scheduled for {0:d} at {0:T}.", _
                          takeOff)
        For ctr As Integer = flightTimes.GetLowerBound(0) To _
                             flightTimes.GetUpperBound(0)
            currentTime = currentTime.Add(flightTimes(ctr))
            Console.WriteLine("Destination #{0} at {1}.", ctr + 1, currentTime)
        Next
        ' </Snippet1>
    End Sub

    Private Sub ShowStartOfWorkWeek()
        ' <Snippet2>
        Dim workDay As New DateTimeOffset(#3/1/2008 9:00AM#, _
                           DateTimeOffset.Now.Offset)
        Dim month As Integer = workDay.Month
        ' Start with the first Monday of the month
        If workDay.DayOfWeek <> DayOfWeek.Monday Then
            If workDay.DayOfWeek = DayOfWeek.Sunday Then
                workDay = workDay.AddDays(1)
            Else
                workDay = workDay.AddDays(8 - CInt(workDay.DayOfWeek))
            End If
        End If
        Console.WriteLine("Beginning of Work Week In {0:MMMM} {0:yyyy}:", workDay)
        ' Add one week to the current date 
        Do While workDay.Month = month
            Console.WriteLine("   {0:dddd}, {0:MMMM}{0: d}", workDay)
            workDay = workDay.AddDays(7)
        Loop
        ' The example produces the following output:
        '    Beginning of Work Week In March 2008:
        '       Monday, March 3
        '       Monday, March 10
        '       Monday, March 17
        '       Monday, March 24
        '       Monday, March 31             
        ' </Snippet2>                      
    End Sub

    Private Sub ShowShiftStartTimes()
        ' <Snippet3>                      
        Const SHIFT_LENGTH As Integer = 8

        Dim startTime As New DateTimeOffset(#8/6/2007 12:00:00AM#, _
                             DateTimeOffset.Now.Offset)
        Dim startOfShift As DateTimeOffset = startTime.AddHours(SHIFT_LENGTH)

        Console.WriteLine("Shifts for the week of {0:D}", startOfShift)
        Do
            ' Exclude third shift
            If startOfShift.Hour > 6 Then _
               Console.WriteLine("   {0:d} at {0:T}", startOfShift)

            startOfShift = startOfShift.AddHours(SHIFT_LENGTH)
        Loop While startOfShift.DayOfWeek <> DayOfWeek.Saturday And _
                   startOfShift.DayOfWeek <> DayOfWeek.Sunday

        ' The example produces the following output:
        '
        '    Shifts for the week of Monday, August 06, 2007
        '       8/6/2007 at 8:00:00 AM
        '       8/6/2007 at 4:00:00 PM
        '       8/7/2007 at 8:00:00 AM
        '       8/7/2007 at 4:00:00 PM
        '       8/8/2007 at 8:00:00 AM
        '       8/8/2007 at 4:00:00 PM
        '       8/9/2007 at 8:00:00 AM
        '       8/9/2007 at 4:00:00 PM
        '       8/10/2007 at 8:00:00 AM
        '       8/10/2007 at 4:00:00 PM                 
        ' </Snippet3>                      
    End Sub

    Private Sub ShowQuarters()
        ' <Snippet4>
        Dim quarterDate As New DateTimeOffset(#01/01/2007#, DateTimeOffset.Now.Offset)
        For ctr As Integer = 1 To 4
            Console.WriteLine("Quarter {0}: {1:MMMM d}", ctr, quarterDate)
            quarterDate = quarterDate.AddMonths(3)
        Next
        ' This example produces the following output:
        '       Quarter 1: January 1
        '       Quarter 2: April 1
        '       Quarter 3: July 1
        '       Quarter 4: October 1      
        ' </Snippet4>
    End Sub

    Private Sub DisplayTimes()
        ' <Snippet5>
        Dim lapTimes() As Double = {1.308, 1.283, 1.325, 1.3625, 1.317, 1.267}
        Dim currentTime As New DateTimeOffset(#1:30PM#, DateTimeOffset.Now.Offset)
        Console.WriteLine("Start:    {0:T}", currentTime)
        For ctr As Integer = lapTimes.GetLowerBound(0) To lapTimes.GetUpperBound(0)
            currentTime = currentTime.AddMinutes(lapTimes(ctr))
            Console.WriteLIne("Lap {0}:    {1:T}", ctr + 1, currentTime)
        Next
        ' The example produces the following output:
        '       Start:    1:30:00 PM
        '       Lap 1:    1:31:18 PM
        '       Lap 2:    1:32:35 PM
        '       Lap 3:    1:33:54 PM
        '       Lap 4:    1:35:16 PM
        '       Lap 5:    1:36:35 PM
        '       Lap 6:    1:37:51 PM          
        ' </Snippet5>
    End Sub

    Private Sub ShowLegalLicenseAge()
        ' <Snippet6>
        Const minimumAge As Integer = 16
        Dim dateToday As DateTimeOffset = DateTimeOffset.Now
        Dim latestBirthday As DateTimeOffset = dateToday.AddYears(-1 * minimumAge)
        Console.WriteLine("To possess a driver's license, you must have been born on or before {0:d}.", _
                          latestBirthday)
        ' </Snippet6>                         
    End Sub

    Private Sub CompareForEquality1()
        ' <Snippet9>
        Dim firstTime As New DateTimeOffset(#09/01/2007 6:45:00AM#, _
                         New TimeSpan(-7, 0, 0))

        Dim secondTime As DateTimeOffset = firstTime
        Console.WriteLine("{0} = {1}: {2}", _
                          firstTime, secondTime, _
                          firstTime.Equals(secondTime))

        secondTime = New DateTimeOffset(#09/01/2007 6:45:00AM#, _
                         New TimeSpan(-6, 0, 0))
        Console.WriteLine("{0} = {1}: {2}", _
                         firstTime, secondTime, _
                         firstTime.Equals(secondTime))

        secondTime = New DateTimeOffset(#09/01/2007 8:45:00AM#, _
                         New TimeSpan(-5, 0, 0))
        Console.WriteLine("{0} = {1}: {2}", _
                         firstTime, secondTime, _
                         firstTime.Equals(secondTime))
        ' The example displays the following output to the console:
        '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -07:00: True
        '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -06:00: False
        '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 8:45:00 AM -05:00: True
        ' </Snippet9>
    End Sub

    Private Sub CompareForEquality2()
        ' <Snippet10>
        Dim firstTime As New DateTimeOffset(#09/01/2007 6:45:00AM#, _
                         New TimeSpan(-7, 0, 0))

        Dim secondTime As Object = firstTime
        Console.WriteLine("{0} = {1}: {2}", _
                          firstTime, secondTime, _
                          firstTime.Equals(secondTime))

        secondTime = New DateTimeOffset(#09/01/2007 6:45:00AM#, _
                         New TimeSpan(-6, 0, 0))
        Console.WriteLine("{0} = {1}: {2}", _
                         firstTime, secondTime, _
                         firstTime.Equals(secondTime))

        secondTime = New DateTimeOffset(#09/01/2007 8:45:00AM#, _
                         New TimeSpan(-5, 0, 0))
        Console.WriteLine("{0} = {1}: {2}", _
                         firstTime, secondTime, _
                         firstTime.Equals(secondTime))

        secondTime = Nothing
        Console.WriteLine("{0} = {1}: {2}", _
                         firstTime, secondTime, _
                         firstTime.Equals(secondTime))

        secondTime = #9/1/2007 6:45AM#
        Console.WriteLine("{0} = {1}: {2}", _
                         firstTime, secondTime, _
                         firstTime.Equals(secondTime))

        ' The example displays the following output to the console:
        '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -07:00: True  
        '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -06:00: False 
        '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 8:45:00 AM -05:00: True  
        '       9/1/2007 6:45:00 AM -07:00 = : False                           
        '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM: False          
        ' </Snippet10>
    End Sub

    Private Sub CompareForEquality3()
        ' <Snippet11>
        Dim firstTime As New DateTimeOffset(#11/15/2007 11:35AM#, _
                                            DateTimeOffset.Now.Offset)
        Dim secondTime As DateTimeOffset = firstTime
        Console.WriteLine("{0} = {1}: {2}", _
                          firstTime, secondTime, _
                          DateTimeOffset.Equals(firstTime, secondTime))

        ' The value of firstTime remains unchanged
        secondTime = New DateTimeOffset(firstTime.DateTime, _
                     TimeSpan.FromHours(firstTime.Offset.Hours + 1))
        Console.WriteLine("{0} = {1}: {2}", _
                          firstTime, secondTime, _
                          DateTimeOffset.Equals(firstTime, secondTime))

        ' value of firstTime remains unchanged
        secondTime = New DateTimeOffset(firstTime.DateTime + TimeSpan.FromHours(1), _
                                        TimeSpan.FromHours(firstTime.Offset.Hours + 1))
        Console.WriteLine("{0} = {1}: {2}", _
                          firstTime, secondTime, _
                          DateTimeOffset.Equals(firstTime, secondTime))
        ' The example produces the following output:
        '       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -07:00: True
        '       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -06:00: False
        '       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 12:35:00 PM -06:00: True       
        ' </Snippet11>                        
    End Sub

    Private Sub CompareExactly
        ' <Snippet12>
        Dim instanceTime As New DateTimeOffset(#10/31/2007 12:00AM#, _
                                               DateTimeOffset.Now.Offset)

        Dim otherTime As DateTimeOffset = instanceTime
        Console.WriteLine("{0} = {1}: {2}", _
                          instanceTime, otherTime, _
                          instanceTime.EqualsExact(otherTime))

        otherTime = New DateTimeOffset(instanceTime.DateTime, _
                                       TimeSpan.FromHours(instanceTime.Offset.Hours + 1))
        Console.WriteLine("{0} = {1}: {2}", _
                          instanceTime, otherTime, _
                          instanceTime.EqualsExact(otherTime))

        otherTime = New DateTimeOffset(instanceTime.DateTime + TimeSpan.FromHours(1), _
                                        TimeSpan.FromHours(instanceTime.Offset.Hours + 1))
        Console.WriteLine("{0} = {1}: {2}", _
                          instanceTime, otherTime, _
                          instanceTime.EqualsExact(otherTime))
        ' The example produces the following output:
        '       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -07:00: True
        '       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -06:00: False
        '       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 1:00:00 AM -06:00: False       
        ' </Snippet12>                                                   
    End Sub

    Private Sub Subtract1()
        ' <Snippet13>
        Dim firstDate As New DateTimeOffset(#10/25/2018 6:00PM#, _
                                            New TimeSpan(-7, 0, 0))
        Dim secondDate As New DateTimeOffset(#10/25/2018 6:00PM#, _
                                             New TimeSpan(-5, 0, 0))
        Dim thirdDate As New DateTimeOffset(#9/28/2018 9:00AM#, _
                                            New TimeSpan(-7, 0, 0))
        Dim difference As TimeSpan

        difference = firstDate.Subtract(secondDate)
        Console.WriteLine($"({firstDate}) - ({secondDate}): {difference.Days} days, {difference.Hours}:{difference.Minutes:d2}")

        difference = firstDate.Subtract(thirdDate)
        Console.WriteLine($"({firstDate}) - ({thirdDate}): {difference.Days} days, {difference.Hours}:{difference.Minutes:d2}")

        ' The example produces the following output:
        '    (10/25/2018 6:00:00 PM -07:00) - (10/25/2018 6:00:00 PM -05:00): 0 days, 2:00
        '    (10/25/2018 6:00:00 PM -07:00) - (9/28/2018 9:00:00 AM -07:00): 27 days, 9:00
        ' </Snippet13>   
    End Sub

    Private Sub Subtract2()
        ' <Snippet14>   
        Dim offsetDate As New DateTimeOffset(#12/3/2007 11:30AM#, _
                                       New TimeSpan(-8, 0, 0))
        Dim duration As New TimeSpan(7, 18, 0, 0)
        Console.WriteLine(offsetDate.Subtract(duration))    ' Displays 11/25/2007 5:30:00 PM -08:00
        ' </Snippet14>   
    End Sub

    Private Sub ConvertToLocal()
        ' <Snippet15>
        ' Local time changes on 3/11/2007 at 2:00 AM
        Dim originalTime, localTime As DateTimeOffset

        originalTime = New DateTimeOffset(#03/11/2007 3:00AM#, _
                                          New TimeSpan(-6, 0, 0))
        localTime = originalTime.ToLocalTime()
        Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), _
                                                   localTime.ToString())

        originalTime = New DateTimeOffset(#03/11/2007 4:00AM#, _
                                          New TimeSpan(-6, 0, 0))
        localTime = originalTime.ToLocalTime()
        Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), _
                                                   localTime.ToString())

        ' Define a summer UTC time
        originalTime = New DateTimeOffset(#6/15/2007 8:00AM#, _
                                          TimeSpan.Zero)
        localTime = originalTime.ToLocalTime()
        Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), _
                                                   localTime.ToString())

        ' Define a winter time
        originalTime = New DateTimeOffset(#11/30/2007 2:00PM#, _
                                          New TimeSpan(3, 0, 0))
        localTime = originalTime.ToLocalTime()
        Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), _
                                                   localTime.ToString())
        ' The example produces the following output:
        '    Converted 3/11/2007 3:00:00 AM -06:00 to 3/11/2007 1:00:00 AM -08:00.
        '    Converted 3/11/2007 4:00:00 AM -06:00 to 3/11/2007 3:00:00 AM -07:00.
        '    Converted 6/15/2007 8:00:00 AM +00:00 to 6/15/2007 1:00:00 AM -07:00.
        '    Converted 11/30/2007 2:00:00 PM +03:00 to 11/30/2007 3:00:00 AM -08:00.                                                           
        ' </Snippet15>   
    End Sub

    Private Sub ConvertToUniversal()
        ' <Snippet16>
        Dim localTime, otherTime, universalTime As DateTimeOffset

        ' Define local time in local time zone
        localTime = New DateTimeOffset(#6/15/2007 12:00:00PM#)
        Console.WriteLine("Local time: {0}", localTime)
        Console.WriteLine()

        ' Convert local time to offset 0 and assign to otherTime
        otherTime = localTime.ToOffset(TimeSpan.Zero)
        Console.WriteLine("Other time: {0}", otherTime)
        Console.WriteLine("{0} = {1}: {2}", _
                          localTime, otherTime, _
                          localTime.Equals(otherTime))
        Console.WriteLine("{0} exactly equals {1}: {2}", _
                          localTime, otherTime, _
                          localTime.EqualsExact(otherTime))
        Console.WriteLine()

        ' Convert other time to UTC
        universalTime = localTime.ToUniversalTime()
        Console.WriteLine("Universal time: {0}", universalTime)
        Console.WriteLine("{0} = {1}: {2}", _
                          otherTime, universalTime, _
                          universalTime.Equals(otherTime))
        Console.WriteLine("{0} exactly equals {1}: {2}", _
                          otherTime, universalTime, _
                          universalTime.EqualsExact(otherTime))
        Console.WriteLine()
        ' The example produces the following output to the console:
        '    Local time: 6/15/2007 12:00:00 PM -07:00
        '    
        '    Other time: 6/15/2007 7:00:00 PM +00:00
        '    6/15/2007 12:00:00 PM -07:00 = 6/15/2007 7:00:00 PM +00:00: True
        '    6/15/2007 12:00:00 PM -07:00 exactly equals 6/15/2007 7:00:00 PM +00:00: False
        '    
        '    Universal time: 6/15/2007 7:00:00 PM +00:00
        '    6/15/2007 7:00:00 PM +00:00 = 6/15/2007 7:00:00 PM +00:00: True
        '    6/15/2007 7:00:00 PM +00:00 exactly equals 6/15/2007 7:00:00 PM +00:00: True   
        ' </Snippet16>   
    End Sub
End Module

