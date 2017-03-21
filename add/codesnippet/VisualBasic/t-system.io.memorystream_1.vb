Imports System
Imports System.IO
Imports System.Text

Module MemStream

    Sub Main()
    
        Dim count As Integer
        Dim byteArray As Byte()
        Dim charArray As Char()
        Dim uniEncoding As New UnicodeEncoding()

        ' Create the data to write to the stream.
        Dim firstString As Byte() = _
            uniEncoding.GetBytes("Invalid file path characters are: ")
        Dim secondString As Byte() = _
            uniEncoding.GetBytes(Path.GetInvalidPathChars())

        Dim memStream As New MemoryStream(100)
        Try
            ' Write the first string to the stream.
            memStream.Write(firstString, 0 , firstString.Length)

            ' Write the second string to the stream, byte by byte.
            count = 0
            While(count < secondString.Length)
                memStream.WriteByte(secondString(count))
                count += 1
            End While
            
            ' Write the stream properties to the console.
            Console.WriteLine( _
                "Capacity = {0}, Length = {1}, Position = {2}", _
                memStream.Capacity.ToString(), _
                memStream.Length.ToString(), _
                memStream.Position.ToString())

            ' Set the stream position to the beginning of the stream.
            memStream.Seek(0, SeekOrigin.Begin)

            ' Read the first 20 bytes from the stream.
            byteArray = _
                New Byte(CType(memStream.Length, Integer)){}
            count = memStream.Read(byteArray, 0, 20)

            ' Read the remaining Bytes, Byte by Byte.
            While(count < memStream.Length)
                byteArray(count) = _
                    Convert.ToByte(memStream.ReadByte())
                count += 1
            End While

            ' Decode the Byte array into a Char array 
            ' and write it to the console.
            charArray = _
                New Char(uniEncoding.GetCharCount( _
                byteArray, 0, count)){}
            uniEncoding.GetDecoder().GetChars( _
                byteArray, 0, count, charArray, 0)
            Console.WriteLine(charArray)
        Finally
            memStream.Close()
        End Try

    End Sub
End Module