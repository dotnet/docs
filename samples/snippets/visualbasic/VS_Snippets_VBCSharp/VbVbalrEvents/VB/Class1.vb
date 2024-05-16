Class Class072b9cf6629846f1849e4edc1631564c
    ' WithEvents and the Handles Clause

    ' <snippet1>
    ' Declare a WithEvents variable.
    Dim WithEvents EClass As New EventClass

    ' Call the method that raises the object's events.
    Sub TestEvents()
        EClass.RaiseEvents()
    End Sub

    ' Declare an event handler that handles multiple events.
    Sub EClass_EventHandler() Handles EClass.XEvent, EClass.YEvent
        MsgBox("Received Event.")
    End Sub

    Class EventClass
        Public Event XEvent()
        Public Event YEvent()
        ' RaiseEvents raises both events.
        Sub RaiseEvents()
            RaiseEvent XEvent()
            RaiseEvent YEvent()
        End Sub
    End Class
    ' </snippet1>

End Class

Class Class1b051c0ef49942f6acb56f4f27824b40
    ' Handles

    ' <snippet2>
    Public Class ContainerClass
        ' Module or class level declaration.
        WithEvents Obj As New Class1

        Public Class Class1
            ' Declare an event.
            Public Event Ev_Event()
            Sub CauseSomeEvent()
                ' Raise an event.
                RaiseEvent Ev_Event()
            End Sub
        End Class

        Sub EventHandler() Handles Obj.Ev_Event
            ' Handle the event.
            MsgBox("EventHandler caught event.")
        End Sub

        ' Call the TestEvents procedure from an instance of the ContainerClass 
        ' class to test the Ev_Event event and the event handler.
        Public Sub TestEvents()
            Obj.CauseSomeEvent()
        End Sub
    End Class
    ' </snippet2>

    ' <snippet3>
    Public Class BaseClass
        ' Declare an event.
        Event Ev1()
    End Class
    Class DerivedClass
        Inherits BaseClass
        Sub TestEvents() Handles MyBase.Ev1
            ' Add code to handle this event.
        End Sub
    End Class
    ' </snippet3>

End Class

Class Class2a131bf7add74c749a8162953ba6717b
    ' How to: Write Event Handlers

    ' <snippet4>
    Class Class1
        Public Event AnEvent(ByVal EventNumber As Integer)
    End Class
    ' </snippet4>

    ' <snippet5>
    Public WithEvents ClassInst As Class1
    ' </snippet5>

    ' <snippet6>
    Public Sub ClassInst_AnEvent(ByVal EventNumber As Integer
     ) Handles ClassInst.AnEvent

        MsgBox("Received event number: " & CStr(EventNumber))
    End Sub
    ' </snippet6>

    ' <snippet7>
    Public Sub EHandler(ByVal EventNumber As Integer)
        MsgBox("Received event number " & CStr(EventNumber))
    End Sub
    ' </snippet7>

    ' <snippet8>
    Public Sub TestAddHandler()
        Dim CI As New Class1
    End Sub
    ' </snippet8>

    Public Sub Method9()
        Dim CI As New Class1

        ' <snippet9>
        AddHandler CI.AnEvent, AddressOf EHandler
        ' </snippet9>

        ' <snippet11>
        RemoveHandler CI.AnEvent, AddressOf EHandler
        ' </snippet11>

    End Sub

    ' <snippet12>
    Public Class BaseClass
        Public Event BaseEvent(ByVal i As Integer)
        ' Place methods and properties here.
    End Class

    Public Class DerivedClass
        Inherits BaseClass
        Sub EventHandler(ByVal x As Integer) Handles MyBase.BaseEvent
            ' Place code to handle events from BaseClass here.
        End Sub
    End Class
    ' </snippet12>

End Class

