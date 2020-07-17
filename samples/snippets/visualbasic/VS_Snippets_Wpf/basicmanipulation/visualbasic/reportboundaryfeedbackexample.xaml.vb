Public Class ReportBoundaryFeedBackExample

    Dim initialPosition As MatrixTransform

    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If initialPosition Is Nothing Then
            MessageBox.Show("transform not found")
            Exit Sub
        End If

        manRect.RenderTransform = initialPosition
    End Sub

    '<SnippetManipulationPivot>
    Private Sub Window_ManipulationStarting(ByVal sender As Object, ByVal e As ManipulationStartingEventArgs)
        ' Set the ManipulationPivot so that the element rotates as it is
        ' moved with one finger.
        Dim element As FrameworkElement = TryCast(e.OriginalSource, FrameworkElement)
        Dim pivot As New ManipulationPivot()
        pivot.Center = New Point(element.ActualWidth / 2, element.ActualHeight / 2)
        pivot.Radius = 20
        e.Pivot = pivot

        e.ManipulationContainer = Me
        e.Handled = True
    End Sub
    '</SnippetManipulationPivot>

    '<SnippetReportBoundaryFeedback>
    Private Sub Window_ManipulationDelta(ByVal sender As Object, ByVal e As ManipulationDeltaEventArgs)

        Dim rectToMove As Rectangle = TryCast(e.OriginalSource, Rectangle)
        Dim overshoot As Vector

        ' When the element crosses the boundary of the window, check whether 
        ' the manipulation is in inertia. If it is, complete the manipulation.
        ' Otherwise, report the boundary feedback.
        If CalculateOvershoot(rectToMove, e.ManipulationContainer, overshoot) Then
            If e.IsInertial Then
                e.Complete()
                e.Handled = True
                Exit Sub
            Else
                'Report that the element hit the boundary

                e.ReportBoundaryFeedback(New ManipulationDelta(overshoot, 0, New Vector(), New Vector()))
            End If
        End If

        ' Move the element as usual.

        ' Get the Rectangle and its RenderTransform matrix.
        Dim rectsMatrix As Matrix = DirectCast(rectToMove.RenderTransform, MatrixTransform).Matrix

        ' Rotate the Rectangle.
        rectsMatrix.RotateAt(e.DeltaManipulation.Rotation, e.ManipulationOrigin.X, e.ManipulationOrigin.Y)

        ' Resize the Rectangle. Keep it square 
        ' so use only the X value of Scale.
        rectsMatrix.ScaleAt(e.DeltaManipulation.Scale.X, e.DeltaManipulation.Scale.X, e.ManipulationOrigin.X, e.ManipulationOrigin.Y)

        ' Move the Rectangle.
        rectsMatrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y)

        ' Apply the changes to the Rectangle.
        rectToMove.RenderTransform = New MatrixTransform(rectsMatrix)

        e.Handled = True
    End Sub

    Private Function CalculateOvershoot(ByVal element As UIElement, ByVal container As IInputElement, ByRef overshoot As Vector) As Boolean
        ' Get axis aligned element bounds
        Dim elementBounds = element.RenderTransform.TransformBounds(VisualTreeHelper.GetDrawing(element).Bounds)

        'double extraX = 0.0, extraY = 0.0;
        overshoot = New Vector()

        Dim parent As FrameworkElement = TryCast(container, FrameworkElement)
        If parent Is Nothing Then
            Return False
        End If

        ' Calculate overshoot. 
        If elementBounds.Left < 0 Then
            overshoot.X = elementBounds.Left
        ElseIf elementBounds.Right > parent.ActualWidth Then
            overshoot.X = elementBounds.Right - parent.ActualWidth
        End If

        If elementBounds.Top < 0 Then
            overshoot.Y = elementBounds.Top
        ElseIf elementBounds.Bottom > parent.ActualHeight Then
            overshoot.Y = elementBounds.Bottom - parent.ActualHeight
        End If

        ' Return false if Overshoot is empty; otherwsie, return true.
        Return Not Vector.Equals(overshoot, New Vector())
    End Function
    '</SnippetReportBoundaryFeedback>

    Private Sub Window_InertiaStarting(ByVal sender As Object, ByVal e As ManipulationInertiaStartingEventArgs)

        ' Decrease the velocity of the Rectangle's movement by 
        ' 10 inches per second every second.
        ' (10 inches * 96 pixels per inch / 1000ms^2)
        e.TranslationBehavior.DesiredDeceleration = 10.0R * 96.0R / (1000.0R * 1000.0R)

        ' Decrease the velocity of the Rectangle's resizing by 
        ' 0.1 inches per second every second.
        ' (0.1 inches * 96 pixels per inch / (1000ms^2)
        e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / 1000.0R * 1000.0R

        ' Decrease the velocity of the Rectangle's rotation rate by 
        ' 2 rotations per second every second.
        ' (2 * 360 degrees / (1000ms^2)
        e.RotationBehavior.DesiredDeceleration = 720 / (1000.0R * 1000.0R)

        e.Handled = True
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        initialPosition = TryCast(TryFindResource("InitialMatrixTransform"), MatrixTransform)


    End Sub
End Class
