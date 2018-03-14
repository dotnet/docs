'<Snippet1>
Imports System
Imports System.ServiceProcess
Imports System.Threading
Imports System.Windows.Forms
Imports System.Diagnostics
Imports Microsoft.Win32
Imports System.ComponentModel
Imports System.Configuration.Install

Namespace SimpleServiceVb
    Public Class SimpleService
        Inherits ServiceBase
    
        Shared Sub Main(ByVal args() As String) 
            ServiceBase.Run(New SimpleService())
        End Sub
    
        Protected Overrides Sub OnStart(ByVal args() As String) 
            EventLog.WriteEntry("SimpleService", "Starting SimpleService")
            Dim t As New Thread(AddressOf RunMessagePump)
            t.Start()    
        End Sub
    
        Sub RunMessagePump() 
            EventLog.WriteEntry("SimpleService.MessagePump", _
                "Starting SimpleService Message Pump")
            Application.Run(New HiddenForm())
        End Sub
    
        Protected Overrides Sub OnStop() 
            Application.Exit()
        End Sub
    End Class 

    Partial Class HiddenForm
        Inherits Form

        Public Sub New() 
            InitializeComponent()
        End Sub
    
        Private Sub HiddenForm_Load(ByVal sender As Object, ByVal e As EventArgs) 
            AddHandler SystemEvents.TimeChanged, AddressOf SystemEvents_TimeChanged
            AddHandler SystemEvents.UserPreferenceChanged, AddressOf SystemEvents_UPCChanged
        End Sub 
    
        Private Sub HiddenForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) 
            RemoveHandler SystemEvents.TimeChanged, New EventHandler(AddressOf SystemEvents_TimeChanged)
            RemoveHandler SystemEvents.UserPreferenceChanged, _
                New UserPreferenceChangedEventHandler(AddressOf SystemEvents_UPCChanged)
        End Sub 
    
        Private Sub SystemEvents_TimeChanged(ByVal sender As Object, ByVal e As EventArgs) 
            EventLog.WriteEntry("SimpleService.TimeChanged", _
                "Time changed; it is now " & DateTime.Now.ToLongTimeString())
        End Sub 
    
        Private Sub SystemEvents_UPCChanged(ByVal sender As Object, ByVal e As UserPreferenceChangedEventArgs) 
            EventLog.WriteEntry("SimpleService.UserPreferenceChanged", e.Category.ToString())
        End Sub 
    End Class

    Partial Class HiddenForm

        Private components As System.ComponentModel.IContainer = Nothing
    
        Protected Overrides Sub Dispose(ByVal disposing As Boolean) 
            If disposing AndAlso Not (components Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
  
        Private Sub InitializeComponent() 
            Me.SuspendLayout()
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(0, 0)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "HiddenForm"
            Me.Text = "HiddenForm"
            Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
            AddHandler Me.Load, AddressOf Me.HiddenForm_Load
            AddHandler Me.FormClosing, AddressOf Me.HiddenForm_FormClosing
            Me.ResumeLayout(False)
        End Sub 
    End Class 

    <RunInstaller(True)> _
    Public Class SimpleInstaller
        Inherits Installer

        Private serviceInstaller As ServiceInstaller
        Private processInstaller As ServiceProcessInstaller
    
        Public Sub New() 
            processInstaller = New ServiceProcessInstaller()
            serviceInstaller = New ServiceInstaller()
        
            ' Service will run under system account
            processInstaller.Account = ServiceAccount.LocalSystem
        
            ' Service will have Start Type of Manual
            serviceInstaller.StartType = ServiceStartMode.Automatic
        
            serviceInstaller.ServiceName = "Simple Service"
        
            Installers.Add(serviceInstaller)
            Installers.Add(processInstaller)
        End Sub
    End Class 
End Namespace
'</Snippet1>
