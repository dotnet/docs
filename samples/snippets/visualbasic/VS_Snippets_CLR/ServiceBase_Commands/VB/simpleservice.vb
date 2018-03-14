' The following example illustrates deriving a service implementation from
' the System.ServiceProcess.ServiceBase class.  This simple service starts
' a worker thread, and handles various service commands.
' The main service thread and the worker thread write their trace output
' to the eventlog.
' <Snippet1>
' Turn on logging to the event log.
#Const LOGEVENTS = True

Imports System
Imports System.IO
Imports System.Threading
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.ServiceProcess
Imports System.Text
Imports Microsoft.Win32
Imports System.Runtime.InteropServices


' Define custom commands for the SimpleService.

Public Enum SimpleServiceCustomCommands
    StopWorker = 128
    RestartWorker
    CheckWorker
End Enum 'SimpleServiceCustomCommands
<StructLayout(LayoutKind.Sequential)> _
Public Structure SERVICE_STATUS
    Public serviceType As Integer
    Public currentState As Integer
    Public controlsAccepted As Integer
    Public win32ExitCode As Integer
    Public serviceSpecificExitCode As Integer
    Public checkPoint As Integer
    Public waitHint As Integer
End Structure 'SERVICE_STATUS


Public Enum State
    SERVICE_STOPPED = &H1
    SERVICE_START_PENDING = &H2
    SERVICE_STOP_PENDING = &H3
    SERVICE_RUNNING = &H4
    SERVICE_CONTINUE_PENDING = &H5
    SERVICE_PAUSE_PENDING = &H6
    SERVICE_PAUSED = &H7
End Enum 'State

' Define a simple service implementation.

Public Class SimpleService
    Inherits System.ServiceProcess.ServiceBase
    Private Shared userCount As Integer = 0
    Private Shared pause As New ManualResetEvent(False)

    Public Declare Auto Function SetServiceStatus Lib "ADVAPI32.DLL" Alias "SetServiceStatus" (ByVal hServiceStatus As IntPtr, ByRef lpServiceStatus As SERVICE_STATUS) As Boolean
    Private myServiceStatus As SERVICE_STATUS

    Private workerThread As Thread = Nothing

    ' <Snippet2>
    Public Sub New()
        CanPauseAndContinue = True
        CanHandleSessionChangeEvent = True
        CanShutdown = True
        CanStop = True
        ServiceName = "Simple Service"
        System.Diagnostics.EventLog.WriteEntry("SimpleService", DateTime.Now.ToLongTimeString())

    End Sub 'New

    ' </Snippet2>
    Shared Sub Main()
#If LOGEVENTS Then
        System.Diagnostics.EventLog.WriteEntry("SimpleService.Main", DateTime.Now.ToLongTimeString() + " - Service main method starting...")
#End If

        ' Load the service into memory.
        System.ServiceProcess.ServiceBase.Run(New SimpleService())

#If LOGEVENTS Then
        System.Diagnostics.EventLog.WriteEntry("SimpleService.Main", DateTime.Now.ToLongTimeString() + " - Service main method exiting...")
#End If

    End Sub 'Main



    ' <Snippet3>
    ' Start the service.
    Protected Overrides Sub OnStart(ByVal args() As String)
        Dim handle As IntPtr = Me.ServiceHandle
        myServiceStatus.currentState = Fix(State.SERVICE_START_PENDING)
        SetServiceStatus(handle, myServiceStatus)

        ' Start a separate thread that does the actual work.
        If workerThread Is Nothing OrElse (workerThread.ThreadState And System.Threading.ThreadState.Unstarted Or System.Threading.ThreadState.Stopped) <> 0 Then
#If LOGEVENTS Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.OnStart", DateTime.Now.ToLongTimeString() + " - Starting the service worker thread.")
#End If

            workerThread = New Thread(New ThreadStart(AddressOf ServiceWorkerMethod))
            workerThread.Start()
        End If
#If LOGEVENTS Then
        If Not (workerThread Is Nothing) Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.OnStart", DateTime.Now.ToLongTimeString() + " - Worker thread state = " + workerThread.ThreadState.ToString())
        End If
