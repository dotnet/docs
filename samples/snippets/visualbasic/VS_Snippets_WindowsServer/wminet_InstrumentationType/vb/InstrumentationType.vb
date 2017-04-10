'<Snippet1>
Imports System
Imports System.Management
Imports System.Configuration.Install
Imports System.Management.Instrumentation

' This sample demonstrates how to create
' a management event class by using
' the InstrumentationType enumeration

' Specify which namespace the management event
' class is created in
<Assembly: Instrumented("Root/Default")> 

' Let the system know InstallUtil.exe tool will
' be run against this assembly
<System.ComponentModel.RunInstaller(True)> _
Public Class MyInstaller
    Inherits DefaultManagementProjectInstaller
End Class 'MyInstaller

Namespace WMISample
    ' Create a management instrumentation event class
    <InstrumentationClass(InstrumentationType.Event)> _
    Public Class MyEvent
        Private EventName As String
        Function setEventName(ByVal name As String)
            EventName = name
        End Function
    End Class

    Public Class SampleEventProvider
        Public Shared Function Main(ByVal args() _
            As String) As Integer

            Dim e As New MyEvent
            e.setEventName("Hello")

            ' Fire a management event
            System.Management.Instrumentation. _
                Instrumentation.Fire(e)

            Return 0
        End Function
    End Class
End Namespace
'</Snippet1>