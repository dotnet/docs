Dim sessionItems As SessionStateItemCollection = New SessionStateItemCollection()

sessionItems("ZipCode") = "98072"
sessionItems("Email") = "someone@example.com"

For i As Integer = 0 To items.Count - 1
  Response.Write("sessionItems(" & i & ") = " & sessionItems(i).ToString() & "<br />")
Next