    Public Sub Page_Load(ByVal source As Object, ByVal e As EventArgs)
        If Panel1.IsTemplated Then
            Dim txt As String = "Loaded panel has {0} Templates for a Filter named {1}."
            Dim TemplateCount As Integer = _
                Panel1.DeviceSpecific.Choices(0).Templates.Count
            Dim FilterString As String = _
                Panel1.DeviceSpecific.Choices(0).Filter.ToString()
            Label1.Text = _
                String.Format(txt, TemplateCount, FilterString)
        Else
            Label1.Text = "Loaded panel does not have Templates"
        End If
    End Sub