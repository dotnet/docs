        ' Handler for the Click event, which provides the region in the arguments.
        Protected Overrides Sub OnClick(ByVal e As DesignerRegionMouseEventArgs)
            If IsNothing(e.Region) Then
                Return
            End If

            ' If the clicked region is not a header, return
            If e.Region.Name.IndexOf("Header") <> 0 Then
                Return
            End If

            ' Switch the current view if required
            If e.Region.Name.Substring(6, 1) <> myControl.CurrentView.ToString() Then
                myControl.CurrentView = Integer.Parse(e.Region.Name.Substring(6, 1))
                MyBase.UpdateDesignTimeHtml()
            End If
        End Sub