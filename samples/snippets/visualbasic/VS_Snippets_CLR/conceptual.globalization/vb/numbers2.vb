' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Globalization
Imports System.IO
Imports System.Threading

Module Example15
    Public Sub Main15()
        ' Create ten random doubles.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Dim numbers() As Double = GetRandomNumbers(10)
        DisplayRandomNumbers(numbers)

        ' Persist the numbers as strings.
        Dim sw As New StreamWriter("randoms.dat")
        For ctr As Integer = 0 To numbers.Length - 1
            sw.Write("{0:R}{1}", numbers(ctr), If(ctr < numbers.Length - 1, "|", ""))
        Next
        sw.Close()

        ' Read the persisted data.
        Dim sr As New StreamReader("randoms.dat")
        Dim numericData As String = sr.ReadToEnd()
        sr.Close()
        Dim numberStrings() As String = numericData.Split("|"c)

        ' Restore and display the data using the conventions of the en-US culture.
        Console.WriteLine("Current Culture: {0}",
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        For Each numberStr In numberStrings
            Dim restoredNumber As Double
            If Double.TryParse(numberStr, restoredNumber) Then
                Console.WriteLine(restoredNumber.ToString("R"))
            Else
                Console.WriteLine("ERROR: Unable to parse '{0}'", numberStr)
            End If
        Next
        Console.WriteLine()

        ' Restore and display the data using the conventions of the fr-FR culture.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR")
        Console.WriteLine("Current Culture: {0}",
                          Thread.CurrentThread.CurrentCulture.DisplayName)
        For Each numberStr In numberStrings
            Dim restoredNumber As Double
            If Double.TryParse(numberStr, restoredNumber) Then
                Console.WriteLine(restoredNumber.ToString("R"))
            Else
                Console.WriteLine("ERROR: Unable to parse '{0}'", numberStr)
            End If
        Next
    End Sub

    Private Function GetRandomNumbers(n As Integer) As Double()
        Dim rnd As New Random()
        Dim numbers(n - 1) As Double
        For ctr As Integer = 0 To n - 1
            numbers(ctr) = rnd.NextDouble * 1000
        Next
        Return numbers
    End Function

    Private Sub DisplayRandomNumbers(numbers As Double())
        For ctr As Integer = 0 To numbers.Length - 1
            Console.WriteLine(numbers(ctr).ToString("R"))
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays output like the following:
'       487.0313743534644
'       674.12000879371533
'       498.72077885024288
'       42.3034229512808
'       970.57311049223563
'       531.33717716268131
'       587.82905693530529
'       562.25210175023039
'       600.7711019370571
'       299.46113717717174
'       
'       Current Culture: English (United States)
'       487.0313743534644
'       674.12000879371533
'       498.72077885024288
'       42.3034229512808
'       970.57311049223563
'       531.33717716268131
'       587.82905693530529
'       562.25210175023039
'       600.7711019370571
'       299.46113717717174
'       
'       Current Culture: French (France)
'       ERROR: Unable to parse '487.0313743534644'
'       ERROR: Unable to parse '674.12000879371533'
'       ERROR: Unable to parse '498.72077885024288'
'       ERROR: Unable to parse '42.3034229512808'
'       ERROR: Unable to parse '970.57311049223563'
'       ERROR: Unable to parse '531.33717716268131'
'       ERROR: Unable to parse '587.82905693530529'
'       ERROR: Unable to parse '562.25210175023039'
'       ERROR: Unable to parse '600.7711019370571'
'       ERROR: Unable to parse '299.46113717717174'
' </Snippet6>
