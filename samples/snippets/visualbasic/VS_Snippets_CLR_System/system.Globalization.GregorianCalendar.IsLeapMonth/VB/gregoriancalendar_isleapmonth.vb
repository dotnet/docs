' The following code example calls IsLeapMonth for all the months in five years in the current era.

' <snippet1>
Imports System.Globalization

Public Class SamplesGregorianCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a GregorianCalendar.
      Dim myCal As New GregorianCalendar()

      ' Checks all the months in five years in the current era.
      Dim iMonthsInYear As Integer
      Dim y As Integer
      For y = 2001 To 2005
         Console.Write("{0}:" + ControlChars.Tab, y)
         iMonthsInYear = myCal.GetMonthsInYear(y, GregorianCalendar.CurrentEra)
         Dim m As Integer
         For m = 1 To iMonthsInYear
            Console.Write(ControlChars.Tab + "{0}", myCal.IsLeapMonth(y, m, GregorianCalendar.CurrentEra))
         Next m
         Console.WriteLine()
      Next y

   End Sub

End Class


'This code produces the following output.
'
'2001:           False   False   False   False   False   False   False   False   False   False   False   False
'2002:           False   False   False   False   False   False   False   False   False   False   False   False
'2003:           False   False   False   False   False   False   False   False   False   False   False   False
'2004:           False   False   False   False   False   False   False   False   False   False   False   False
'2005:           False   False   False   False   False   False   False   False   False   False   False   False

' </snippet1>
