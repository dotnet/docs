Imports Microsoft.Win32

Public Module VersionTest
   Public Sub Main()
      GetVersionFromEnvironment()
   End Sub
   
    Private Sub GetVersionFromEnvironment()
        Console.WriteLine($"Version: {Environment.Version}")
    End Sub
End Module

