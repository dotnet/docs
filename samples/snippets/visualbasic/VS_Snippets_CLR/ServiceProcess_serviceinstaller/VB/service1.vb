 ' The following example illustrates deriving a service implementation from
' the System.ServiceProcess.ServiceBase class.  This simple service starts
' a worker thread, and handles various service commands.
' The main service thread and the worker thread write their trace output
' to c:\service_log.txt.
' <Snippet1>
' Turn on the constant for trace output.
#Const TRACE = True

Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.ServiceProcess
Imports System.Threading
Imports System.Diagnostics


' Define custom commands for the SimpleService.

Public Enum SimpleServiceCustomCommands
    StopWorker = 128
    RestartWorker
    CheckWorker
End Enum 'SimpleServiceCustomCommands 
' Define a simple service implementation.

Public Class SimpleService
    Inherits System.ServiceProcess.ServiceBase
    Private Const logFile As String = "C:\service_log.txt"
    Private Shared serviceTraceListener As TextWriterTraceListener = Nothing
    Private workerThread As Thread = Nothing
    
    
    ' <Snippet2>
    Public Sub New() 
        CanPauseAndContinue = True
        ServiceName = "SimpleService"
    
    End Sub 'New
    
    ' </Snippet2>
    Shared Sub Main() 
        
        ' Create a log file for trace output.
        ' A new file is created each time.  If a
        ' previous log file exists, it is overwritten.
        Dim myFile As StreamWriter = File.CreateText(logFile)
        
        ' Create a new trace listener that writes to the text file,
        ' and add it to the collection of trace listeners.
        serviceTraceListener = New TextWriterTraceListener(myFile)
        Trace.Listeners.Add(serviceTraceListener)
        
        Trace.AutoFlush = True
        Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Service main method starting...", "Main")
        
        ' Load the service into memory.
        System.ServiceProcess.ServiceBase.Run(New SimpleService())
        
        Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Service main method exiting...", "Main")
        
        ' Remove and close the trace listener for this service.
        Trace.Listeners.Remove(serviceTraceListener)
        
        serviceTraceListener.Close()
        serviceTraceListener = Nothing
        myFile.Close()
    
    End Sub 'Main
    
    
    Private Sub InitializeComponent() 
        ' Initialize the operating properties for the service.
        Me.CanPauseAndContinue = True
        Me.CanShutdown = True
        Me.ServiceName = "SimpleService"
        Me.CanHandleSessionChangeEvent = False
    
    End Sub 'InitializeComponent
    
    
    ' <Snippet3>
    ' Start the service.
    Protected Overrides Sub OnStart(ByVal args() As String) 
        ' Start a separate thread that does the actual work.
        If workerThread Is Nothing OrElse(workerThread.ThreadState And System.Threading.ThreadState.Unstarted Or System.Threading.ThreadState.Stopped) <> 0 Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Starting the service worker thread.", "OnStart")
            
            workerThread = New Thread(New ThreadStart(AddressOf ServiceWorkerMethod))
            workerThread.Start()
        End If
        If Not (workerThread Is Nothing) Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Worker thread state = " + workerThread.ThreadState.ToString(), "OnStart")
        End If
    
    End Sub 'OnStart
    
    
    
    ' </Snippet3>
    ' <Snippet4>
    ' Stop this service.
    Protected Overrides Sub OnStop() 
        ' Signal the worker thread to exit.
        If Not (workerThread Is Nothing) AndAlso workerThread.IsAlive Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Stopping the service worker thread.", "OnStop")
            
            workerThread.Abort()
            
            ' Wait up to 500 milliseconds for the thread to terminate.
            workerThread.Join(500)
        End If
        If Not (workerThread Is Nothing) Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Worker thread state = " + workerThread.ThreadState.ToString(), "OnStop")
        End If
    
    End Sub 'OnStop
    
    ' </Snippet4>
    ' <Snippet5>
    ' Pause the service.
    Protected Overrides Sub OnPause() 
        ' Pause the worker thread.
        If Not (workerThread Is Nothing) AndAlso workerThread.IsAlive AndAlso(workerThread.ThreadState And System.Threading.ThreadState.Suspended Or System.Threading.ThreadState.SuspendRequested) = 0 Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Suspending the service worker thread.", "OnPause")
            
            workerThread.Suspend()
        End If
        
        If Not (workerThread Is Nothing) Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Worker thread state = " + workerThread.ThreadState.ToString(), "OnPause")
        End If
    
    End Sub 'OnPause
    
    ' </Snippet5>
    ' <Snippet6>
    ' Continue a paused service.
    Protected Overrides Sub OnContinue() 
        
        ' Signal the worker thread to continue.
        If Not (workerThread Is Nothing) AndAlso(workerThread.ThreadState And System.Threading.ThreadState.Suspended Or System.Threading.ThreadState.SuspendRequested) <> 0 Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Resuming the service worker thread.", "OnContinue")
            
            workerThread.Resume()
        End If
        If Not (workerThread Is Nothing) Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Worker thread state = " + workerThread.ThreadState.ToString(), "OnContinue")
        End If
    
    End Sub 'OnContinue
    
    ' </Snippet6>
    ' <Snippet7>
    ' Handle a custom command.
    Protected Overrides Sub OnCustomCommand(ByVal command As Integer) 
        Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Custom command received: " + command.ToString(), "OnCustomCommand")
        
        ' If the custom command is recognized,
        ' signal the worker thread appropriately.
        Select Case command
            Case Fix(SimpleServiceCustomCommands.StopWorker)
                ' Signal the worker thread to terminate.
                ' For this custom command, the main service
                ' continues to run without a worker thread.
                OnStop()
            
            Case Fix(SimpleServiceCustomCommands.RestartWorker)
                
                ' Restart the worker thread if necessary.
                OnStart(Nothing)
            
            Case Fix(SimpleServiceCustomCommands.CheckWorker)
                
                ' Log the current worker thread state.
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Worker thread state = " + workerThread.ThreadState.ToString(), "OnCustomCommand")
            
            
            Case Else
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Unrecognized custom command ignored!", "OnCustomCommand")
        End Select
    
    End Sub 'OnCustomCommand
    
    ' </Snippet7>
    ' Define a simple method that runs as the worker thread for 
    ' the service.  
    Public Sub ServiceWorkerMethod() 
        Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Starting the service worker thread.", "Worker")
        
        Try
            Do
                ' Wake up every 10 seconds and write
                ' a message to the trace output.
                Thread.Sleep(10000)
                Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - heartbeat cycle.", "Worker")
            Loop While True
        Catch 
            ' Another thread has signalled that this worker
            ' thread must terminate.  Typically, this occurs when
            ' the main service thread receives a service stop 
            ' command.
            ' Write a trace line indicating that the worker thread
            ' is exiting.  Notice that this simple thread does
            ' not have any local objects or data to clean up.
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Thread abort signaled.", "Worker")
        End Try
        
        Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Exiting the service worker thread.", "Worker")
    
    End Sub 'ServiceWorkerMethod
End Class 'SimpleService

' </Snippet1>