    Public Sub Page_Load(ByVal source As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Dim txt As String = "Selected Filter is {0}"
            Label1.Text = String.Format(txt, _
                Panel1.DeviceSpecific.SelectedChoice.Filter.ToString())
        End If
    End Sub