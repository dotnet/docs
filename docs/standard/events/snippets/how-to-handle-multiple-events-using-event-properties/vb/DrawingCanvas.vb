' <EventProperties>
Imports System.ComponentModel

Public Class StrokeEventArgs
    Inherits EventArgs

    Public ReadOnly Property X As Integer
    Public ReadOnly Property Y As Integer

    Public Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
    End Sub
End Class

' The class DrawingCanvas defines two event properties, StrokeStarted and StrokeEnded.
Class DrawingCanvas

    ' Define the delegate collection.
    Protected listEventDelegates As New EventHandlerList()

    ' Define a unique key for each event.
    Shared ReadOnly strokeStartedEventKey As New Object()
    Shared ReadOnly strokeEndedEventKey As New Object()

    ' Define the StrokeStarted event property.
    Public Custom Event StrokeStarted As EventHandler(Of StrokeEventArgs)
        AddHandler(Value As EventHandler(Of StrokeEventArgs))
            listEventDelegates.AddHandler(strokeStartedEventKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of StrokeEventArgs))
            listEventDelegates.RemoveHandler(strokeStartedEventKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As StrokeEventArgs)
            Dim strokeEventDelegate As EventHandler(Of StrokeEventArgs) =
                listEventDelegates(strokeStartedEventKey)
            strokeEventDelegate?.Invoke(sender, e)
        End RaiseEvent
    End Event

    ' Define the StrokeEnded event property.
    Public Custom Event StrokeEnded As EventHandler(Of StrokeEventArgs)
        AddHandler(Value As EventHandler(Of StrokeEventArgs))
            listEventDelegates.AddHandler(strokeEndedEventKey, Value)
        End AddHandler
        RemoveHandler(Value As EventHandler(Of StrokeEventArgs))
            listEventDelegates.RemoveHandler(strokeEndedEventKey, Value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As StrokeEventArgs)
            Dim strokeEventDelegate As EventHandler(Of StrokeEventArgs) =
                listEventDelegates(strokeEndedEventKey)
            strokeEventDelegate?.Invoke(sender, e)
        End RaiseEvent
    End Event
End Class
' </EventProperties>