#End If
        myServiceStatus.currentState = Fix(State.SERVICE_RUNNING)
        SetServiceStatus(handle, myServiceStatus)
        System.Diagnostics.EventLog.WriteEntry("SimpleService", "Starting SimpleService")

        ' Get arguments from the ImagePath string value for the service's registry 
        ' key (HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SimpleService).
        ' These arguments are not used by this sample, this code is only intended to
        ' demonstrate how to obtain the arguments.
        Dim imagePathArgs As String() = Environment.GetCommandLineArgs()
        If imagePathArgs.Length > 1 Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.ImagePath", "argument 1: " + imagePathArgs(1))
            If imagePathArgs.Length > 2 Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.ImagePath", "argument 2: " + imagePathArgs(2))
            End If
        End If ' Get values for arguments passed in from the Services control panel or
        ' by the ServiceController class Start(string[]) method.
        ' Note:  The arguments are not persisted by the control panel. You must
        ' open the properties for the service, set the arguments, then start the
        ' service. You may find this functionality useful when debugging a service.
        ' These arguments are not used by this sample, this code is only
        ' intended to demonstrate how to obtain the arguments.
        If args.Length > 1 Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.Arguments", args(0))
            If args.Length > 1 Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.Arguments", args(1))
            End If
        End If

    End Sub 'OnStart

    ' </Snippet3>
    ' <Snippet4>
    ' Stop this service.
    Protected Overrides Sub OnStop()
        ' New in .NET Framework version 2.0.
        Me.RequestAdditionalTime(4000)
        ' Signal the worker thread to exit.
        If Not (workerThread Is Nothing) AndAlso workerThread.IsAlive Then
#If LOGEVENTS Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.OnStop", DateTime.Now.ToLongTimeString() + " - Stopping the service worker thread.")
#End If
            pause.Reset()
            Thread.Sleep(5000)
            workerThread.Abort()
        End If
        If Not (workerThread Is Nothing) Then
#If LOGEVENTS Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.OnStop", DateTime.Now.ToLongTimeString() + " - OnStop Worker thread state = " + workerThread.ThreadState.ToString())
#End If
        End If
        ' Indicate a successful exit.
        Me.ExitCode = 0

    End Sub 'OnStop

    ' </Snippet4>
    ' <Snippet5>
    ' Pause the service.
    Protected Overrides Sub OnPause()
        ' Pause the worker thread.
        If Not (workerThread Is Nothing) AndAlso workerThread.IsAlive AndAlso (workerThread.ThreadState And System.Threading.ThreadState.Suspended Or System.Threading.ThreadState.SuspendRequested) = 0 Then
#If LOGEVENTS Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.OnPause", DateTime.Now.ToLongTimeString() + " - Pausing the service worker thread.")
#End If

            pause.Reset()
            Thread.Sleep(5000)
        End If

        If Not (workerThread Is Nothing) Then
#If LOGEVENTS Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.OnPause", DateTime.Now.ToLongTimeString() + " OnPause - Worker thread state = " + workerThread.ThreadState.ToString())
#End If
        End If

    End Sub 'OnPause

    ' </Snippet5>
    '<Snippet11>
    Protected Overrides Sub OnShutdown()
#If LOGEVENTS Then
        System.Diagnostics.EventLog.WriteEntry("SimpleService.OnShutdown", DateTime.Now.ToLongTimeString() + " - Stopping the SimpleService.")
#End If

    End Sub 'OnShutdown

    '</Snippet11>
    ' <Snippet6>
    ' Continue a paused service.
    Protected Overrides Sub OnContinue()

        ' Signal the worker thread to continue.
        If Not (workerThread Is Nothing) AndAlso (workerThread.ThreadState And System.Threading.ThreadState.Suspended Or System.Threading.ThreadState.SuspendRequested) <> 0 Then
#If LOGEVENTS Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.OnContinue", DateTime.Now.ToLongTimeString() + " - Resuming the service worker thread.")

#End If
            pause.Set()
        End If
#If LOGEVENTS Then
        If Not (workerThread Is Nothing) Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.OnContinue", DateTime.Now.ToLongTimeString() + " OnContinue - Worker thread state = " + workerThread.ThreadState.ToString())
