Dim items As SessionStateItemCollection = New SessionStateItemCollection()

items("LastName") = "Wilson"
items("FirstName") = "Dan"

For Each s As String In items.Keys
  Response.Write("items(""" & s & """) = " & items(s).ToString() & "<br />")
Next