' System.Configuration.Install.AssemblyInstaller

'   The following example demonstrates the 'AssemblyInstaller' class.
'   An object of the AssemblyInstaller class is created by invoking the constructor.
'   The properties of this object are set and the install and commit methods are
'   called to install the 'MyAssembly.exe' assembly.

' <Snippet1>
Imports System
Imports System.Configuration.Install
Imports System.Collections
Imports System.Collections.Specialized

Class AssemblyInstaller_Example

   Shared Sub Main()
      Dim mySavedState = New Hashtable()

      Console.WriteLine("")

      Try
         ' Set the commandline argument array for 'logfile'.
         Dim commandLineOptions(0) As String
         commandLineOptions(0) = "/LogFile=example.log"

         ' Create an object of the 'AssemblyInstaller' class.
         Dim myAssemblyInstaller As _
               New AssemblyInstaller("MyAssembly.exe", commandLineOptions)

         myAssemblyInstaller.UseNewContext = True

         ' Install the 'MyAssembly' assembly.
         myAssemblyInstaller.Install(mySavedState)

         ' Commit the 'MyAssembly' assembly.
         myAssemblyInstaller.Commit(mySavedState)
      Catch e As ArgumentException
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'Main
End Class 'AssemblyInstaller_Example
' </Snippet1>