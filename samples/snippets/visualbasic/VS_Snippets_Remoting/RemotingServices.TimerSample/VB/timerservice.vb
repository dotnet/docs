 ' <Snippet3>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions
Imports System.Timers


' Define the event arguments
<Serializable()>  _
Public Class TimerServiceEventArgs
    Inherits EventArgs
    Private m_Message As String
    
    Public Sub New(ByVal message As String) 
        m_Message = message
    
    End Sub 'New
    
    
    Public ReadOnly Property Message() As String 
        Get
            Return m_Message
        End Get
    End Property
End Class 'TimerServiceEventArgs


' Define the delegate for the event
Public Delegate Sub TimerExpiredEventHandler(ByVal sender As Object, ByVal e As TimerServiceEventArgs) 

' Define the remote service class

Public Class TimerService
    Inherits MarshalByRefObject
    Private m_MinutesToTime As Double
    Private m_Timer As Timer
    
    ' The client will subscribe and unsubscribe to this event
    Public Event TimerExpired As TimerExpiredEventHandler
    
    
    ' Default: Initialize the TimerService to 4 minutes, the time required
    ' to brew coffee in a French Press.
    Public Sub New() 
        MyClass.New(4.0)
    
    End Sub 'New
    
    
    Public Sub New(ByVal minutes As Double) 
        Console.WriteLine("TimerService instantiated.")
        m_MinutesToTime = minutes
        m_Timer = New Timer()
        AddHandler m_Timer.Elapsed, AddressOf OnElapsed
    
    End Sub 'New
    
    
    Public Property MinutesToTime() As Double 
        Get
            Return m_MinutesToTime
        End Get
        Set
            m_MinutesToTime = value
        End Set
    End Property
    
    
    Public Sub Start() 
        If Not m_Timer.Enabled Then
            Dim interval As TimeSpan = TimeSpan.FromMinutes(m_MinutesToTime)
            m_Timer.Interval = interval.TotalMilliseconds
            m_Timer.Enabled = True
        Else
        End If
     ' TODO: Raise an exception
    End Sub 'Start
    
    
    Private Sub OnElapsed(ByVal [source] As Object, ByVal e As ElapsedEventArgs) 
        m_Timer.Enabled = False
        
        ' Fire Event
        If Not (TimerExpiredEvent Is Nothing) Then
            ' Package String in TimerServiceEventArgs
            Dim timerEventArgs As New TimerServiceEventArgs("TimerServiceEventArgs: Timer Expired.")
            Console.WriteLine("Firing TimerExpired Event")
            RaiseEvent TimerExpired(Me, timerEventArgs)
        End If
    
    End Sub 'OnElapsed
    
    <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
    Public Overrides Function InitializeLifetimeService() As [Object] 
        Dim lease As ILease = CType(MyBase.InitializeLifetimeService(), ILease)
        If lease.CurrentState = LeaseState.Initial Then
            lease.InitialLeaseTime = TimeSpan.FromMinutes(0.125)
            lease.SponsorshipTimeout = TimeSpan.FromMinutes(2)
            lease.RenewOnCallTime = TimeSpan.FromSeconds(2)
            Console.WriteLine("TimerService: InitializeLifetimeService")
        End If
        Return lease
    
    End Function 'InitializeLifetimeService
End Class 'TimerService

' </Snippet3>