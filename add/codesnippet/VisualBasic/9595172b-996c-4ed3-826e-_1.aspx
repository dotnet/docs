<script runat="server">
Private Sub UpdateRecords(source As Object, e As EventArgs)

  Dim cb As CheckBox
  Dim row As GridViewRow

  For Each row In GridView1.Rows

    cb = CType(row.Cells(0).Controls(1), CheckBox)
    If cb.Checked Then

      Dim oid As String
      oid = CType(row.Cells(1).Text, String)

      MyAccessDataSource.UpdateParameters.Add("date", TypeCode.DateTime, DateTime.Now.ToString())

      MyAccessDataSource.UpdateParameters.Add("orderid", oid)

      MyAccessDataSource.Update()
      MyAccessDataSource.UpdateParameters.Clear()
    End If
  Next
End Sub ' UpdateRecords
</script>