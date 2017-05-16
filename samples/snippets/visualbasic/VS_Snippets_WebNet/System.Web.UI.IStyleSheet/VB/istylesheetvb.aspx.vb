
Partial Class istylesheetvb
    Inherits System.Web.UI.Page
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        If Not Page.Header Is Nothing Then

            ' Create a Style object to hold style rules to apply to a Label control.
            Dim labelStyle As Style = New Style()

            labelStyle.ForeColor = System.Drawing.Color.DarkRed
            labelStyle.BorderColor = System.Drawing.Color.DarkBlue
            labelStyle.BorderWidth = 2

            ' Register the Style object so that it can be merged with 
            ' the Style object of the controls that use it.
            Page.Header.StyleSheet.RegisterStyle(labelStyle, Nothing)

            ' Merge the labelCssStyle style with the label1 control's
            ' style settings.
            label1.MergeStyle(labelStyle)
            label1.Text = "This is what the labelCssStyle looks like."

            ' Create a Style object for the <BODY> section of the Web page.
            Dim bodyStyle As Style = New Style()

            bodyStyle.ForeColor = System.Drawing.Color.Blue
            bodyStyle.BackColor = System.Drawing.Color.LightGray

            ' Add the style to the header of the current page.
            Page.Header.StyleSheet.CreateStyleRule(bodyStyle, Nothing, "BODY")

            ' Add text to the label2 control to see the label without 
            ' the labelStyle applied to it.  
            label2.Text = "This is what the bodyStyle looks like."

        End If

    End Sub
End Class
