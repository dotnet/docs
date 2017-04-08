' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim date1 As New DateTime(2010, 3, 14, 2, 30, 00)
      Console.WriteLine("Invalid Time: {0}", TimeZoneInfo.Local.IsInvalidTime(date1))
      Dim ft As Long = date1.ToFileTime()
      Dim date2 As DateTime = DateTime.FromFileTime(ft)
      Console.WriteLine("{0} -> {1}", date1, date2) 
   End Sub
End Module
' The example displays the following output:
'       Invalid Time: True
'       3/14/2010 2:30:00 AM -> 3/14/2010 3:30:00 AM
' </Snippet1>
      
