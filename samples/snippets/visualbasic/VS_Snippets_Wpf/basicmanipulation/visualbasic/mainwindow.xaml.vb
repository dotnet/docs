Class MainWindow 

    '<SnippetManipulationStarting>
    Private Sub Window_ManipulationStarting(ByVal sender As Object, ByVal e As ManipulationStartingEventArgs)
        e.ManipulationContainer = Me
        e.Handled = True
    End Sub
    '</SnippetManipulationStarting>


    '<SnippetManipulationDelta> 
    Private Sub Window_ManipulationDelta(ByVal sender As Object, ByVal e As ManipulationDeltaEventArgs)

        ' Get the Rectangle and its RenderTransform matrix.
        Dim rectToMove As Rectangle = e.OriginalSource
        Dim rectTransform As MatrixTransform = rectToMove.RenderTransform
        Dim rectsMatrix As Matrix = rectTransform.Matrix


        ' Rotate the shape
        rectsMatrix.RotateAt(e.DeltaManipulation.Rotation,
                             e.ManipulationOrigin.X,
                             e.ManipulationOrigin.Y)

        ' Resize the Rectangle. Keep it square 
        ' so use only the X value of Scale.
        rectsMatrix.ScaleAt(e.DeltaManipulation.Scale.X,
                            e.DeltaManipulation.Scale.X,
                            e.ManipulationOrigin.X,
                            e.ManipulationOrigin.Y)

        'move the center
        rectsMatrix.Translate(e.DeltaManipulation.Translation.X,
                              e.DeltaManipulation.Translation.Y)

        ' Apply the changes to the Rectangle.
        rectTransform = New MatrixTransform(rectsMatrix)
        rectToMove.RenderTransform = rectTransform

        Dim container As FrameworkElement = e.ManipulationContainer
        Dim containingRect As New Rect(container.RenderSize)

        Dim shapeBounds As Rect = rectTransform.TransformBounds(
                                    New Rect(rectToMove.RenderSize))

        ' Check if the rectangle is completely in the window.
        ' If it is not and intertia is occuring, stop the manipulation.
        If e.IsInertial AndAlso Not containingRect.Contains(shapeBounds) Then
            e.Complete()
        End If

        e.Handled = True
    End Sub
    '</SnippetManipulationDelta> 

    '<SnippetManipulationInertiaStarting>
    Private Sub Window_InertiaStarting(ByVal sender As Object,
                                       ByVal e As ManipulationInertiaStartingEventArgs)

        ' Decrease the velocity of the Rectangle's movement by 
        ' 10 inches per second every second.
        ' (10 inches * 96 pixels per inch / 1000ms^2)
        e.TranslationBehavior.DesiredDeceleration = 10.0 * 96.0 / (1000.0 * 1000.0)

        ' Decrease the velocity of the Rectangle's resizing by 
        ' 0.1 inches per second every second.
        ' (0.1 inches * 96 pixels per inch / (1000ms^2)
        e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / (1000.0 * 1000.0)

        ' Decrease the velocity of the Rectangle's rotation rate by 
        ' 2 rotations per second every second.
        ' (2 * 360 degrees / (1000ms^2)
        e.RotationBehavior.DesiredDeceleration = 720 / (1000.0 * 1000.0)

        e.Handled = True
    End Sub
    '</SnippetManipulationInertiaStarting>
End Class