#End If
        End If

    End Sub 'OnContinue

    ' </Snippet6>
    ' <Snippet7>
    ' Handle a custom command.
    Protected Overrides Sub OnCustomCommand(ByVal command As Integer)
#If LOGEVENTS Then
        System.Diagnostics.EventLog.WriteEntry("SimpleService.OnCustomCommand", DateTime.Now.ToLongTimeString() + " - Custom command received: " + command.ToString())
#End If

        ' If the custom command is recognized,
        ' signal the worker thread appropriately.
        Select Case command
            Case Fix(SimpleServiceCustomCommands.StopWorker)
                ' Signal the worker thread to terminate.
                ' For this custom command, the main service
                ' continues to run without a worker thread.
                pause.Reset()

            Case Fix(SimpleServiceCustomCommands.RestartWorker)

                ' Restart the worker thread if necessary.
                pause.Set()

            Case Fix(SimpleServiceCustomCommands.CheckWorker)
#If LOGEVENTS Then
                ' Log the current worker thread state.
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnCustomCommand", DateTime.Now.ToLongTimeString() + " OnCustomCommand - Worker thread state = " + workerThread.ThreadState.ToString())
#End If


            Case Else
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnCustomCommand", DateTime.Now.ToLongTimeString())
#End If
        End Select

    End Sub 'OnCustomCommand

    ' </Snippet7>
    '<Snippet9>
    '<Snippet10>
    ' Handle a session change notice
    Protected Overrides Sub OnSessionChange(ByVal changeDescription As SessionChangeDescription)
#If LOGEVENTS Then
        System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " - Session change notice received: " + changeDescription.Reason.ToString() + "  Session ID: " + changeDescription.SessionId.ToString())
#End If

        '</Snippet10>
        Select Case changeDescription.Reason
            Case SessionChangeReason.SessionLogon
                userCount += 1
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " SessionLogon, total users: " + userCount.ToString())
#End If
            Case SessionChangeReason.SessionLogoff

                userCount -= 1
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " SessionLogoff, total users: " + userCount.ToString())
#End If
            Case SessionChangeReason.RemoteConnect
                userCount += 1
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " RemoteConnect, total users: " + userCount.ToString())
#End If
            Case SessionChangeReason.RemoteDisconnect
                userCount -= 1
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " RemoteDisconnect, total users: " + userCount.ToString())
#End If
            Case SessionChangeReason.SessionLock
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " SessionLock")
#End If
            Case SessionChangeReason.SessionUnlock
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() + " SessionUnlock")
#End If
            Case Else
        End Select

    End Sub 'OnSessionChange

    '</Snippet9>
    ' Define a simple method that runs as the worker thread for 
    ' the service.  
    Public Sub ServiceWorkerMethod()
#If LOGEVENTS Then
        System.Diagnostics.EventLog.WriteEntry("SimpleService.WorkerThread", DateTime.Now.ToLongTimeString() + " - Starting the service worker thread.")
#End If

        Try
            Do
                ' Simulate 4 seconds of work.
                Thread.Sleep(4000)
                ' Block if the service is paused or is shutting down.
                pause.WaitOne()
#If LOGEVENTS Then
                System.Diagnostics.EventLog.WriteEntry("SimpleService.WorkerThread", DateTime.Now.ToLongTimeString() + " - heartbeat cycle.")
#End If
            Loop While True
        Catch
            ' Another thread has signalled that this worker
            ' thread must terminate.  Typically, this occurs when
            ' the main service thread receives a service stop 
            ' command.
            ' Write a trace line indicating that the worker thread
            ' is exiting.  Notice that this simple thread does
            ' not have any local objects or data to clean up.
#If LOGEVENTS Then
            System.Diagnostics.EventLog.WriteEntry("SimpleService.WorkerThread", DateTime.Now.ToLongTimeString() + " - Thread abort signaled.")
#End If
        End Try
#If LOGEVENTS Then

        System.Diagnostics.EventLog.WriteEntry("SimpleService.WorkerThread", DateTime.Now.ToLongTimeString() + " - Exiting the service worker thread.")
#End If

    End Sub 'ServiceWorkerMethod 
End Class 'SimpleService
'</Snippet1>