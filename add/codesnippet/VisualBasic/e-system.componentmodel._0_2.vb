      ' This is the OnSelectionChanged handler method.  This method calls
      '  OnUserChange to display a message that indicates the name of the
      '  handler that made the call and the type of the event argument. 
      Private Sub OnSelectionChanged(ByVal sender As Object, ByVal args As EventArgs)
         OnUserChange("OnSelectionChanged", args.ToString())
      End Sub 'OnSelectionChanged
