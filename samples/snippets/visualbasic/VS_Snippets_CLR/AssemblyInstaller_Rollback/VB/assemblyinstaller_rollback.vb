' System.Configuration.Install.AssemblyInstaller.Rollback
' System.Configuration.Install.AssemblyInstaller.Path
' System.Configuration.Install.AssemblyInstaller.CommandLine

'  The following example demonstrates the 'Rollback' method and the
'  'Path' and 'CommandLine' properties of the 'AssemblyInstaller' class.
'  An object of the AssemblyInstaller class is created by invoking the constructor.
'  The properties of this object are set and the install method is invoked on the
'  'MyAssembly.exe' assembly. The 'Rollback' method is called to undo the
'  install process on the specified assembly.

Imports System
Imports System.Configuration.Install
Imports System.Collections
Imports System.Collections.Specialized

Class AssemblyInstaller_Example

   Shared Sub Main()
      Dim mySavedState = New Hashtable()

      Console.WriteLine("")

      Try
' <Snippet2>
         ' Create an object of the 'AssemblyInstaller' class.
         Dim myAssemblyInstaller As New AssemblyInstaller()

         ' Set the path property of the AssemblyInstaller object.
         myAssemblyInstaller.Path = "MyAssembly_Rollback.exe"
' </Snippet2>

' <Snippet3>
         ' Set the logfile name in the commandline argument array.
         Dim commandLineOptions(0) As String
         commandLineOptions(0) = "/LogFile=example.log"
         myAssemblyInstaller.CommandLine = commandLineOptions
' </Snippet3>

         ' Set the 'UseNewContext' property to true.
         myAssemblyInstaller.UseNewContext = True

         ' Install the 'MyAssembly_Rollback' assembly.
         myAssemblyInstaller.Install(mySavedState)

' <Snippet1>
         ' 'Rollback' the installation process.
         myAssemblyInstaller.Rollback(mySavedState)
' </Snippet1>
      Catch e As ArgumentException
      Catch myException As Exception
         Console.WriteLine(myException.Message)
      End Try
   End Sub 'Main 
End Class 'AssemblyInstaller_Example