' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim dto As DateTimeOffset = New DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)
      Console.WriteLine("{0} --> Unix Seconds: {1}", dto, dto.ToUnixTimeSeconds())

      dto = New DateTimeOffset(1969, 12, 31, 23, 59, 0, TimeSpan.Zero)
      Console.WriteLine("{0} --> Unix Seconds: {1}", dto, dto.ToUnixTimeSeconds())

      dto = New DateTimeOffset(1970, 1, 1, 0, 1, 0, TimeSpan.Zero)
      Console.WriteLine("{0} --> Unix Seconds: {1}", dto, dto.ToUnixTimeSeconds())
   End Sub
End Module
' The example displays the following output:
'       1/1/1970 12:00:00 AM +00:00 --> Unix Seconds: 0
'       12/31/1969 11:59:00 PM +00:00 --> Unix Seconds: -60
'       1/1/1970 12:01:00 AM +00:00 --> Unix Seconds: 60
' </Snippet1>
