' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      InstantiateMinutes()
      InstantiateDays()
      InstantiateHours()
      InstantiateMilliseconds()
      InstantiateSeconds()
   End Sub
   
   Private Sub InstantiateMinutes()
      ' <Snippet1>
      ' The following throws an OverflowException at runtime
      Dim maxSpan As TimeSpan = TimeSpan.FromMinutes(TimeSpan.MaxValue.TotalMinutes)
      ' </Snippet1>
   End Sub   

   Private Sub InstantiateDays()
      ' <Snippet2>
      ' The following throws an OverflowException at runtime
      Dim maxSpan As TimeSpan = TimeSpan.FromDays(TimeSpan.MaxValue.TotalDays)
      ' </Snippet2>
   End Sub

   Private Sub InstantiateHours()
      ' <Snippet3>
      ' The following throws an OverflowException at runtime
      Dim maxSpan As TimeSpan = TimeSpan.FromHours(TimeSpan.MaxValue.TotalHours)
      ' </Snippet3>
   End Sub
   
   Private Sub InstantiateMilliseconds()
      ' <Snippet4>
      ' The following throws an OverflowException at runtime
      Dim maxSpan As TimeSpan = TimeSpan.FromMilliseconds(TimeSpan.MaxValue.TotalMilliseconds)
      ' </Snippet4>
   End Sub
   
   Private Sub InstantiateSeconds()
      ' <Snippet5>
      ' The following throws an OverflowException at runtime
      Dim maxSpan As TimeSpan = TimeSpan.FromSeconds(TimeSpan.MaxValue.TotalSeconds)
      ' </Snippet5>
   End Sub
End Module

