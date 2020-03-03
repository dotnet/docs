Option Strict On
Option Explicit On

' <Snippet2>
Module MyExecutable
   
   Sub Main()
      Dim name As String = AppDomain.CurrentDomain.FriendlyName
      Console.WriteLine("MyExecutable running on " + name)
   End Sub

End Module 'MyExecutable
' </Snippet2>