' Visual Basic .NET Document
Option Strict On

' Relationships between calendar and long date pattern in Arabic (Syria) culture.
' <Snippet3>
Imports System.Globalization
Imports System.IO

Module Example
   Public Sub Main()
      Dim date1 As Date = #8/7/2011#
      Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture("ar-SY")
      Dim sw As New StreamWriter(".\arSYCalendars.txt") 

      sw.WriteLine("{0,-32} {1,-21} {2}", 
                   "Calendar", "Long Date Pattern", "Example Date")
      sw.WriteLine()
      For Each cal As Calendar In ci.OptionalCalendars
         ci.DateTimeFormat.Calendar = cal
         sw.WriteLine("{0,-32} {1,-21} {2}", GetCalendarName(cal), 
                                             ci.DateTimeFormat.LongDatePattern,
                                             date1.ToString("D", ci))
      Next     
      sw.Close()
   End Sub
   
   Private Function GetCalendarName(cal As Calendar) As String
      Dim calName As String
      calName = cal.GetType().Name.Substring(0, cal.GetType().Name.IndexOf("Cal"))
      If calName.Equals("Gregorian") Then
         Dim grCal As GregorianCalendar = DirectCast(cal, GregorianCalendar)
         calName += String.Format("-{0}", grCal.CalendarType)    
      End If
      Return calName
   End Function
End Module
' The example generates the following output:
'    Calendar                         Long Date Pattern     Example Date
'    
'    Gregorian-Localized              dd MMMM, yyyy         07 آب, 2011
'    UmAlQura                         dd/MMMM/yyyy          07/رمضان/1432
'    Hijri                            dd/MM/yyyy            08/09/1432
'    Gregorian-USEnglish              dddd, MMMM dd, yyyy   Sunday, August 07, 2011
'    Gregorian-MiddleEastFrench       dddd, MMMM dd, yyyy   dimanche, août 07, 2011
'    Gregorian-TransliteratedEnglish  dddd, MMMM dd, yyyy   الأحد, أغسطس 07, 2011
'    Gregorian-TransliteratedFrench   dddd, MMMM dd, yyyy   الأحد, أوت 07, 2011
' </Snippet3>
