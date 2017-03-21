        ' Get the sizes and offsets for the window parts as specified 
        ' by the visual style.
        Private Sub GetPartDetails()
            ' Do nothing further if visual styles are not enabled.
            If Not Application.RenderWithVisualStyles Then
                Return
            End If

            Using g As Graphics = Me.CreateGraphics()
                ' Get the size and offset of the close button.
                If SetRenderer(windowElements("windowClose")) Then
                    closeButtonSize = _
                        renderer.GetPartSize(g, ThemeSizeType.True)
                    closeButtonOffset = _
                        renderer.GetPoint(PointProperty.Offset)
                End If

                ' Get the height of the window caption.
                If SetRenderer(windowElements("windowCaption")) Then
                    captionHeight = renderer.GetPartSize(g, _
                        ThemeSizeType.True).Height
                End If

                ' Get the thickness of the left, bottom, and right 
                ' window frame.
                If SetRenderer(windowElements("windowLeft")) Then
                    frameThickness = renderer.GetPartSize(g, _
                        ThemeSizeType.True).Width
                End If

                ' Get the size of the resizing gripper.
                If SetRenderer(windowElements("statusGripper")) Then
                    gripperSize = renderer.GetPartSize(g, _
                        ThemeSizeType.True)
                End If
            End Using
        End Sub