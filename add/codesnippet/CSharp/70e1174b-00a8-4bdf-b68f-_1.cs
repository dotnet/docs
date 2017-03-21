
public static void Base64DecodeImageFile() {

  byte[] buffer = new byte[1000];
  int readBytes = 0;

  using (XmlReader reader = XmlReader.Create("output.xml")) {
					   
        FileStream outputFile = new FileStream(@"C:\artFiles\data\newImage.jpg",
					FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
        // Read to the image element.
        reader.ReadToFollowing("image");
        // Read the Base64 data.
        Console.WriteLine("\r\nReading Base64...");
        BinaryWriter bw = new BinaryWriter(outputFile);
        while ((readBytes = reader.ReadElementContentAsBase64(buffer, 0, 50))>0) {
            bw.Write(buffer, 0, readBytes);
        }
        outputFile.Close();
  }
}