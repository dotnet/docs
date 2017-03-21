        ' Calculate and set the clipping region for the control  
        ' so that the corners of the title bar are rounded.
        Private Sub SetClipRegion()
            If Not Application.RenderWithVisualStyles Then
                Return
            End If

            Using g As Graphics = Me.CreateGraphics()
                ' Get the current region for the window caption.
                If SetRenderer(windowElements("windowCaption")) Then
                    Dim clipRegion As Region = _
                        renderer.GetBackgroundRegion(g, _
                        elementRectangles("windowCaption"))

                    ' Get the client rectangle, but exclude the   
                    ' region of the window caption.
                    Dim height As Integer = _
                        CInt(clipRegion.GetBounds(g).Height)
                    Dim nonCaptionRect As _
                        New Rectangle(ClientRectangle.X, _
                        ClientRectangle.Y + height, _
                        ClientRectangle.Width, _
                        ClientRectangle.Height - height)

                    ' Add the rectangle to the caption region, and  
                    ' make this region the form's clipping region.
                    clipRegion.Union(nonCaptionRect)
                    Me.Region = clipRegion
                End If
            End Using
        End Sub