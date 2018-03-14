' System.Diagnostics.PerformanceCounterInstaller

' The following example demonstrates 'PerformanceCounterInstaller' class.
' A class is inherited from 'Installer' having 'RunInstallerAttribute' to true.
' A new instance of 'PerformanceCounterInstaller' is created and its 
' 'CategoryName' is set. Then this instance is added to 'InstallerCollection'.
' Note: 
' 1)To run this example use the following command:
'    InstallUtil.exe PerformanceCounterInstaller.exe
' 2)To uninstall the perfomance counter use the following command:
'    InstallUtil.exe /u PerformanceCounterInstaller.exe

' <Snippet1>
Imports System
Imports System.Configuration.Install
Imports System.Diagnostics
Imports System.ComponentModel

<RunInstaller(True)> _
Public Class MyPerformanceCounterInstaller
    Inherits Installer
    Public Sub New()
        Try
            ' Create an instance of 'PerformanceCounterInstaller'.
            Dim myPerformanceCounterInstaller As New PerformanceCounterInstaller()
            ' Set the 'CategoryName' for performance counter.
            myPerformanceCounterInstaller.CategoryName = "MyPerformanceCounter"
            Dim myCounterCreation As New CounterCreationData()
            myCounterCreation.CounterName = "MyCounter"
            myCounterCreation.CounterHelp = "Counter Help"
            ' Add a counter to collection of  myPerformanceCounterInstaller.
            myPerformanceCounterInstaller.Counters.Add(myCounterCreation)
            Installers.Add(myPerformanceCounterInstaller)
        Catch e As Exception
            Me.Context.LogMessage("Error occured :" + e.Message)
        End Try
    End Sub 'New
    Public Shared Sub Main()
    End Sub 'Main
End Class 'MyPerformanceCounterInstaller
' </Snippet1>
