'<SNIPPET1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.AccessControl



Module FileStreamExample

    Sub Main()
        Try
            ' Create a file and write data to it.
            ' Create an array of bytes.
            Dim messageByte As Byte() = Encoding.ASCII.GetBytes("Here is some data.")

            ' Specify an access control list (ACL)
            Dim fs As New FileSecurity()

            fs.AddAccessRule(New FileSystemAccessRule("DOMAINNAME\AccountName", FileSystemRights.ReadData, AccessControlType.Allow))

            ' Create a file using the FileStream class.
            Dim fWrite As New FileStream("test.txt", FileMode.Create, FileSystemRights.Modify, FileShare.None, 8, FileOptions.None, fs)

            ' Write the number of bytes to the file.
            fWrite.WriteByte(System.Convert.ToByte(messageByte.Length))

            ' Write the bytes to the file.
            fWrite.Write(messageByte, 0, messageByte.Length)

            ' Close the stream.
            fWrite.Close()


            ' Open a file and read the number of bytes.
            Dim fRead As New FileStream("test.txt", FileMode.Open)

            ' The first byte is the string length.
            Dim length As Integer = Fix(fRead.ReadByte())

            ' Create a new byte array for the data.
            Dim readBytes(length) As Byte

            ' Read the data from the file.
            fRead.Read(readBytes, 0, readBytes.Length)

            ' Close the stream.
            fRead.Close()

            ' Display the data.
            Console.WriteLine(Encoding.ASCII.GetString(readBytes))

            Console.WriteLine("Done writing and reading data.")
        Catch e As Exception
            Console.WriteLine(e)
        End Try

        Console.ReadLine()

    End Sub
End Module

'</SNIPPET1>