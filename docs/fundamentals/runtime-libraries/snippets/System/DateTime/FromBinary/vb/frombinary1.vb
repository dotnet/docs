' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim localDate As Date = DateTime.SpecifyKind(#03/14/2010 2:30AM#, DateTimeKind.Local)
      Dim binLocal As Long = localDate.ToBinary()
      If TimeZoneInfo.Local.IsInvalidTime(localDate) Then
         Console.WriteLine("{0} is an invalid time in the {1} zone.", _
                           localDate, _
                           TimeZoneInfo.Local.StandardName)
      End If
      Dim localDate2 As Date = DateTime.FromBinary(binLocal)
      Console.WriteLine("{0} = {1}: {2}", _
                        localDate, localDate2, localDate.Equals(localDate2))
   End Sub
End Module
' The example displays the following output:
'    3/14/2010 2:30:00 AM is an invalid time in the Pacific Standard Time zone.
'    3/14/2010 2:30:00 AM = 3/14/2010 3:30:00 AM: False
' </Snippet1>
