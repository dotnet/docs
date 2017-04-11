' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      NoCachedReferences()
   End Sub

   Private Sub NoCachedReferences
      ' <Snippet1>
      Dim cst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
      Dim local As TimeZoneInfo = TimeZoneInfo.Local
      Console.WriteLine(TimeZoneInfo.ConvertTime(Date.Now, local, cst))
      
      TimeZoneInfo.ClearCachedData()
      Try
         Console.WriteLine(TimeZoneInfo.ConvertTime(Date.Now, local, cst))
      Catch e As ArgumentException
         Console.WriteLine(e.GetType().Name & vbCrLf & "   " & e.Message)
      End Try
      ' </Snippet1>
   End Sub
End Module

