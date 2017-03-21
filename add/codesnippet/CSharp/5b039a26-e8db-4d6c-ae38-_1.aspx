SessionStateItemCollection items = new SessionStateItemCollection();

items["LastName"] = "Wilson";
items["FirstName"] = "Dan";

System.IO.BinaryWriter writer = new System.IO.BinaryWriter(
  System.IO.File.Open(Server.MapPath("session_collection.bin"), System.IO.FileMode.Create));

items.Serialize(writer);

writer.Close();