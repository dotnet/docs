//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Text;

class TestBase64 {

    private const int bufferSize=4096;

    public static void Main(String[] args) {

        TestBase64 testBase64=new TestBase64();

        //Check that the usage string is correct.
        if (args.Length < 2 ) {
            testBase64.Usage();
            return;
        }

        FileStream fileOld = new FileStream(args[0], FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
        testBase64.EncodeXmlFile("temp.xml", fileOld);

        FileStream fileNew = new FileStream(args[1], FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

        testBase64.DecodeOrignalObject("temp.xml", fileNew);

        //Compare the two files.
        if (testBase64.CompareResult( fileOld, fileNew)) {
            Console.WriteLine("The recreated binary file {0} is the same as {1}", args[1], args[0] );
        } else {
            Console.WriteLine("The recreated binary file {0} is not the same as {1}", args[1], args[0] );
        }

        fileOld.Flush();
        fileNew.Flush();
        fileOld.Close();
        fileNew.Close();

    }

    //Use the WriteBase64 method to create an XML document.  The object  
    //passed by the user is encoded and included in the document.
    public void EncodeXmlFile(String xmlFileName, FileStream fileOld) {

        byte[] buffer = new byte[bufferSize];
        int readByte=0;

        XmlTextWriter xw = new XmlTextWriter(xmlFileName, Encoding.UTF8);
        xw.WriteStartDocument();
        xw.WriteStartElement("root");
        // Create a Char writer.
        BinaryReader br = new BinaryReader(fileOld);
        // Set the file pointer to the end.

        try {
              do {
                  readByte=br.Read(buffer, 0, bufferSize);
                  xw.WriteBase64(buffer, 0, readByte);
              } while (bufferSize <= readByte );

        } catch (Exception ex) {
            EndOfStreamException ex1= new EndOfStreamException();

            if (ex1.Equals(ex)) {
                Console.WriteLine("We are at end of file");
            } else {
                Console.WriteLine(ex);
            }
        }
        xw.WriteEndElement();
        xw.WriteEndDocument();

        xw.Flush();
        xw.Close();
    }

    //Use the ReadBase64 method to decode the new XML document 
    //and generate the original object.
    public void DecodeOrignalObject(String xmlFileName, FileStream fileNew) {

        byte[] buffer = new byte[bufferSize];
        int readByte=0;

        //Create a file to write the bmp back.
        BinaryWriter bw = new BinaryWriter(fileNew);

        XmlTextReader tr = new XmlTextReader(xmlFileName);
        tr.MoveToContent();
        Console.WriteLine(tr.Name);

        do {
          readByte=tr.ReadBase64(buffer, 0, bufferSize);
          bw.Write(buffer, 0, readByte);
        } while(readByte>=bufferSize);

        bw.Flush();

    }

    //Compare the two files.
    public bool CompareResult(FileStream fileOld, FileStream fileNew) {

        int readByteOld=0;
        int readByteNew=0;
        int count, readByte=0;

        byte[] bufferOld = new byte[bufferSize];
        byte[] bufferNew = new byte[bufferSize];


        BinaryReader binaryReaderOld = new BinaryReader(fileOld);
        BinaryReader binaryReaderNew = new BinaryReader(fileNew);

        binaryReaderOld.BaseStream.Seek(0, SeekOrigin.Begin);
        binaryReaderNew.BaseStream.Seek(0, SeekOrigin.Begin);


        do {
          readByteOld=binaryReaderOld.Read(bufferOld, 0, bufferSize);
          readByteNew=binaryReaderNew.Read(bufferNew, 0, bufferSize);

          if (readByteOld!=readByteNew) {
              return false;
          }

          for (count=0; count <bufferSize; ++count) {
              if (bufferOld[count]!=bufferNew[count]) {
                  return false;
              }
          }

        } while (count<readByte );

        return true;

    }

    //Display the usage statement.
    public void Usage() {
        Console.WriteLine("TestBase64 sourceFile, targetFile \n");
        Console.WriteLine("For example: TestBase64 winlogon.bmp, target.bmp\n");
    }

}
//</snippet1>
