'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Text

class TestBase64 

    private const bufferSize as integer = 4096

    public shared sub Main() 
 
        Dim args() As String = System.Environment.GetCommandLineArgs()
        Dim myTestBase64 as TestBase64 = new TestBase64()
        
        'Check that the usage string is correct.
        if (args.Length < 3 ) 
           myTestBase64.Usage()
           return
        end if

        Dim fileOld as FileStream = new FileStream(args(1), FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
        myTestBase64.EncodeXmlFile("temp.xml", fileOld)

        Dim fileNew as FileStream = new FileStream(args(2), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)

        myTestBase64.DecodeOrignalObject("temp.xml", fileNew)

        'Compare the two files.
        if (myTestBase64.CompareResult(fileOld, fileNew))
            Console.WriteLine("The recreated binary file {0} is the same as {1}", args(2), args(1))
        else 
            Console.WriteLine("The recreated binary file {0} is not the same as {1}", args(2), args(1))
        end if

        fileOld.Flush()
        fileNew.Flush()
        fileOld.Close()
        fileNew.Close()

    end sub

    'Use the WriteBase64 method to create an XML document.  The object  
    'passed by the user is encoded and included in the document.
    public shared sub EncodeXmlFile(xmlFileName as String, fileOld as FileStream) 

        Dim buffer(bufferSize) as byte
        Dim readByte as integer=0

        Dim xw as XmlTextWriter = new XmlTextWriter(xmlFileName, Encoding.UTF8)
        xw.WriteStartDocument()
        xw.WriteStartElement("root")
        ' Create a Char writer.
        Dim br as BinaryReader = new BinaryReader(fileOld)
        ' Set the file pointer to the end.

        try 
              do 
                  readByte=br.Read(buffer, 0, bufferSize)
                  xw.WriteBase64(buffer, 0, readByte)
              loop while (bufferSize <= readByte )

        catch ex as Exception
            Dim ex1 as EndOfStreamException = new EndOfStreamException()

            if (ex1.Equals(ex)) 
                Console.WriteLine("We are at end of file")
            else 
                Console.WriteLine(ex)
            end if
        end try
        xw.WriteEndElement()
        xw.WriteEndDocument()

        xw.Flush()
        xw.Close()
    end sub

    'Use the ReadBase64 method to decode the new XML document 
    'and generate the original object.
    public shared sub DecodeOrignalObject(xmlFileName as String, fileNew as FileStream) 

        Dim buffer(bufferSize) as byte
        Dim readByte as integer =0

        'Create a file to write the bmp back.
        Dim bw as BinaryWriter = new BinaryWriter(fileNew)

        Dim tr as XmlTextReader = new XmlTextReader(xmlFileName)
        tr.MoveToContent()
        Console.WriteLine(tr.Name)

        do 
          readByte=tr.ReadBase64(buffer, 0, bufferSize)
          bw.Write(buffer, 0, readByte)
        loop while(readByte>=bufferSize)

        bw.Flush()

    end sub

    'Compare the two files.
    public function CompareResult(fileOld as FileStream, fileNew as FileStream) as boolean

        Dim readByteOld as integer=0
        Dim readByteNew as integer=0
        Dim count as integer
        Dim readByte as integer=0

        Dim bufferOld(bufferSize) as byte
        Dim bufferNew(bufferSize) as byte

        Dim binaryReaderOld as BinaryReader = new BinaryReader(fileOld)
        Dim binaryReaderNew as BinaryReader = new BinaryReader(fileNew)

        binaryReaderOld.BaseStream.Seek(0, SeekOrigin.Begin)
        binaryReaderNew.BaseStream.Seek(0, SeekOrigin.Begin)

        do 
          readByteOld=binaryReaderOld.Read(bufferOld, 0, bufferSize)
          readByteNew=binaryReaderNew.Read(bufferNew, 0, bufferSize)

          if not (readByteOld=readByteNew) 
              return false
          end if

          for count=0 to bufferSize-1
              if not (bufferOld(count)=bufferNew(count)) 
                  return false
              end if
          next

        loop while (count<readByte)
        return true
    end function

    'Display the usage statement.
    public shared sub Usage()
        Console.WriteLine("TestBase64 sourceFile, targetFile")
        Console.WriteLine("For example: TestBase64 winlogon.bmp, target.bmp")
    end sub

end class
'</snippet1>
