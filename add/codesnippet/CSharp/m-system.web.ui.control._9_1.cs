      public override void DataBind() 
      {
         base.OnDataBinding(EventArgs.Empty);
         // Reset the control's state.
         Controls.Clear();
         // Check for HasChildViewState to avoid unnecessary calls to ClearChildViewState.
         if (HasChildViewState)
            ClearChildViewState();
         ChildControlsCreated = true;
         if (!IsTrackingViewState)
            TrackViewState();
      }