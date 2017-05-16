
' <Snippet1>

Imports System

Namespace EventSample

    ' Class that contains the data for
    ' the alarm event. Derives from System.EventArgs.
    '
    Public Class AlarmEventArgs
        Inherits EventArgs
        Private _snoozePressed As Boolean
        Private nrings As Integer

        'Constructor.
        '
        Public Sub New(snoozePressed As Boolean, nrings As Integer)
            Me._snoozePressed = snoozePressed
            Me.nrings = nrings
        End Sub

        ' The NumRings property returns the number of rings
        ' that the alarm clock has sounded when the alarm event
        ' is generated.
        '
        Public ReadOnly Property NumRings() As Integer
            Get
                Return nrings
            End Get
        End Property

        ' The SnoozePressed property indicates whether the snooze
        ' button is pressed on the alarm when the alarm event is generated.
        '
        Public ReadOnly Property SnoozePressed() As Boolean
            Get
                Return _snoozePressed
            End Get
        End Property

        ' The AlarmText property that contains the wake-up message.
        '
        Public ReadOnly Property AlarmText() As String
            Get
                If _snoozePressed Then
                    Return "Wake Up!!! Snooze time is over."
                Else
                    Return "Wake Up!"
                End If
            End Get
        End Property
    End Class


    ' Delegate declaration.
    '
    Public Delegate Sub AlarmEventHandler(sender As Object, e As AlarmEventArgs)

    ' The Alarm class that raises the alarm event.
    '
    Public Class AlarmClock
        Private _snoozePressed As Boolean = False
        Private nrings As Integer = 0
        Private stopFlag As Boolean = False

        ' The Stop property indicates whether the
        ' alarm should be turned off.
        '
        Public Property [Stop]() As Boolean
            Get
                Return stopFlag
            End Get
            Set
                stopFlag = value
            End Set
        End Property

        ' The SnoozePressed property indicates whether the snooze
        ' button is pressed on the alarm when the alarm event is generated.
        '
        Public Property SnoozePressed() As Boolean
            Get
                Return _snoozePressed
            End Get
            Set
                _snoozePressed = value
            End Set
        End Property

        ' The event member that is of type AlarmEventHandler.
        '
        Public Event Alarm As AlarmEventHandler

        ' The protected OnAlarm method raises the event by invoking
        ' the delegates. The sender is always this, the current instance
        ' of the class.
        '
        Protected Overridable Sub OnAlarm(e As AlarmEventArgs)
            RaiseEvent Alarm(Me, e)
        End Sub

        ' This alarm clock does not have
        ' a user interface.
        ' To simulate the alarm mechanism it has a loop
        ' that raises the alarm event at every iteration
        ' with a time delay of 300 milliseconds,
        ' if snooze is not pressed. If snooze is pressed,
        ' the time delay is 1000 milliseconds.
        '
        Public Sub Start()
            Do
                nrings += 1
                If stopFlag Then
                    Exit Do
                Else
                    If _snoozePressed Then
                        System.Threading.Thread.Sleep(1000)
                    Else
                        System.Threading.Thread.Sleep(300)
                    End If
                    Dim e As New AlarmEventArgs(_snoozePressed, nrings)
                    OnAlarm(e)
                End If
            Loop
        End Sub
    End Class

   ' The WakeMeUp class has a method AlarmRang that handles the
   ' alarm event.
   '
   Public Class WakeMeUp
      Public Sub AlarmRang(sender As Object, e As AlarmEventArgs)
         
         Console.WriteLine((e.AlarmText + ControlChars.Cr))
         
         If Not e.SnoozePressed Then
            If e.NumRings Mod 10 = 0 Then
               Console.WriteLine(" Let alarm ring? Enter Y")
               Console.WriteLine(" Press Snooze? Enter N")
               Console.WriteLine(" Stop Alarm? Enter Q")
               Dim input As String = Console.ReadLine()
               
               If input.Equals("Y") Or input.Equals("y") Then
                  Return
               
               Else
                  If input.Equals("N") Or input.Equals("n") Then
                     CType(sender, AlarmClock).SnoozePressed = True
                     Return
                  Else
                     CType(sender, AlarmClock).Stop = True
                     Return
                  End If
               End If
            End If
         Else
            Console.WriteLine(" Let alarm ring? Enter Y")
            Console.WriteLine(" Stop Alarm? Enter Q")
            Dim input As String = Console.ReadLine()
            If input.Equals("Y") Or input.Equals("y") Then
               Return
            Else
               CType(sender, AlarmClock).Stop = True
               Return
            End If
         End If
      End Sub
   End Class
   
   ' The driver class that hooks up the event handling method of
   ' WakeMeUp to the alarm event of an Alarm object using a delegate.
   ' In a forms-based application, the driver class is the
   ' form.
   '
   Public Class AlarmDriver
      Public Shared Sub Main()
         ' Instantiates the event receiver.
         Dim w As New WakeMeUp()
         
         ' Instantiates the event source.
         Dim clock As New AlarmClock()
         
         ' Wires the AlarmRang method to the Alarm event.
         AddHandler clock.Alarm, AddressOf w.AlarmRang
         
         clock.Start()
      End Sub
   End Class
End Namespace

' </Snippet1>
