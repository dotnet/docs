 ' File name: WmiWebEventListener.cs
'* Shows how to capture the WMI events associated with 
'* ASP.NET health monitoriong types. 
' 
' <Snippet1>
Imports System
Imports System.Management



' Capture WMI events associated with 
' ASP.NET health monitoring types. 

Class SampleWmiWebEventListener
    
    'Displays event related information.
    Shared Sub DisplayEventInformation(ByVal ev _
As ManagementBaseObject)

        ' It contains the name of the WMI raised 
        ' event. This is the name of the 
        ' event class as defined in the 
        ' Aspnet.mof file.
        Dim eventTypeName As String

        ' Get the name of the WMI raised event.
        eventTypeName = ev.ClassPath.ToString()

        ' Process the raised event.
        Select Case eventTypeName
            ' Process the heartbeat event.  
            Case "HeartBeatEvent"
                Console.WriteLine("HeartBeat")
                Console.WriteLine(vbTab + _
                "Process: {0}", ev("ProcessName"))
                Console.WriteLine(vbTab + "App: {0}", _
                ev("ApplicationUrl"))
                Console.WriteLine(vbTab + "WorkingSet: {0}", _
                ev("WorkingSet"))
                Console.WriteLine(vbTab + "Threads: {0}", _
                ev("ThreadCount"))
                Console.WriteLine(vbTab + "ManagedHeap: {0}", _
                ev("ManagedHeapSize"))
                Console.WriteLine(vbTab + "AppDomainCount: {0}", _
                ev("AppDomainCount"))

                ' Process the request error event. 
            Case "RequestErrorEvent"
                Console.WriteLine("Error")
                Console.WriteLine("Url: {0}", _
                ev("RequestUrl"))
                Console.WriteLine("Path: {0}", _
                ev("RequestPath"))
                Console.WriteLine("Message: {0}", _
                ev("EventMessage"))
                Console.WriteLine("Stack: {0}", _
                ev("StackTrace"))
                Console.WriteLine("UserName: {0}", _
                ev("UserName"))
                Console.WriteLine("ThreadID: {0}", _
                ev("ThreadAccountName"))

                ' Process the application lifetime event. 
            Case "ApplicationLifetimeEvent"
                Console.WriteLine("App Lifetime Event {0}", _
                ev("EventMessage"))


                ' Handle events for which processing is not
                ' provided.
            Case Else
                Console.WriteLine("ASP.NET Event {0}", _
                ev("EventMessage"))
        End Select

    End Sub 'DisplayEventInformation

    ' End DisplayEventInformation.
    ' The main entry point for the application.
    Shared Sub Main(ByVal args() As String)
        ' Get the name of the computer on 
        ' which this program runs.
        ' Note. The monitored application must also run 
        ' on this computer.
        Dim machine As String = Environment.MachineName

        ' Define the Common Information Model (CIM) path 
        ' for WIM monitoring. 
        Dim path As String = _
        String.Format("\\{0}\root\aspnet", machine)

        ' Create a managed object watcher as 
        ' defined in System.Management.
        Dim query As String = "select * from BaseEvent"
        Dim watcher As New ManagementEventWatcher(query)

        ' Set the watcher options.
        Dim timeInterval As New TimeSpan(0, 1, 30)
        watcher.Options = _
        New EventWatcherOptions(Nothing, timeInterval, 1)

        ' Set the scope of the WMI events to 
        ' watch to be ASP.NET applications.
        watcher.Scope = _
        New ManagementScope(New ManagementPath(path))

        ' Set the console background.
        Console.BackgroundColor = ConsoleColor.Blue
        ' Set foreground color.
        Console.ForegroundColor = ConsoleColor.Yellow
        ' Clear the console.
        Console.Clear()

        ' Loop indefinitely to catch the events.
        Console.WriteLine( _
        "Listener started. Enter CntlC to terminate")


        While True
            Try
                ' Capture the WMI event related to 
                ' the Web event.
                Dim ev As ManagementBaseObject = _
                watcher.WaitForNextEvent()
                ' Display the Web event information.
                DisplayEventInformation(ev)

                ' Prompt the user.
                Console.Beep()

            Catch e As Exception
                Console.WriteLine("Error: {0}", e)
                Exit While
            End Try
        End While

    End Sub 'Main 
End Class 'SampleWmiWebEventListener 


' </Snippet1>