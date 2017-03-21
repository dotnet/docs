System.IO.BinaryReader reader = new System.IO.BinaryReader(
  System.IO.File.Open(Server.MapPath("session_collection.bin"), System.IO.FileMode.Open));

SessionStateItemCollection sessionItems = SessionStateItemCollection.Deserialize(reader);

for (int i = 0; i < sessionItems.Count; i++)
  Response.Write("sessionItems[" + i + "] = " + sessionItems[i].ToString() + "<br />");