' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module IsLeapYear
   Public Sub Main()
      For year As Integer = 1994 to 2014
         If DateTime.IsLeapYear(year) Then
            Console.WriteLine("{0} is a leap year.", year)
            Dim leapDay As New Date(year, 2, 29)
            Dim nextYear As Date = leapDay.AddYears(1)
            Console.WriteLine("   One year from {0} is {1}.", _
                              leapDay.ToString("d"), _
                              nextYear.ToString("d"))
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'       1996 is a leap year.
'          One year from 2/29/1996 is 2/28/1997.
'       2000 is a leap year.
'          One year from 2/29/2000 is 2/28/2001.
'       2004 is a leap year.
'          One year from 2/29/2004 is 2/28/2005.
'       2008 is a leap year.
'          One year from 2/29/2008 is 2/28/2009.
'       2012 is a leap year.
'          One year from 2/29/2012 is 2/28/2013.
' </Snippet1>

