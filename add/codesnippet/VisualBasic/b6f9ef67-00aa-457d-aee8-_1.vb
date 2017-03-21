        ' Define the text bounds so that the text rectangle 
        ' does not include the radio button.
        Public ReadOnly Property TextRectangle() As Rectangle
            Get
                Using g As Graphics = Me.CreateGraphics()
                    With textRectangleValue
                        .X = Me.ClientRectangle.X + _
                            RadioButtonRenderer.GetGlyphSize(g, _
                            RadioButtonState.UncheckedNormal).Width
                        .Y = Me.ClientRectangle.Y
                        .Width = Me.ClientRectangle.Width - _
                            RadioButtonRenderer.GetGlyphSize(g, _
                            RadioButtonState.UncheckedNormal).Width
                        .Height = Me.ClientRectangle.Height
                    End With
                End Using
                Return textRectangleValue
            End Get
        End Property