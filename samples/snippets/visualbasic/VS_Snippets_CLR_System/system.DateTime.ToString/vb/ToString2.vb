' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module DateToStringExample
   Public Sub Main()
      Dim dateValue As Date = #6/15/2008 9:15:07PM#
      ' Create an array of standard format strings.
      Dim standardFmts() As String = {"d", "D", "f", "F", "g", "G", _
                                      "m", "o", "R", "s", "t", "T", _
                                      "u", "U", "y"}
      ' Output date and time using each standard format string.
      For Each standardFmt As String In standardFmts
         Console.WriteLine("{0}: {1}", standardFmt, _
                           dateValue.ToString(standardFmt))
      Next
      Console.WriteLine()
      
      ' Create an array of some custom format strings.
      Dim customFmts() As String = {"h:mm:ss.ff t", "d MMM yyyy", "HH:mm:ss.f", _
                                    "dd MMM HH:mm:ss", "\Mon\t\h\: M", "HH:mm:ss.ffffzzz" }
      ' Output date and time using each custom format string.
      For Each customFmt As String In customFmts
         Console.WriteLine("'{0}': {1}", customFmt, _
                           dateValue.ToString(customFmt))
      Next
   End Sub
End Module
' This example displays the following output to the console:
'       d: 6/15/2008
'       D: Sunday, June 15, 2008
'       f: Sunday, June 15, 2008 9:15 PM
'       F: Sunday, June 15, 2008 9:15:07 PM
'       g: 6/15/2008 9:15 PM
'       G: 6/15/2008 9:15:07 PM
'       m: June 15
'       o: 2008-06-15T21:15:07.0000000
'       R: Sun, 15 Jun 2008 21:15:07 GMT
'       s: 2008-06-15T21:15:07
'       t: 9:15 PM
'       T: 9:15:07 PM
'       u: 2008-06-15 21:15:07Z
'       U: Monday, June 16, 2008 4:15:07 AM
'       y: June, 2008
'       
'       'h:mm:ss.ff t': 9:15:07.00 P
'       'd MMM yyyy': 15 Jun 2008
'       'HH:mm:ss.f': 21:15:07.0
'       'dd MMM HH:mm:ss': 15 Jun 21:15:07
'       '\Mon\t\h\: M': Month: 6
'       'HH:mm:ss.ffffzzz': 21:15:07.0000-07:00
' </Snippet2>
