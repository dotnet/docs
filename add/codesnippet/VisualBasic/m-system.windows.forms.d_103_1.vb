        Private Sub changeService_ComponentChanged( _
        ByVal sender As Object, _
        ByVal e As ComponentChangedEventArgs)

            If Object.ReferenceEquals( _
            e.Component, _
            Me.relatedControl) Then
                If e.Member.Name = "Margin" OrElse _
                   e.Member.Name = "Padding" Then
                    Me.marginAndPaddingAdorner.Invalidate()
                End If
            End If

        End Sub