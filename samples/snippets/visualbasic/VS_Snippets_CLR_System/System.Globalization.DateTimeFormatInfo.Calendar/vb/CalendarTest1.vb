' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture("ar-EG")
      Console.WriteLine("The current calendar for the {0} culture is {1}",
                        ci.Name, 
                        CalendarUtilities.ShowCalendarName(ci.DateTimeFormat.Calendar))

      CalendarUtilities.ChangeCalendar(ci, New JapaneseCalendar())
      Console.WriteLine("The current calendar for the {0} culture is {1}",
                        ci.Name, 
                        CalendarUtilities.ShowCalendarName(ci.DateTimeFormat.Calendar))
      
      CalendarUtilities.ChangeCalendar(ci, New UmAlQuraCalendar())
      Console.WriteLine("The current calendar for the {0} culture is {1}",
                        ci.Name, 
                        CalendarUtilities.ShowCalendarName(ci.DateTimeFormat.Calendar))
   End Sub
End Module

Public Class CalendarUtilities
   Private newCal As Calendar
   Private isGregorian As Boolean
   
   Public Shared Sub ChangeCalendar(ci As CultureInfo, cal As Calendar)
      Dim util As New CalendarUtilities(cal)
      
      ' Is the new calendar already the current calendar?
      If util.CalendarExists(ci.DateTimeFormat.Calendar) Then
         Exit Sub
      End If

      ' Is the new calendar supported?
      If Array.Exists(ci.OptionalCalendars, AddressOf util.CalendarExists) Then
         ci.DateTimeFormat.Calendar = cal
      End If
   End Sub
   
   Private Sub New(cal As Calendar)
      newCal = cal
      
      ' Is the new calendar a Gregorian calendar?
      isGregorian = cal.GetType().Name.Contains("Gregorian")
   End Sub
   
   Private Function CalendarExists(cal As Calendar) As Boolean
      If cal.ToString() = newCal.ToString Then
         If isGregorian Then
            If CType(cal, GregorianCalendar).CalendarType = 
               CType(newCal, GregorianCalendar).CalendarType Then
               Return True
            End If
         Else
            Return True
         End If
      End If
      Return False
   End Function

   Public Shared Function ShowCalendarName(cal As Calendar) As String
      Dim calName As String = cal.ToString().Replace("System.Globalization.", "")
      If TypeOf cal Is GregorianCalendar Then
         calName += ", Type " + CType(cal, GregorianCalendar).CalendarType.ToString()
      End If
      Return calName 
   End Function
End Class
' The example displays the following output:
'    The current calendar for the ar-EG culture is GregorianCalendar, Type Localized
'    The current calendar for the ar-EG culture is GregorianCalendar, Type Localized
'    The current calendar for the ar-EG culture is UmAlQuraCalendar
' </Snippet1>