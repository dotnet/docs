
public static void BinHexEncodeImageFile() {

  int bufferSize = 1000;
  byte[] buffer = new byte[bufferSize];
  int readBytes = 0;
	
  using (XmlWriter writer = XmlWriter.Create("output.xml")) {
       FileStream inputFile = new FileStream(@"C:\artFiles\sunset.jpg", FileMode.OpenOrCreate, 
                                                                    FileAccess.Read, FileShare.Read);
       writer.WriteStartDocument();
       writer.WriteStartElement("image");
       BinaryReader br = new BinaryReader(inputFile);
       Console.WriteLine("\r\nWriting BinHex data...");

       do {
          readBytes = br.Read(buffer, 0, bufferSize);
          writer.WriteBinHex(buffer, 0, readBytes);
       } while (bufferSize <= readBytes);
       br.Close();

    writer.WriteEndElement();// </image>
    writer.WriteEndDocument();
		
  }
}