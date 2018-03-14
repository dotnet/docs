' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim thisTimeZone As TimeZoneInfo
      Dim obj1, obj2 As Object
      
      thisTimeZone = TimeZoneInfo.Local
      obj1 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
      obj2 = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
      Console.WriteLine(thisTimeZone.Equals(obj1))
      Console.WriteLine(thisTimeZone.Equals(obj2))
   End Sub
End Module
' The example displays the following output:
'      True
'      False
' </Snippet1>

