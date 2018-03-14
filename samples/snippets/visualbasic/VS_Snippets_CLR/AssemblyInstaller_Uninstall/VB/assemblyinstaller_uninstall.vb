' System.Configuration.Install.AssemblyInstaller.AssemblyInstaller( string, string[] )
' System.Configuration.Install.AssemblyInstaller.Uninstall

Imports System
Imports System.Configuration.Install
Imports System.Collections
Imports System.Collections.Specialized

Class MyInstallClass
   
   Shared Sub Main()
      Dim mySavedState = New Hashtable()
      
      Console.WriteLine("")
      
      Try
' <Snippet1>
         Dim myStringArray(0) As String
         Dim myString As String
         

         ' Set the commandline argument array for 'logfile'.
         myStringArray(0) = "/logFile=example.log"
         
         ' Set the name of the assembly to install.
         myString = "MyAssembly_Uninstall.exe"
         
         ' Create an object of the 'AssemblyInstaller' class.
         Dim myAssemblyInstaller As New AssemblyInstaller(myString, myStringArray)
' </Snippet1>
         ' Install and commit the 'MyAssembly_Uninstall' assembly.
         mySavedState.Clear()
         myAssemblyInstaller.Install(mySavedState)
         myAssemblyInstaller.Commit(mySavedState)
         
' <Snippet2>
         ' Uninstall the 'MyAssembly_Uninstall' assembly.
         myAssemblyInstaller.Uninstall(mySavedState)
' </Snippet2>

      Catch
      Catch myException As Exception
         Console.WriteLine(myException.Message)
      End Try
   End Sub 'Main
End Class 'MyInstallClass