Dim items As SessionStateItemCollection = New SessionStateItemCollection()

items("LastName") = "Wilson"
items("FirstName") = "Dan"

Dim writer As System.IO.BinaryWriter = New System.IO.BinaryWriter( _
  System.IO.File.Open(Server.MapPath("session_collection.bin"), System.IO.FileMode.Create))

items.Serialize(writer)

writer.Close()