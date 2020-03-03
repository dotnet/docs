Option Strict On
Option Explicit On

' <Snippet1>   
Module Test

   Sub Main()
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      Dim otherDomain As AppDomain = AppDomain.CreateDomain("otherDomain")
      
      currentDomain.ExecuteAssembly("MyExecutable.exe")
      ' Prints "MyExecutable running on [default]"

      otherDomain.ExecuteAssembly("MyExecutable.exe")
      ' Prints "MyExecutable running on otherDomain"
   End Sub

End Module 'Test
' </Snippet1>