        ' Override the Render method to ensure that this control
        ' is nested in an HtmlForm server control, between a <form runat=server>
        ' opening tag and a </form> closing tag.
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

            ' Ensure that the control is nested in a server form.
            If Not (Page Is Nothing) Then
                Page.VerifyRenderingInServerForm(Me)
            End If

            MyBase.Render(writer)

        End Sub
