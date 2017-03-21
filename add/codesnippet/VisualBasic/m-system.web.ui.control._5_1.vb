      Public Overrides Sub DataBind()
         MyBase.OnDataBinding(EventArgs.Empty)
         ' Reset the control's state.
         Controls.Clear()
         ' Check for HasChildViewState to avoid unnecessary calls to ClearChildViewState.
         If HasChildViewState Then
            ClearChildViewState()
         End If
         ChildControlsCreated = True
         If Not IsTrackingViewState Then
            TrackViewState()
         End If
      End Sub