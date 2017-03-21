Private Sub cmdAdd_Click(objSender As Object, objArgs As EventArgs)
  If txtName.Text <> "" Then
    ' Add this item to the cache.
  Cache(txtName.Text) = txtValue.Text
  End If
End Sub