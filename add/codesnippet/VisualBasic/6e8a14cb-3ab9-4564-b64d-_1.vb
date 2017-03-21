        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            If (Control.ID.StartsWith("Contoso")) Then
                If (Not Control.Enabled) Then
                    Return
                End If
            End If

            MyBase.Render(writer)
        End Sub