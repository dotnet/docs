    Private Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)
        
        ' Set the pager text properties
        If Not IsPostBack Then
            Form1.PagerStyle.NextPageText = "Go Next >"
        Else
            ' For postback, set different text
            Form1.PagerStyle.NextPageText = "Go More >"
            Form1.PagerStyle.PreviousPageText = "< Go Prev"
        End If
    End Sub