' The following code example displays the values of several components of a DateTime in terms of the Hijri calendar.

' <snippet1>
Imports System
Imports System.Globalization


Public Class SamplesHijriCalendar   

   Public Shared Sub Main()

      ' Sets a DateTime to April 3, 2002 of the Gregorian calendar.
      Dim myDT As New DateTime(2002, 4, 3, New GregorianCalendar())

      ' Creates an instance of the HijriCalendar.
      Dim myCal As New HijriCalendar()

      ' Displays the values of the DateTime.
      Console.WriteLine("April 3, 2002 of the Gregorian calendar equals the following in the Hijri calendar:")
      DisplayValues(myCal, myDT)

      ' Adds two years and ten months.
      myDT = myCal.AddYears(myDT, 2)
      myDT = myCal.AddMonths(myDT, 10)

      ' Displays the values of the DateTime.
      Console.WriteLine("After adding two years and ten months:")
      DisplayValues(myCal, myDT)

   End Sub 'Main

   Public Shared Sub DisplayValues(myCal As Calendar, myDT As DateTime)
      Console.WriteLine("   Era:        {0}", myCal.GetEra(myDT))
      Console.WriteLine("   Year:       {0}", myCal.GetYear(myDT))
      Console.WriteLine("   Month:      {0}", myCal.GetMonth(myDT))
      Console.WriteLine("   DayOfYear:  {0}", myCal.GetDayOfYear(myDT))
      Console.WriteLine("   DayOfMonth: {0}", myCal.GetDayOfMonth(myDT))
      Console.WriteLine("   DayOfWeek:  {0}", myCal.GetDayOfWeek(myDT))
      Console.WriteLine()
   End Sub 'DisplayValues

End Class 'SamplesHijriCalendar 


'This code produces the following output.
'
'April 3, 2002 of the Gregorian calendar equals the following in the Hijri calendar:
'   Era:        1
'   Year:       1423
'   Month:      1
'   DayOfYear:  21
'   DayOfMonth: 21
'   DayOfWeek:  Wednesday
'
'After adding two years and ten months:
'   Era:        1
'   Year:       1425
'   Month:      11
'   DayOfYear:  316
'   DayOfMonth: 21
'   DayOfWeek:  Saturday

' </snippet1>
