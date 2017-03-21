Module Test

   Sub Main()
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      Dim otherDomain As AppDomain = AppDomain.CreateDomain("otherDomain")
      
      currentDomain.ExecuteAssembly("MyExecutable.exe")
      ' Prints "MyExecutable running on [default]"

      otherDomain.ExecuteAssembly("MyExecutable.exe")
      ' Prints "MyExecutable running on otherDomain"
   End Sub 'Main

End Module 'Test