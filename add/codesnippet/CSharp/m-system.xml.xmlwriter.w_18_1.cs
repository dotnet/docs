
public static void Base64EncodeImageFile() {

  int bufferSize = 1000;
  byte[] buffer = new byte[bufferSize];
  int readBytes = 0;
	
  using (XmlWriter writer = XmlWriter.Create("output.xml")) {

       FileStream inputFile = new FileStream(@"C:\artFiles\sunset.jpg",
                                                                    FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
       writer.WriteStartDocument();
       writer.WriteStartElement("image");
       BinaryReader br = new BinaryReader(inputFile);
       Console.WriteLine("\r\nWriting Base64 data...");

       do {
          readBytes = br.Read(buffer, 0, bufferSize);
          writer.WriteBase64(buffer, 0, readBytes);
       } while (bufferSize <= readBytes);
       br.Close();
		
    writer.WriteEndElement();// </image>
    writer.WriteEndDocument();
		
  }
}