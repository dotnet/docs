'<snippet30>
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

'<snippet31>
' The class SampleControl defines two event properties, MouseUp and MouseDown.
Class SampleControl
    Inherits Component
    ' :
    ' Define other control methods and properties.
    ' :

    ' Define the delegate collection.
    Protected listEventDelegates As New EventHandlerList()

    ' Define a unique key for each event.
    Shared ReadOnly mouseDownEventKey As New Object()
    Shared ReadOnly mouseUpEventKey As New Object()

    ' Define the MouseDown event property.
    Public Custom Event MouseDown As MouseEventHandler
        ' Add the input delegate to the collection.
        AddHandler(Value As MouseEventHandler)
            listEventDelegates.AddHandler(mouseDownEventKey, Value)
        End AddHandler
        ' Remove the input delegate from the collection.
        RemoveHandler(Value As MouseEventHandler)
            listEventDelegates.RemoveHandler(mouseDownEventKey, Value)
        End RemoveHandler
        ' Raise the event with the delegate specified by mouseDownEventKey
        RaiseEvent(sender As Object, e As MouseEventArgs)
            Dim mouseEventDelegate As MouseEventHandler = _
                listEventDelegates(mouseDownEventKey)
            mouseEventDelegate(sender, e)
        End RaiseEvent
    End Event

    ' Define the MouseUp event property.
    Public Custom Event MouseUp As MouseEventHandler
        ' Add the input delegate to the collection.
        AddHandler(Value As MouseEventHandler)
            listEventDelegates.AddHandler(mouseUpEventKey, Value)
        End AddHandler
        ' Remove the input delegate from the collection.
        RemoveHandler(Value As MouseEventHandler)
            listEventDelegates.RemoveHandler(mouseUpEventKey, Value)
        End RemoveHandler
        ' Raise the event with the delegate specified by mouseDownUpKey
        RaiseEvent(sender As Object, e As MouseEventArgs)
            Dim mouseEventDelegate As MouseEventHandler = _
                listEventDelegates(mouseUpEventKey)
            mouseEventDelegate(sender, e)
        End RaiseEvent
    End Event
End Class
'</snippet31>

Class Dummy
    Public Shared Sub Main()
        Console.WriteLine("Dummy.Main()")
    End Sub
End Class
'</snippet30>
