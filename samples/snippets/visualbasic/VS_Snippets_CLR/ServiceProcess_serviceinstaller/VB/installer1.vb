
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.ServiceProcess


<RunInstaller(True)> _
Class Installer1
    Inherits Installer
    Private serviceInstaller As ServiceInstaller
    Private processInstaller As ServiceProcessInstaller


    Public Sub ProjectInstaller()

        processInstaller = New ServiceProcessInstaller()
        serviceInstaller = New ServiceInstaller()

        ' Service will run under system account
        processInstaller.Account = ServiceAccount.User

        ' Service will have Start Type of Manual
        serviceInstaller.StartType = ServiceStartMode.Automatic

        serviceInstaller.ServiceName = "SimpleService"

        Installers.Add(serviceInstaller)
        Installers.Add(processInstaller)

    End Sub 'ProjectInstaller

End Class 'Installer1