Class Class306ff8ed74dd4b6abd2fe91b17474042
    ' Event Statement

    ' Snippets 14 and 15 are also used by 
    '    Class Classf82e380a1e6b4047bea8c853f4d2c742
    ' RaiseEvent Statement


    ' <snippet13>
    Public Class EventSource
        ' Declare an event.
        Public Event LogonCompleted(ByVal UserName As String)
        Sub CauseEvent()
            ' Raise an event on successful logon.
            RaiseEvent LogonCompleted("AustinSteele")
        End Sub
    End Class
    ' </snippet13>

    Class Form1
        Inherits Form
        Private WithEvents Button1 As New Button
        Private WithEvents TextBox1 As New TextBox

        ' <snippet14>
        Private WithEvents mText As TimerState
        ' </snippet14>

        ' <snippet15>
        Private Sub Form1_Load() Handles MyBase.Load
            Button1.Text = "Start"
            mText = New TimerState
        End Sub
        Private Sub Button1_Click() Handles Button1.Click
            mText.StartCountdown(10.0, 0.1)
        End Sub

        Private Sub mText_ChangeText() Handles mText.Finished
            TextBox1.Text = "Done"
        End Sub

        Private Sub mText_UpdateTime(ByVal Countdown As Double
          ) Handles mText.UpdateTime

            TextBox1.Text = Format(Countdown, "##0.0")
            ' Use DoEvents to allow the display to refresh.
            My.Application.DoEvents()
        End Sub

        Class TimerState
            Public Event UpdateTime(ByVal Countdown As Double)
            Public Event Finished()
            Public Sub StartCountdown(ByVal Duration As Double,
                                      ByVal Increment As Double)
                Dim Start As Double = DateAndTime.Timer
                Dim ElapsedTime As Double = 0

                Dim SoFar As Double = 0
                Do While ElapsedTime < Duration
                    If ElapsedTime > SoFar + Increment Then
                        SoFar += Increment
                        RaiseEvent UpdateTime(Duration - SoFar)
                    End If
                    ElapsedTime = DateAndTime.Timer - Start
                Loop
                RaiseEvent Finished()
            End Sub
        End Class
        ' </snippet15>

    End Class
End Class

Class Class3f76e3ed23f343dfbeb52c9830890d45
    ' How to: Raise an Event (Visual Basic)

    ' <snippet16>
    Public Event TimeExpired(ByVal Status As String)
    Public Sub RaiseTimeExpiredEvent()
        RaiseEvent TimeExpired("Your time has run out")
    End Sub
    ' </snippet16>

End Class

Class Class647cd825e8774910b4f18d168beebe6a
    ' RemoveHandler Statement
    ' AddHandler Statement

    ' <snippet17>
    Sub TestEvents()
        Dim Obj As New Class1
        ' Associate an event handler with an event.
        AddHandler Obj.Ev_Event, AddressOf EventHandler
        ' Call the method to raise the event.
        Obj.CauseSomeEvent()
        ' Stop handling events.
        RemoveHandler Obj.Ev_Event, AddressOf EventHandler
        ' This event will not be handled.
        Obj.CauseSomeEvent()
        ' Associate an event handler with an event, using a lambda.
        ' This handler cannot be removed.
        AddHandler Obj.Ev_Event, Sub ()
            MsgBox("Lambda caught event.")
        End Sub
        ' This event will be handled by the lambda above.
        Obj.CauseSomeEvent()
    End Sub

    Sub EventHandler()
        ' Handle the event.
        MsgBox("EventHandler caught event.")
    End Sub

    Public Class Class1
        ' Declare an event.
        Public Event Ev_Event()
        Sub CauseSomeEvent()
            ' Raise an event.
            RaiseEvent Ev_Event()
        End Sub
    End Class
    ' </snippet17>

End Class

Class Class6965efdc2b254b84945d0e918a7b9417
    ' How to: Create an Event and Handler (Visual Basic)

    ' <snippet20>
    Public Event TimeExpired(ByVal Status As String)
    Public Sub HandleTimeExpired(ByVal Status As String)
        ' Perform desired processing for when time has expired.
        MsgBox("HandleTimeExpired caught the TimeExpired event" &
               vbCrLf & "Status = " & Status)
    End Sub
    Public Sub SetUpEventHandler()
        AddHandler TimeExpired, AddressOf HandleTimeExpired
    End Sub
    ' </snippet20>

End Class

