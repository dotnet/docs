        ' Calculate the text bounds, exluding the check box.
        Public ReadOnly Property TextRectangle() As Rectangle
            Get
                Using g As Graphics = Me.CreateGraphics()
                    With textRectangleValue
                        .X = Me.ClientRectangle.X + _
                            CheckBoxRenderer.GetGlyphSize(g, _
                            CheckBoxState.UncheckedNormal).Width
                        .Y = Me.ClientRectangle.Y
                        .Width = Me.ClientRectangle.Width - _
                            CheckBoxRenderer.GetGlyphSize(g, _
                            CheckBoxState.UncheckedNormal).Width
                        .Height = Me.ClientRectangle.Height
                    End With
                End Using
                Return textRectangleValue
            End Get
        End Property