        ' Set the VisualStyleRenderer to a new element.
        Private Function SetRenderer(ByVal element As _
            VisualStyleElement) As Boolean

            If Not VisualStyleRenderer.IsElementDefined(element) Then
                Return False
            End If

            If renderer Is Nothing Then
                renderer = New VisualStyleRenderer(element)
            Else
                renderer.SetParameters(element)
            End If

            Return True
        End Function