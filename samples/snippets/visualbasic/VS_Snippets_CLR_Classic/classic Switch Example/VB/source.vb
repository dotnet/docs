Imports System
Imports System.Diagnostics

' <Snippet1>
' The following are possible values for the new switch.
Public Enum MethodTracingSwitchLevel
    Off = 0
    EnteringMethod = 1
    ExitingMethod = 2
    Both = 3
End Enum 'MethodTracingSwitchLevel
' </Snippet1>

' <Snippet2>
Public Class MyMethodTracingSwitch
    Inherits Switch
    Protected outExit As Boolean
    Protected outEnter As Boolean
    Protected myLevel As MethodTracingSwitchLevel
    
    Public Sub New(displayName As String, description As String)
        MyBase.New(displayName, description)
    End Sub 'New


    Public Property Level() As MethodTracingSwitchLevel
        Get
            Return myLevel
        End Get
        Set
            SetSwitchSetting(CInt(value))
        End Set
    End Property


    Protected Sub SetSwitchSetting(value As Integer)
        If value < 0 Then
            value = 0
        End If
        If value > 3 Then
            value = 3
        End If

        myLevel = CType(value, MethodTracingSwitchLevel)

        outEnter = False
        If value = CInt(MethodTracingSwitchLevel.EnteringMethod) Or _
            value = CInt(MethodTracingSwitchLevel.Both) Then

            outEnter = True
        End If

        outExit = False
        If value = CInt(MethodTracingSwitchLevel.ExitingMethod) Or _
            value = CInt(MethodTracingSwitchLevel.Both) Then

            outExit = True
        End If
    End Sub 'SetSwitchSetting


    Public ReadOnly Property OutputExit() As Boolean
        Get
            Return outExit
        End Get
    End Property


    Public ReadOnly Property OutputEnter() As Boolean
        Get
            Return outEnter
        End Get
    End Property
End Class 'MyMethodTracingSwitch

' </Snippet2>
' <Snippet3>
Public Class Class1
    ' Create an instance of MyMethodTracingSwitch.
    Private Shared mySwitch As New _
        MyMethodTracingSwitch("Methods", "Trace entering and exiting method")

    Public Shared Sub Main()
        ' Add the console listener to see trace messages as console output
        Trace.Listeners.Add(New ConsoleTraceListener(True))
        Debug.AutoFlush = True

        ' Set the switch level to both enter and exit
        mySwitch.Level = MethodTracingSwitchLevel.Both

        ' Write a diagnostic message if the switch is set to entering.
        Debug.WriteLineIf(mySwitch.OutputEnter, "Entering Main")

        ' Insert code to handle processing here...

        ' Write another diagnostic message if the switch is set to exiting.
        Debug.WriteLineIf(mySwitch.OutputExit, "Exiting Main")
    End Sub
End Class 'MyClass
' </Snippet3>
