
Imports System
Imports System.IO




Module Program

    Sub Main(ByVal args() As String)

    End Sub 'Main





    '<SNIPPET1>
    Function OpenDataFile(ByVal FileName As String) As Byte()
        ' Check the FileName argument.
        If FileName Is Nothing OrElse FileName.Length = 0 Then
            Throw New ArgumentNullException("FileName")
        End If

        ' Check to see if the file exists.
        Dim fInfo As New FileInfo(FileName)

        ' You can throw a personalized exception if 
        ' the file does not exist.
        If Not fInfo.Exists Then
            Throw New FileNotFoundException("The file was not found.", FileName)
        End If

        ' Open the file.
        Dim fStream As New FileStream(FileName, FileMode.Open)

        ' Create a buffer.
        Dim buffer(fStream.Length) As Byte

        ' Read the file contents to the buffer.
        fStream.Read(buffer, 0, Fix(fStream.Length))

        ' return the buffer.
        Return buffer

    End Function
    '</SNIPPET1>
End Module
