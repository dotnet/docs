' System.Configuration.Install.AssemblyInstaller.AssemblyInstaller()
' System.Configuration.Install.AssemblyInstaller.Install
' System.Configuration.Install.AssemblyInstaller.Commit

' The following example demonstrates the 'AssemblyInstaller()' constructor and
' the 'Install' and 'Commit' methods of the 'AssemblyInstaller' class.
' An object of the AssemblyInstaller class is created by invoking the constructor.
' The properties of this object are set and the install and commit methods are
' called to install the 'MyAssembly_Install.exe' assembly.

' <Snippet2>
' <Snippet3>
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
' <Snippet1>
         ' Create an object of the 'AssemblyInstaller' class.
         Dim myAssemblyInstaller As New AssemblyInstaller()
' </Snippet1>
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
' </Snippet2>
' </Snippet3>