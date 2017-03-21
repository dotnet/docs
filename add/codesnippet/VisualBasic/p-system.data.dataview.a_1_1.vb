Private Sub CheckAllowDelete(rowToDelete As DataRow)
    Dim view As DataView = New DataView(DataSet1.Tables("Suppliers"))
    If view.AllowDelete Then
    rowToDelete.Delete()
    End If
End Sub