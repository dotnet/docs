' System.Configuration.Install.AssemblyInstaller.UseNewContext
' System.Configuration.Install.AssemblyInstaller.HelpText

'   The following example demonstrates the 'UseNewContext' and the
'   'HelpText' properties of the 'AssemblyInstaller' class.
'   An object of the AssemblyInstaller class is created by invoking the constructor.
'   The 'UseNewContext' property of this object is set to true and the install
'   method is invoked on the 'MyAssembly_HelpText.exe' assembly. Due
'   to this the log messages are displayed on the console. The 'HelpText'
'   property for the object is displayed on the console.

Imports System
Imports System.Configuration.Install
Imports System.Collections
Imports System.Collections.Specialized

Class AssemblyInstaller_Example

   Shared Sub Main()
      Dim mySavedState = New Hashtable()

      Console.WriteLine("")

      Try
         Dim commandLineOptions(0) As String
         commandLineOptions(0) = "/LogFile=example.log"

' <Snippet1>
         ' Create an object of the 'AssemblyInstaller' class.
         Dim myAssemblyInstaller As _
            New AssemblyInstaller("MyAssembly_HelpText.exe", commandLineOptions)

         ' Set the 'UseNewContext' property to true.
         myAssemblyInstaller.UseNewContext = True
' </Snippet1>

         ' Install the 'MyAssembly_HelpText' assembly.
         myAssemblyInstaller.Install(mySavedState)

' <Snippet2>
         Console.WriteLine("The 'HelpText' is-")
         ' Display the 'HelpText' of this AssemblyInstaller object.
         Console.WriteLine(myAssemblyInstaller.HelpText)
' </Snippet2>
      Catch e As ArgumentException
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'Main 
End Class 'AssemblyInstaller_Example