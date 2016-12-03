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