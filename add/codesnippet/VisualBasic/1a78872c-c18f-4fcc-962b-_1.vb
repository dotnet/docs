Imports System
Imports System.Configuration.Install
Imports System.Collections
Imports System.Collections.Specialized

Class MyInstallClass
   
   Shared Sub Main()
      Dim mySavedState = New Hashtable()
      
      Console.WriteLine("")
      

      Try
         ' Set the commandline argument array for 'logfile'.
         Dim myString(0) As String
         myString(0) = "/logFile=example.log"
         ' Create an object of the 'AssemblyInstaller' class.
         Dim myAssemblyInstaller As New AssemblyInstaller()
         ' Set the properties to install the required assembly.
         myAssemblyInstaller.Path = "MyAssembly_Install.exe"
         myAssemblyInstaller.CommandLine = myString
         myAssemblyInstaller.UseNewContext = True
         
         ' Clear the 'IDictionary' object.
         mySavedState.Clear()
         
         ' Install the 'MyAssembly_Install' assembly.
         myAssemblyInstaller.Install(mySavedState)
         
         ' Commit the 'MyAssembly_Install' assembly.
         myAssemblyInstaller.Commit(mySavedState)
      Catch
      End Try

   End Sub 'Main
End Class 'MyInstallClass 