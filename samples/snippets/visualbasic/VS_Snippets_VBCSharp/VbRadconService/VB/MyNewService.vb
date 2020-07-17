'********************************************************************
Imports System.ServiceProcess

Namespace MyNewService

    '********************************************************************
    Public Class Service1
        Inherits System.ServiceProcess.ServiceBase

        Shared Sub MainOriginal()
            '<Snippet6>
            Dim ServicesToRun() As System.ServiceProcess.ServiceBase
            ServicesToRun =
                New System.ServiceProcess.ServiceBase() {New Service1()}
            System.ServiceProcess.ServiceBase.Run(ServicesToRun)
            '</Snippet6>
        End Sub

    End Class



    '********************************************************************
    Public Class MyNewService
        Inherits System.ServiceProcess.ServiceBase

        ' The main entry point for the process
        '<MTAThread()> _
        '<System.Diagnostics.DebuggerNonUserCode()>

        '<Snippet1>
        ' To access the Main method in Visual Basic, select Main from the
        ' method name drop-down list. This expands the Component Designer 
        ' generated code region.
        Shared Sub Main()
            Dim ServicesToRun() As System.ServiceProcess.ServiceBase
            ' Change the following line to match.
            ServicesToRun =
                New System.ServiceProcess.ServiceBase() {New MyNewService()}
            System.ServiceProcess.ServiceBase.Run(ServicesToRun)
        End Sub
        '</Snippet1>


        'Required by the Component Designer
        '<Snippet16>
        Private components As System.ComponentModel.IContainer
        Private EventLog1 As System.Diagnostics.EventLog
        '</Snippet16>


        ' NOTE: The following procedure is required by the Component Designer
        ' It can be modified using the Component Designer.  
        ' Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            Me.ServiceName = "MyNewService"
        End Sub


        '<Snippet2>
        ' To access the constructor in Visual Basic, select New from the
        ' method name drop-down list. 
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Me.EventLog1 = New System.Diagnostics.EventLog
            If Not System.Diagnostics.EventLog.SourceExists("MySource") Then
                System.Diagnostics.EventLog.CreateEventSource("MySource",
                "MyNewLog")
            End If
            EventLog1.Source = "MySource"
            EventLog1.Log = "MyNewLog"
        End Sub
        '</Snippet2>


        '<Snippet3>
        ' To access the OnStart in Visual Basic, select OnStart from the
        ' method name drop-down list. 
        Protected Overrides Sub OnStart(ByVal args() As String)
            EventLog1.WriteEntry("In OnStart")
        End Sub
        '</Snippet3>


        '<Snippet4>
        Protected Overrides Sub OnStop()
            EventLog1.WriteEntry("In OnStop.")
        End Sub
        '</Snippet4>


        '<Snippet5>
        Protected Overrides Sub OnContinue()
            EventLog1.WriteEntry("In OnContinue.")
        End Sub
        '</Snippet5>


        'UserService overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class


    '********************************************************************
    '<Snippet7>
    Public Class UserService1
        Inherits System.ServiceProcess.ServiceBase
    End Class
    '</Snippet7>


    '********************************************************************
    Public Class Service2
        Inherits System.ServiceProcess.ServiceBase

        '<Snippet8>
        Public Sub New()
            Me.ServiceName = "MyService2"
            Me.CanStop = True
            Me.CanPauseAndContinue = True
            Me.AutoLog = True
        End Sub
        '</Snippet8>


        '<Snippet9>
        Shared Sub Main()
            System.ServiceProcess.ServiceBase.Run(New UserService1)
        End Sub
        '</Snippet9>


        '<Snippet10>
        Protected Overrides Sub OnStart(ByVal args() As String)
            ' Insert code here to define processing.
        End Sub
        '</Snippet10>
    End Class


    '********************************************************************
    Public Class Service3
        Inherits System.ServiceProcess.ServiceBase

        Private EventLog1 As System.Diagnostics.EventLog

        '<Snippet14>
        Public Sub New()
            ' Turn off autologging
            '<Snippet17>
            Me.AutoLog = False
            '</Snippet17>
            ' Create a new event source and specify a log name that
            ' does not exist to create a custom log
            If Not System.Diagnostics.EventLog.SourceExists("MySource") Then
                System.Diagnostics.EventLog.CreateEventSource("MySource",
                    "MyLog")
            End If
            ' Configure the event log instance to use this source name
            EventLog1.Source = "MySource"
        End Sub
        '</Snippet14>


        '<Snippet15>
        Protected Overrides Sub OnStart(ByVal args() As String)
            ' Write an entry to the log you've created.
            EventLog1.WriteEntry("In Onstart.")
        End Sub
        '</Snippet15>
    End Class


    '********************************************************************
    Class Class1
        Sub test()
            '<Snippet11>
            Dim theController As System.ServiceProcess.ServiceController
            theController = New System.ServiceProcess.ServiceController("IISAdmin")
            '</Snippet11>


            '<Snippet12>
            ' Pauses the service.
            theController.Pause()
            '</Snippet12>


            '<Snippet13>
            ' Checks that the service is paused.
            If theController.Status =
                System.ServiceProcess.ServiceControllerStatus.Paused Then

                ' Continues the service.
                theController.Continue()
            End If
            '</Snippet13>
        End Sub
    End Class

End Namespace
