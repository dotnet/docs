' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cal As New UmAlQuraCalendar()
      Dim months As New List(Of String)
      Dim output As String = String.Empty
      
      ' Get the current year in the UmAlQura calendar.
      Dim startYear As Integer = cal.GetYear(Date.Now)
      ' Display the number of days in each month for the next five years.
      Console.WriteLine("          Days in Each Month, {0} to {1}",
                        startYear, startYear + 4)
      Console.WriteLine()
      Console.WriteLine("Month     {0}     {1}     {2}     {3}     {4}",
                        startYear, startYear + 1, startYear + 2, 
                        startYear + 3, startYear + 4)
      For year As Integer = startYear To startYear + 4
         Dim days As Integer
         For month As Integer = 1 To _
                   cal.GetMonthsInYear(year, UmAlQuraCalendar.UmALQuraEra)
            days = cal.GetDaysInMonth(year, month, 
                                      UmAlQuraCalendar.UmALQuraEra)
            output = String.Format("{0}     ", days)
            If months.Count < month Then
               months.Add(String.Format("{0,4}        {1}", 
                                        month, output))
            Else
               months.Item(month - 1) += "  " + output
            End If
         Next         
      Next                  
      
      For Each item In months
         Console.WriteLine(item)
      Next   
   End Sub
End Module
' The example displays the following output:
'                 Days in Each Month, 1431 to 1435
'       
'       Month     1431     1432     1433     1434     1435
'          1        29       29       30       29       30
'          2        30       30       29       30       29
'          3        30       30       30       29       30
'          4        29       30       30       30       29
'          5        30       29       29       29       30
'          6        29       30       30       30       29
'          7        30       29       30       30       30
'          8        29       30       29       29       29
'          9        30       29       30       30       30
'         10        29       30       29       30       30
'         11        29       29       30       29       29
'         12        30       29       29       29       30
' </Snippet1>

