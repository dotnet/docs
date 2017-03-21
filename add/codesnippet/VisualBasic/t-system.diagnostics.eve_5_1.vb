   Imports System
   Imports System.Configuration.Install
   Imports System.Diagnostics
   Imports System.ComponentModel

   <RunInstaller(True)>  _
   Public Class MyEventLogInstaller
      Inherits Installer
      Private myEventLogInstaller As EventLogInstaller
      
      Public Sub New()

         ' Create an instance of an EventLogInstaller.
         myEventLogInstaller = New EventLogInstaller()

         ' Set the source name of the event log.
         myEventLogInstaller.Source = "NewLogSource"

         ' Set the event log that the source writes entries to.
         myEventLogInstaller.Log = "MyNewLog"

         ' Add myEventLogInstaller to the Installer collection.
         Installers.Add(myEventLogInstaller)
      End Sub 'New

    Public Shared Sub Main()
    End Sub 'Main
    Dim myInstaller As New EventLogInstaller()
   End Class 'MyEventLogInstaller