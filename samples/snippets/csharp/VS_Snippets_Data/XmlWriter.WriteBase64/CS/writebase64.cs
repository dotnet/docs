//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Text;

public static class TestBase64
{

    private const int bufferSize = 4096;

    public static void Main(string[] args)
    {
        // Check that the usage string is correct.
        if (args.Length < 2)
        {
            TestBase64.Usage();
            return;
        }

        var fileOld = new FileStream(args[0], FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
        TestBase64.EncodeXmlFile("temp.xml", fileOld);

        var fileNew = new FileStream(args[1], FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

        TestBase64.DecodeOrignalObject("temp.xml", fileNew);

        // Compare the two files.
        if (TestBase64.CompareResult(fileOld, fileNew))
        {
            Console.WriteLine($"The recreated binary file {args[1]} is the same as {args[0]}");
        }
        else
        {
            Console.WriteLine($"The recreated binary file {args[1]} is not the same as {args[0]}");
        }

        fileOld.Flush();
        fileNew.Flush();
        fileOld.Close();
        fileNew.Close();
    }

    // Use the WriteBase64 method to create an XML document.  The object  
    // passed by the user is encoded and included in the document.
    public static void EncodeXmlFile(string xmlFileName, FileStream fileOld)
    {

        var buffer = new byte[bufferSize];
        int readByte = 0;

        var xw = new XmlTextWriter(xmlFileName, Encoding.UTF8);
        xw.WriteStartDocument();
        xw.WriteStartElement("root");
        // Create a Char writer.
        var br = new BinaryReader(fileOld);
        // Set the file pointer to the end.

        try
        {
              do
              {
                  readByte = br.Read(buffer, 0, bufferSize);
                  xw.WriteBase64(buffer, 0, readByte);
              } while (bufferSize <= readByte);
        }
        catch (Exception ex)
        {
            var ex1 = new EndOfStreamException();

            if (ex1.Equals(ex))
            {
                Console.WriteLine("We are at end of file");
            }
            else
            {
                Console.WriteLine(ex);
            }
        }
        xw.WriteEndElement();
        xw.WriteEndDocument();

        xw.Flush();
        xw.Close();
    }

    // Use the ReadBase64 method to decode the new XML document 
    // and generate the original object.
    public static void DecodeOrignalObject(string xmlFileName, FileStream fileNew)
    {

        var buffer = new byte[bufferSize];
        int readByte = 0;

        // Create a file to write the bmp back.
        var bw = new BinaryWriter(fileNew);

        var tr = new XmlTextReader(xmlFileName);
        tr.MoveToContent();
        Console.WriteLine(tr.Name);

        do
        {
          readByte=tr.ReadBase64(buffer, 0, bufferSize);
          bw.Write(buffer, 0, readByte);
        } while(readByte >= bufferSize);

        bw.Flush();
    }

    // Compare the two files.
    public static bool CompareResult(FileStream fileOld, FileStream fileNew) {

        int readByteOld = 0;
        int readByteNew = 0;
        int count, readByte =0 ;

        var bufferOld = new byte[bufferSize];
        var bufferNew = new byte[bufferSize];

        var binaryReaderOld = new BinaryReader(fileOld);
        var binaryReaderNew = new BinaryReader(fileNew);

        binaryReaderOld.BaseStream.Seek(0, SeekOrigin.Begin);
        binaryReaderNew.BaseStream.Seek(0, SeekOrigin.Begin);

        do
        {
          readByteOld = binaryReaderOld.Read(bufferOld, 0, bufferSize);
          readByteNew = binaryReaderNew.Read(bufferNew, 0, bufferSize);

          if (readByteOld != readByteNew)
          {
              return false;
          }

          for (count = 0; count < bufferSize; count++)
          {
              if (bufferOld[count] != bufferNew[count])
              {
                  return false;
              }
          }
        } while (count < readByte);

        return true;
    }

    // Display the usage statement.
    public static void Usage()
    {
        Console.WriteLine("TestBase64 sourceFile, targetFile \n");
        Console.WriteLine("For example: TestBase64 winlogon.bmp, target.bmp\n");
    }
}
//</snippet1>
