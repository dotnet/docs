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