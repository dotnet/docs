<script runat="server">
Private Sub UpdateRecords(source As Object, e As EventArgs)

  ' This method is an example of batch updating using a
  ' data source control. The method iterates through the rows
  ' of the GridView, extracts each CheckBox from the row and, if
  ' the CheckBox is checked, updates data by calling the Update
  ' method of the data source control, adding required parameters
  ' to the UpdateParameters collection.

  Dim cb As CheckBox
  Dim row As GridViewRow

  For Each row In GridView1.Rows

    cb = CType(row.Cells(0).Controls(1), CheckBox)
    If cb.Checked Then

      Dim oid As String
      oid = CType(row.Cells(1).Text, String)

      Dim param1 As New Parameter("date", TypeCode.DateTime, DateTime.Now.ToString())
      MyAccessDataSource.UpdateParameters.Add(param1)

      Dim param2 As New Parameter("orderid", TypeCode.String, oid)
      MyAccessDataSource.UpdateParameters.Add(param2)

      MyAccessDataSource.Update()
      MyAccessDataSource.UpdateParameters.Clear()
    End If
  Next
End Sub ' UpdateRecords
</script>