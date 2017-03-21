    Private Sub AllFields_Click(ByVal sender As Object, ByVal e As EventArgs)

        ActiveForm = Form5
        Dim spec As String = "{0}: {1}<br/>"
        Dim flds As IObjectListFieldCollection = List1.AllFields
        Dim i As Integer
        For i = 0 To flds.Count - 1
            TextView1.Text += _
                String.Format(spec, (i + 1), flds(i).Title)
        Next
    End Sub