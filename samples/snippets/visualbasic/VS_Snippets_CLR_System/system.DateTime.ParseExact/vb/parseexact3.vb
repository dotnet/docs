' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim formats() As String = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", _
                                 "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", _
                                 "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", _
                                 "M/d/yyyy h:mm", "M/d/yyyy h:mm", _
                                 "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm",
                                 "MM/d/yyyy HH:mm:ss.ffffff" }
      Dim dateStrings() As String = {"5/1/2009 6:32 PM", "05/01/2009 6:32:05 PM", _
                                     "5/1/2009 6:32:00", "05/01/2009 06:32", _
                                     "05/01/2009 06:32:00 PM", "05/01/2009 06:32:00",
                                     "08/28/2015 16:17:39.125", "08/28/2015 16:17:39.125000" }

      Dim dateValue As DateTime
      
      For Each dateString As String In dateStrings
         Try
            dateValue = DateTime.ParseExact(dateString, formats, _
                                            New CultureInfo("en-US"), _
                                            DateTimeStyles.None)
            Console.WriteLine("Converted '{0}' to {1}.", dateString, dateValue)
         Catch e As FormatException
            Console.WriteLine("Unable to convert '{0}' to a date.", dateString)
         End Try                                               
      Next
   End Sub
End Module
' The example displays the following output:
'       Converted '5/1/2009 6:32 PM' to 5/1/2009 6:32:00 PM.
'       Converted '05/01/2009 6:32:05 PM' to 5/1/2009 6:32:05 PM.
'       Converted '5/1/2009 6:32:00' to 5/1/2009 6:32:00 AM.
'       Converted '05/01/2009 06:32' to 5/1/2009 6:32:00 AM.
'       Converted '05/01/2009 06:32:00 PM' to 5/1/2009 6:32:00 PM.
'       Converted '05/01/2009 06:32:00' to 5/1/2009 6:32:00 AM.
'       Unable to convert '08/28/2015 16:17:39.125' to a date.
'       Converted '08/28/2015 16:17:39.125000' to 8/28/2015 4:17:39 PM.
' </Snippet3>

