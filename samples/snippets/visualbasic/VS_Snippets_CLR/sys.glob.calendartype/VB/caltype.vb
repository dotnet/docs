'<snippet1>
' This example demonstrates the Calendar.AlgorithmType property and
' CalendarAlgorithmType enumeration.
Imports System
Imports System.Globalization

Class Sample
   Public Shared Sub Main()
      Dim grCal As New GregorianCalendar()
      Dim hiCal As New HijriCalendar()
      Dim jaCal As New JapaneseLunisolarCalendar()
      Display(grCal)
      Display(hiCal)
      Display(jaCal)
   End Sub 'Main
   
   Shared Sub Display(c As Calendar)
      Dim name As String = c.ToString().PadRight(50, "."c)
      Console.WriteLine("{0} {1}", name, c.AlgorithmType)
   End Sub 'Display
End Class 'Sample
'
'This code example produces the following results:
'
'System.Globalization.GregorianCalendar............ SolarCalendar
'System.Globalization.HijriCalendar................ LunarCalendar
'System.Globalization.JapaneseLunisolarCalendar.... LunisolarCalendar
'
'</snippet1>