' System.Diagnostics.EventLogInstaller


' The following example demonstrates the EventLogInstaller class.
' It defines the instance MyEventLogInstaller with the
' attribute RunInstallerAttribute.
' 
' The Log and Source properties of the new instance are set,
' and the instance is added to the collection of installers
' to be run during an installation.
' 
' Note:
'     1) Run this program using the following command: 
'           InstallUtil.exe  <filename.exe>
'     2) Uninstall the event log created in step 1 using the
'        following command:
'           InstallUtil.exe /u <filename.exe>

'<Snippet1>
   Imports System
   Imports System.Configuration.Install
   Imports System.Diagnostics
   Imports System.ComponentModel

   <RunInstaller(True)>  _
   Public Class SampleEventLogInstaller
      Inherits Installer

      Private myEventLogInstaller As EventLogInstaller

      Public Sub New()

         ' Create an instance of an EventLogInstaller.
         myEventLogInstaller = New EventLogInstaller()

         ' Set the source name of the event log.
         myEventLogInstaller.Source = "ApplicationEventSource"

         ' Set the event log into which the source writes entries.
         myEventLogInstaller.Log = "MyCustomLog"

         ' Set the resource file for the event log.
         ' The message strings are defined in EventLogMsgs.mc; the message
         ' identifiers used in the application must match those defined in the
         ' corresponding message resource file. The messages must be built
         ' into a Win32 resource library and copied to the target path on the
         ' system.

         myEventLogInstaller.CategoryResourceFile = _
             Environment.SystemDirectory + "\eventlogmsgs.dll"
         myEventLogInstaller.CategoryCount = 3
         myEventLogInstaller.MessageResourceFile = _
             Environment.SystemDirectory + "\eventlogmsgs.dll"
         myEventLogInstaller.ParameterResourceFile = _
             Environment.SystemDirectory + "\eventlogmsgs.dll"

         ' Add myEventLogInstaller to the installer collection.
         Installers.Add(myEventLogInstaller)

      End Sub 'New

      Public Shared Sub Main()
        Console.WriteLine("Usage: InstallUtil.exe [<install>.exe | <install>.dll]")
      End Sub 'Main
   End Class 'MyEventLogInstaller
'</Snippet1>