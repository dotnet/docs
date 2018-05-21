Namespace My

  Partial Friend Class MyApplication

    ' Custom event handler for Load event.
    Private _sampleExtensionHandlers As EventHandler

    Public Custom Event SampleExtensionLoad As EventHandler
      AddHandler(ByVal value As EventHandler)
        ' Warning: This code is not thread-safe. Do not call
        ' this code from multiple concurrent threads.
        If _sampleExtensionHandlers Is Nothing Then
          AddHandler My.SampleExtension.Load, AddressOf OnSampleExtensionLoad
        End If
        _sampleExtensionHandlers = 
            System.Delegate.Combine(_sampleExtensionHandlers, value)
      End AddHandler
      RemoveHandler(ByVal value As EventHandler)
        _sampleExtensionHandlers = 
          System.Delegate.Remove(_sampleExtensionHandlers, value)
      End RemoveHandler
      RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
        If _sampleExtensionHandlers IsNot Nothing Then
          _sampleExtensionHandlers.Invoke(sender, e)
        End If
      End RaiseEvent
    End Event

    ' Method called by custom event handler to raise user-defined
    ' event handlers.
    <Global.System.ComponentModel.EditorBrowsable( 
         Global.System.ComponentModel.EditorBrowsableState.Advanced)> 
      Protected Overridable Sub OnSampleExtensionLoad( 
                ByVal sender As Object, ByVal e As EventArgs)
      RaiseEvent SampleExtensionLoad(sender, e)
    End Sub

    ' Event handler to call My.SampleExtensionLoad event.
    Private Sub MyApplication_SampleExtensionLoad( 
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.SampleExtensionLoad

    End Sub
  End Class
End Namespace