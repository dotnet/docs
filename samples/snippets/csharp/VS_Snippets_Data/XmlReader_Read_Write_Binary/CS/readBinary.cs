using System;
using System.Text;
using System.IO;
using System.Xml;

class Read_Write_BinaryMethods {

   static void Main() {

	BinHexEncodeImageFile();
              BinHexDecodeImageFile();

              Base64EncodeImageFile();
              Base64DecodeImageFile();

   }
//<snippet1>

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
//</snippet1>

//<snippet2>
public static void BinHexDecodeImageFile() {

  byte[] buffer = new byte[1000];
  int readBytes = 0;

  using (XmlReader reader = XmlReader.Create("output.xml")) {
					   
        FileStream outputFile = new FileStream(@"C:\artFiles\data\newImage.jpg", FileMode.OpenOrCreate, 
                                                                      FileAccess.Write, FileShare.Write);
        // Read to the image element.
        reader.ReadToFollowing("image");
        // Read the BinHex data.
        Console.WriteLine("\r\nReading BinHex...");
        BinaryWriter bw = new BinaryWriter(outputFile);
        while ((readBytes = reader.ReadElementContentAsBinHex(buffer, 0, 50))>0) {
            bw.Write(buffer, 0, readBytes);
        }
        outputFile.Close();
		
  }
}
//</snippet2>

//<snippet3>

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
//</snippet3>

//<snippet4>

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
//</snippet4>

} // end class.