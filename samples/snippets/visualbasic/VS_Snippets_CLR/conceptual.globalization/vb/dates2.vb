' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet3>
Imports System.Globalization
Imports System.IO
Imports System.Threading

Module Example4
    Public Sub Main4()
        ' Persist two dates as strings.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Dim dates() As DateTime = {New DateTime(2013, 1, 9),
                                    New DateTime(2013, 8, 18)}
        Dim sw As New StreamWriter("dateData.dat")
        sw.Write("{0:d}|{1:d}", dates(0), dates(1))
        sw.Close()

        ' Read the persisted data.
        Dim sr As New StreamReader("dateData.dat")
        Dim dateData As String = sr.ReadToEnd()
        sr.Close()
        Dim dateStrings() As String = dateData.Split("|"c)

        ' Restore and display the data using the conventions of the en-US culture.
        Console.WriteLine("Current Culture: {0}",
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        For Each dateStr In dateStrings
            Dim restoredDate As Date
            If Date.TryParse(dateStr, restoredDate) Then
                Console.WriteLine("The date is {0:D}", restoredDate)
            Else
                Console.WriteLine("ERROR: Unable to parse {0}", dateStr)
            End If
        Next
        Console.WriteLine()

        ' Restore and display the data using the conventions of the en-GB culture.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB")
        Console.WriteLine("Current Culture: {0}",
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        For Each dateStr In dateStrings
            Dim restoredDate As Date
            If Date.TryParse(dateStr, restoredDate) Then
                Console.WriteLine("The date is {0:D}", restoredDate)
            Else
                Console.WriteLine("ERROR: Unable to parse {0}", dateStr)
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'       Current Culture: English (United States)
'       The date is Wednesday, January 09, 2013
'       The date is Sunday, August 18, 2013
'       
'       Current Culture: English (United Kingdom)
'       The date is 01 September 2013
'       ERROR: Unable to parse 8/18/2013
' </Snippet3>