Class Class87ebee87260c462f979c407874debd19
    ' How to: Declare Events That Conserve Memory Use

    ' <snippet22>
    Public Class MemoryOptimizedBaseControl
        ' Define a delegate store for all event handlers.
        Private Events As New System.ComponentModel.EventHandlerList

        ' Define the Click event to use the delegate store.
        Public Custom Event Click As EventHandler
            AddHandler(ByVal value As EventHandler)
                Events.AddHandler("ClickEvent", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                Events.RemoveHandler("ClickEvent", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
                CType(Events("ClickEvent"), EventHandler).Invoke(sender, e)
            End RaiseEvent
        End Event

        ' Define the DoubleClick event to use the same delegate store.
        Public Custom Event DoubleClick As EventHandler
            AddHandler(ByVal value As EventHandler)
                Events.AddHandler("DoubleClickEvent", value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                Events.RemoveHandler("DoubleClickEvent", value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
                CType(Events("DoubleClickEvent"), EventHandler).Invoke(sender, e)
            End RaiseEvent
        End Event

        ' Define additional events to use the same delegate store.
        ' ...
    End Class
    ' </snippet22>

End Class

Class Class95074a0d1cbc4221a95a964185c7f962
    ' Events and Event Handlers

    ' <snippet24>
    Event AnEvent(ByVal EventNumber As Integer)
    ' </snippet24>

    Public Sub Method25()
        Dim EventNumber As Integer = 5
        ' <snippet25>
        RaiseEvent AnEvent(EventNumber)
        ' </snippet25>
    End Sub

    ' <snippet26>
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Protected Sub Button1_Click() Handles Button1.Click
    End Sub
    ' </snippet26>

End Class

Class Class998b6a9067c54d2c8b11366d3e355505
    ' How to: Declare Events That Avoid Blocking

    ' <snippet27>
    Public NotInheritable Class ReliabilityOptimizedControl
        'Defines a list for storing the delegates
        Private EventHandlerList As New ArrayList

        'Defines the Click event using the custom event syntax.
        'The RaiseEvent always invokes the delegates asynchronously
        Public Custom Event Click As EventHandler
            AddHandler(ByVal value As EventHandler)
                EventHandlerList.Add(value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                EventHandlerList.Remove(value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
                For Each handler As EventHandler In EventHandlerList
                    If handler IsNot Nothing Then
                        handler.BeginInvoke(sender, e, Nothing, Nothing)
                    End If
                Next
            End RaiseEvent
        End Event
    End Class
    ' </snippet27>

End Class

Class Classa7a24bd2519a46fe8a2c2b9df2ca28ef
    ' AddHandler and RemoveHandler

    Class Class1
        Public Event XEvent()
    End Class

    Private Sub XEventHandler()
    End Sub

    Public Sub Method28()
        Dim Obj As New Class1

        ' <snippet28>
        AddHandler Obj.XEvent, AddressOf Me.XEventHandler
        ' </snippet28>

        ' <snippet29>
        RemoveHandler Obj.XEvent, AddressOf Me.XEventHandler
        ' </snippet29>
    End Sub

End Class

Class Classe1c8759f5370430884768c48b73509bf
    ' Troubleshooting Inherited Event Handlers in Visual Basic 2005

    Class Class1
        Protected WithEvents Button1 As New Button
        Protected Overridable Sub Button1_Click(
            ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles Button1.Click
        End Sub
    End Class
    Class Class2
        Inherits Class1
        ' <snippet32>
        ' INCORRECT
        Protected Overrides Sub Button1_Click(
            ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles Button1.Click

            ' The Handles clause will cause all code
            ' in this block to be executed twice.
        End Sub
        ' </snippet32>
    End Class

End Class

Class Classecf5d551ab874020af1886dea054a033
    ' How to: Add Events to a Class

    ' <snippet33>
    Public Event PercentDone(ByVal Percent As Single,
                             ByRef Cancel As Boolean)
    ' </snippet33>

End Class

Class Classee80db040f194a8d8eb958c54f4df370
    ' Event Handler Example

    ' <snippet34>
    Public Class Class1
        ' Declare an event for this class.
        Public Event Event1(ByVal EventNumber As Integer)
        ' Define a method that raises an event.
        Sub CauseEvent(ByVal EventNumber As Integer)
            RaiseEvent Event1(EventNumber)
        End Sub
    End Class

    Protected Sub TestEvents(ByVal EventNumber As Integer)
        Dim Obj As New Class1
        AddHandler Obj.Event1, AddressOf Me.EventHandler
        ' Cause the object to raise an event.
        Obj.CauseEvent(EventNumber)
    End Sub

    Sub EventHandler(ByVal EventNumber As Integer)
        MsgBox("Received event number " & EventNumber.ToString)
    End Sub
    ' </snippet34>

End Class

Class Classf82e380a1e6b4047bea8c853f4d2c742
    ' RaiseEvent Statement

    ' This topic also uses snippets 14 and 15, defined above.

    ' <snippet37>
    ' Declare an event at module level.
    Event LogonCompleted(ByVal UserName As String)

    Sub Logon(ByVal UserName As String)
        ' Raise the event.
        RaiseEvent LogonCompleted(UserName)
    End Sub
    ' </snippet37>
End Class
