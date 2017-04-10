' System.Configuration.Install.ComponentInstaller.CopyFromComponent
' System.Configuration.Install.ComponentInstaller.IsEquivalentInstaller

'   The following example demonstrates the 'CopyFromComponent' and
'   the 'IsEquivalentInstaller' methods of the 'ComponentInstaller' class.
'   It defines a class MyInstallClass, which creates the event log and copies
'   the properties of the event log component to the 'EventLogInstaller' object.
'   It also checks whether 'ServiceInstaller' object can handle the same kind of 
'   installation as 'EventLogInstaller' object. 

Imports System
Imports System.Diagnostics
Imports System.ServiceProcess

Public Class ComponentInstaller_Example

   Shared Sub Main()
' <Snippet1>
      Dim myEventLogInstaller As New EventLogInstaller()
      ' Create a source for the specified event log, on local computer.
      EventLog.CreateEventSource("MyEventSource", "MyEventLog", ".")
      ' Create an event log instance and associate it with the log .
      Dim myEventLog As New EventLog("MyEventLog", ".", "MyEventSource")
      ' Copy the properties that are required at install time from
      ' the event log component to the installer.
      myEventLogInstaller.CopyFromComponent(myEventLog)
' </Snippet1>
      Console.WriteLine("The properties of the event log component : ")
      Console.WriteLine(myEventLogInstaller.Log)
      Console.WriteLine(myEventLogInstaller.Source)
' <Snippet2>
      Dim myServiceInstaller As New ServiceInstaller()
      ' Check whether 'ServiceInstaller' object can handle the same 
      ' kind of installation as 'EventLogInstaller' object.
      If myEventLogInstaller.IsEquivalentInstaller(myServiceInstaller) Then
         Console.WriteLine("'ServiceInstaller' can handle the same kind" + _
                                    " of installation as EventLogInstaller")
      Else
         Console.WriteLine("'ServiceInstaller' can't handle the same" + _
                              " kind of installation as 'EventLogInstaller'")
      End If
' </Snippet2>
      EventLog.Delete("MyEventLog", ".")
   End Sub 'Main
End Class 'ComponentInstaller_Example