        ' The AnchorGlyph objects should mimic the resize glyphs;
        ' they should only be visible when the control is the 
        ' primary selection. The adorner is enabled when the 
        ' control is the primary selection and disabled when 
        ' it is not.
        Private Sub selectionService_SelectionChanged( _
        ByVal sender As Object, _
        ByVal e As EventArgs)

            If Object.ReferenceEquals( _
            Me.selectionService.PrimarySelection, _
            Me.relatedControl) Then
                Me.ComputeBounds()
                Me.anchorAdorner.Enabled = True
            Else
                Me.anchorAdorner.Enabled = False
            End If

        End Sub