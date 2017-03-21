Dim reader As System.IO.BinaryReader = New System.IO.BinaryReader( _
  System.IO.File.Open(Server.MapPath("session_collection.bin"), System.IO.FileMode.Open))

Dim sessionItems As SessionStateItemCollection = SessionStateItemCollection.Deserialize(reader)

For I As Integer = 0 To sessionItems.Count - 1
  Response.Write("sessionItems(" & i & ") = " & sessionItems(i).ToString() & "<br />")
Next