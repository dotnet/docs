    ' This method handles the "Launch Url Builder UI" menu command.
    ' Invokes the BuildUrl method of the System.Web.UI.Design.UrlBuilder.
    Private Sub launchUrlBuilder(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a parent control.
        Dim c As New System.Windows.Forms.Control()
        c.CreateControl()

        ' Launch the Url Builder using the specified control
        ' parent, initial URL, empty relative base URL path,
        ' window caption, filter string and URLBuilderOptions value.
        UrlBuilder.BuildUrl( _
            Me.Component, _
            c, _
            "http://www.example.com", _
            "Select a URL", _
            "", _
            UrlBuilderOptions.None)
    End Sub