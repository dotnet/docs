'<snippet1>
Imports System.IO
Imports System.Xml
Imports System.Text

Public Module TestBase64

    Private Const bufferSize As Integer = 4096

    Public Sub Main()

        Dim args As String() = System.Environment.GetCommandLineArgs()
        
        ' Check that the usage string is correct.
        If args.Length < 3
            TestBase64.Usage()
            Return
        End If

        Dim fileOld As New FileStream(args(1), FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
        TestBase64.EncodeXmlFile("temp.xml", fileOld)

        Dim fileNew As New FileStream(args(2), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)

        TestBase64.DecodeOrignalObject("temp.xml", fileNew)

        ' Compare the two files.
        If TestBase64.CompareResult(fileOld, fileNew)
            Console.WriteLine($"The recreated binary file {args(2)} is the same as {args(1)}")
        Else
            Console.WriteLine($"The recreated binary file {args(2)} is not the same as {args(1)}")
        End If

        fileOld.Flush()
        fileNew.Flush()
        fileOld.Close()
        fileNew.Close()

    End Sub

    ' Use the WriteBase64 method to create an XML document.  The object  
    ' passed by the user is encoded and included in the document.
    Public Sub EncodeXmlFile(xmlFileName As String, fileOld As FileStream)

        Dim buffer(bufferSize - 1) As Byte
        Dim readByte As Integer = 0

        Dim xw As New XmlTextWriter(xmlFileName, Encoding.UTF8)
        xw.WriteStartDocument()
        xw.WriteStartElement("root")
        ' Create a Char writer.
        Dim br As New BinaryReader(fileOld)
        ' Set the file pointer to the end.

        Try
            Do
                readByte = br.Read(buffer, 0, bufferSize)
                xw.WriteBase64(buffer, 0, readByte)
            Loop While (bufferSize <= readByte)

        Catch ex As Exception
            Dim ex1 As New EndOfStreamException()

            If (ex1.Equals(ex))
                Console.WriteLine("We are at end of file")
            Else
                Console.WriteLine(ex)
            End If
        End Try
        xw.WriteEndElement()
        xw.WriteEndDocument()

        xw.Flush()
        xw.Close()
    End Sub

    ' Use the ReadBase64 method to decode the new XML document 
    ' and generate the original object.
    Public Sub DecodeOrignalObject(xmlFileName As String, fileNew As FileStream)

        Dim buffer(bufferSize - 1) As Byte
        Dim readByte As Integer = 0

        ' Create a file to write the bmp back.
        Dim bw As New BinaryWriter(fileNew)

        Dim tr As New XmlTextReader(xmlFileName)
        tr.MoveToContent()
        Console.WriteLine(tr.Name)

        Do
            readByte = tr.ReadBase64(buffer, 0, bufferSize)
            bw.Write(buffer, 0, readByte)
        Loop While (readByte >= bufferSize)

        bw.Flush()

    End Sub

    ' Compare the two files.
    Public Function CompareResult(fileOld As FileStream, fileNew As FileStream) As Boolean

        Dim readByteOld As Integer = 0
        Dim readByteNew As Integer = 0
        Dim count As Integer
        Dim readByte as integer = 0

        Dim bufferOld(bufferSize - 1) As Byte
        Dim bufferNew(bufferSize - 1) As Byte

        Dim binaryReaderOld As New BinaryReader(fileOld)
        Dim binaryReaderNew As New BinaryReader(fileNew)

        binaryReaderOld.BaseStream.Seek(0, SeekOrigin.Begin)
        binaryReaderNew.BaseStream.Seek(0, SeekOrigin.Begin)

        Do
            readByteOld = binaryReaderOld.Read(bufferOld, 0, bufferSize)
            readByteNew = binaryReaderNew.Read(bufferNew, 0, bufferSize)

            If readByteOld <> readByteNew
                Return False
            End If

            For count = 0 To bufferSize - 1
                If bufferOld(count) <> bufferNew(count)
                    Return False
                End If
            Next

        Loop While (count < readByte)
        Return True
    End Function

    ' Display the usage statement.
    Public Sub Usage()
        Console.WriteLine("TestBase64 sourceFile, targetFile")
        Console.WriteLine("For example: TestBase64 winlogon.bmp, target.bmp")
    End Sub

End Module
'</snippet1>
