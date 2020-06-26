'<SnippetCustomClass>
Public Class MyButtonSimple
    Inherits Button

    ' Create a custom routed event by first registering a RoutedEventID
    ' This event uses the bubbling routing strategy
    '<SnippetAddRemoveHandler>
    Public Shared ReadOnly TapEvent As RoutedEvent = EventManager.RegisterRoutedEvent("Tap", RoutingStrategy.Bubble, GetType(RoutedEventHandler), GetType(MyButtonSimple))

    ' Provide CLR accessors for the event
    Public Custom Event Tap As RoutedEventHandler
        AddHandler(ByVal value As RoutedEventHandler)
            Me.AddHandler(TapEvent, value)
        End AddHandler

        RemoveHandler(ByVal value As RoutedEventHandler)
            Me.RemoveHandler(TapEvent, value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.RaiseEvent(e)
        End RaiseEvent
    End Event
    '</SnippetAddRemoveHandler>

    ' This method raises the Tap event
    '<SnippetRaiseEvent>
    Private Sub RaiseTapEvent()
        Dim newEventArgs As New RoutedEventArgs(MyButtonSimple.TapEvent)
        MyBase.RaiseEvent(newEventArgs)
    End Sub
    '</SnippetRaiseEvent>

    ' For demonstration purposes we raise the event when the MyButtonSimple is clicked
    Protected Overrides Sub OnClick()
        Me.RaiseTapEvent()
    End Sub

End Class
'</SnippetCustomClass>