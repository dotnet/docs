' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example
   Dim rnd As New Random()
   
   Public Sub Main()
      Dim timeSpent As TimeSpan = TimeSpan.Zero

      timeSpent += GetTimeBeforeLunch()
      timeSpent += GetTimeAfterLunch()

      Console.WriteLine("Total time: {0}", timeSpent)
   End Sub
   
   Private Function GetTimeBeforeLunch() As TimeSpan
      Return New TimeSpan(rnd.Next(3, 6), 0, 0)
   End Function
   
   Private Function GetTimeAfterLunch() As TimeSpan
      Return New TimeSpan(rnd.Next(3, 6), 0, 0)
   End Function
End Module
' The example displays output like the following:
'       Total time: 08:00:00
' </Snippet6>