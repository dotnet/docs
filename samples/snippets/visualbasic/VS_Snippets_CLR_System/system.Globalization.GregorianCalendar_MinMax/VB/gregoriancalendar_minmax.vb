' The following code example gets the minimum date and the maximum date of the calendar.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesCalendar   

   Public Shared Sub Main()

      ' Create an instance of the calendar.
      Dim myCal As New GregorianCalendar()
      Console.WriteLine(myCal.ToString())

      ' Display the MinSupportedDateTime.
      Dim myMin As DateTime = myCal.MinSupportedDateTime
      Console.WriteLine("MinSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal.GetMonth(myMin), myCal.GetDayOfMonth(myMin), myCal.GetYear(myMin))

      ' Display the MaxSupportedDateTime.
      Dim myMax As DateTime = myCal.MaxSupportedDateTime
      Console.WriteLine("MaxSupportedDateTime: {0:D2}/{1:D2}/{2:D4}", myCal.GetMonth(myMax), myCal.GetDayOfMonth(myMax), myCal.GetYear(myMax))

   End Sub 'Main 

End Class 'SamplesCalendar


'This code produces the following output.
'
'System.Globalization.GregorianCalendar
'MinSupportedDateTime: 01/01/0001
'MaxSupportedDateTime: 12/31/9999

' </snippet1>
