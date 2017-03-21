            ' When you double-click on an AnchorGlyph, the value of 
            ' the control's Anchor property is toggled.
            '
            ' Note that the value of the Anchor property is not set
            ' by direct assignment. Instead, the 
            ' PropertyDescriptor.SetValue method is used. This 
            ' enables notification of the design environment, so 
            ' related events can be raised, for example, the
            ' IComponentChangeService.ComponentChanged event.
            Public Overrides Function OnMouseDoubleClick( _
            ByVal g As Glyph, _
            ByVal button As MouseButtons, _
            ByVal mouseLoc As Point) As Boolean

                MyBase.OnMouseDoubleClick(g, button, mouseLoc)

                If button = MouseButtons.Left Then
                    Dim ag As AnchorGlyph = g

                    Dim pdAnchor As PropertyDescriptor = _
                    TypeDescriptor.GetProperties(ag.relatedControl)("Anchor")

                    If ag.IsEnabled Then
                        ' The glyph is enabled. 
                        ' Clear the AnchorStyle flag to disable the Glyph.
                        pdAnchor.SetValue(ag.relatedControl, _
                        ag.relatedControl.Anchor Xor ag.anchorStyle)
                    Else
                        ' The glyph is disabled. 
                        ' Set the AnchorStyle flag to enable the Glyph.
                        pdAnchor.SetValue(ag.relatedControl, _
                        ag.relatedControl.Anchor Or ag.anchorStyle)
                    End If
                End If

                Return True

            End Function