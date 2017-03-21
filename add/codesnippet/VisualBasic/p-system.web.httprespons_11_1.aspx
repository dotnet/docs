
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Show success or failure of page load.
        If Response.StatusCode <> 200 Then
            Response.Write("There was a problem accessing the web resource." & _
                "<br />" & Response.StatusDescription)
        End If

    End Sub