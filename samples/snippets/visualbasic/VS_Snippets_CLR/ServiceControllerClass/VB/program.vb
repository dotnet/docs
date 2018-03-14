'<Snippet1>
Imports System
Imports System.ServiceProcess
Imports System.Diagnostics
Imports System.Threading



Class Program

    Public Enum SimpleServiceCustomCommands
        StopWorker = 128
        RestartWorker
        CheckWorker
    End Enum 'SimpleServiceCustomCommands

    Shared Sub Main(ByVal args() As String)
        Dim scServices() As ServiceController
        scServices = ServiceController.GetServices()

        Dim scTemp As ServiceController
        For Each scTemp In scServices

            If scTemp.ServiceName = "Simple Service" Then
                '<Snippet2>
                ' Display properties for the Simple Service sample 
                ' from the ServiceBase example
                Dim sc As New ServiceController("Simple Service")
                Console.WriteLine("Status = " + sc.Status.ToString())
                Console.WriteLine("Can Pause and Continue = " + _
                    sc.CanPauseAndContinue.ToString())
                Console.WriteLine("Can ShutDown = " + sc.CanShutdown.ToString())
                Console.WriteLine("Can Stop = " + sc.CanStop.ToString())
                '</Snippet2>
                If sc.Status = ServiceControllerStatus.Stopped Then
                    sc.Start()
                    While sc.Status = ServiceControllerStatus.Stopped
                        Thread.Sleep(1000)
                        sc.Refresh()
                    End While
                End If
                '<Snippet3>
                ' Issue custom commands to the service
                ' enum SimpleServiceCustomCommands 
                '    { StopWorker = 128, RestartWorker, CheckWorker };
                sc.ExecuteCommand(Fix(SimpleServiceCustomCommands.StopWorker))
                sc.ExecuteCommand(Fix(SimpleServiceCustomCommands.RestartWorker))
                '</Snippet3>
                '<Snippet4>
                sc.Pause()
                While sc.Status <> ServiceControllerStatus.Paused
                    Thread.Sleep(1000)
                    sc.Refresh()
                End While
                Console.WriteLine("Status = " + sc.Status.ToString())
                '</Snippet4>
                '<Snippet5>
                sc.Continue()
                While sc.Status = ServiceControllerStatus.Paused
                    Thread.Sleep(1000)
                    sc.Refresh()
                End While
                Console.WriteLine("Status = " + sc.Status.ToString())
                '</Snippet5>
                '<Snippet6>
                sc.Stop()
                While sc.Status <> ServiceControllerStatus.Stopped
                    Thread.Sleep(1000)
                    sc.Refresh()
                End While
                Console.WriteLine("Status = " + sc.Status.ToString())
                '</Snippet6>
                '<Snippet7>
                Dim argArray() As String = {"ServiceController arg1", "ServiceController arg2"}
                sc.Start(argArray)
                While sc.Status = ServiceControllerStatus.Stopped
                    Thread.Sleep(1000)
                    sc.Refresh()
                End While
                Console.WriteLine("Status = " + sc.Status.ToString())
                '</Snippet7>
                ' Display the event log entries for the custom commands
                ' and the start arguments.
                Dim el As New EventLog("Application")
                Dim elec As EventLogEntryCollection = el.Entries
                Dim ele As EventLogEntry
                For Each ele In elec
                    If ele.Source.IndexOf("SimpleService.OnCustomCommand") >= 0 Or ele.Source.IndexOf("SimpleService.Arguments") >= 0 Then
                        Console.WriteLine(ele.Message)
                    End If
                Next ele
            End If
        Next scTemp

    End Sub 'Main 
End Class 'Program
' This sample displays the following output if the Simple Service
' sample is running:
'Status = Running
'Can Pause and Continue = True
'Can ShutDown = True
'Can Stop = True
'Status = Paused
'Status = Running
'Status = Stopped
'Status = Running
'4:14:49 PM - Custom command received: 128
'4:14:49 PM - Custom command received: 129
'ServiceController arg1
'ServiceController arg2
'</Snippet1>