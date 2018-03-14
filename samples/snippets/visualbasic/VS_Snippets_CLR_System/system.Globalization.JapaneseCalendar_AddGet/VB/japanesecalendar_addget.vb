' The following code example displays the values of several components of a DateTime in terms of the Japanese calendar.

' <snippet1>
Imports System
Imports System.Globalization


Public Class SamplesJapaneseCalendar   

   Public Shared Sub Main()

      ' Sets a DateTime to April 3, 2002 of the Gregorian calendar.
      Dim myDT As New DateTime(2002, 4, 3, New GregorianCalendar())

      ' Creates an instance of the JapaneseCalendar.
      Dim myCal As New JapaneseCalendar()

      ' Displays the values of the DateTime.
      Console.WriteLine("April 3, 2002 of the Gregorian calendar equals the following in the Japanese calendar:")
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

End Class 'SamplesJapaneseCalendar 


'This code produces the following output.
'
'April 3, 2002 of the Gregorian calendar equals the following in the Japanese calendar:
'   Era:        4
'   Year:       14
'   Month:      4
'   DayOfYear:  93
'   DayOfMonth: 3
'   DayOfWeek:  Wednesday
'
'After adding two years and ten months:
'   Era:        4
'   Year:       17
'   Month:      2
'   DayOfYear:  34
'   DayOfMonth: 3
'   DayOfWeek:  Thursday

' </snippet1>
