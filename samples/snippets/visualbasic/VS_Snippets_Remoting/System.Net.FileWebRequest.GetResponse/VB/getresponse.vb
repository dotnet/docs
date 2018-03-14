' <Internal>
' This program contains examples for the following types and methods:
' System.Net.FileWebRequest.GetResponse;
' </Internal>

' <Snippet1>
'
' This example shows how to use the FileWebRequest.GetResponse method 
' to read and display the contents of a file passed by the user.
' Note.  For this program to work, the folder containing the test file
' must be shared, with its permissions set to allow read access. 


Imports System
Imports System.Net
Imports System.IO


Namespace Mssc.PluggableProtocols.File

  Module M_TestGetResponse

    Class TestGetResponse
      Private Shared myFileWebResponse As FileWebResponse


      Private Shared Sub showUsage()
        Console.WriteLine(ControlChars.Lf + "Please enter file name:")
        Console.WriteLine("Usage: cs_getresponse <systemname>/<sharedfoldername>/<filename>")
      End Sub 'showUsage


      Private Shared Function makeFileRequest(ByVal fileName As String) As Boolean
        Dim requestOk As Boolean = False
        Try
          Dim myUrl As New Uri("file://" + fileName)

          ' Create a FileWebRequest object using the passed URI. 
          Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(myUrl), FileWebRequest)

          ' Get the FileWebResponse object.
          myFileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)

          requestOk = True
        Catch e As WebException
          Console.WriteLine(("WebException: " + e.Message))
        Catch e As UriFormatException
          Console.WriteLine(("UriFormatWebException: " + e.Message))
        End Try

        Return requestOk
      End Function 'makeFileRequest


      Private Shared Sub readFile()
        Try
          ' Create the file stream. 
          Dim receiveStream As Stream = myFileWebResponse.GetResponseStream()

          ' Create a reader object to read the file content.
          Dim readStream As New StreamReader(receiveStream)

          ' Create a local buffer for a temporary storage of the 
          ' read data.
          Dim readBuffer() As Char = New [Char](255) {}

          ' Read the first 256 bytes.
          Dim count As Integer = readStream.Read(readBuffer, 0, 256)

          Console.WriteLine("The file content is:")
          Console.WriteLine("")

          'Loop to read the remaining data in blocks of 256 bytes
          'and display the data on the console.
          While count > 0
            Dim str As New [String](readBuffer, 0, count)
            Console.WriteLine((str + ControlChars.Lf))
            count = readStream.Read(readBuffer, 0, 256)
          End While

          readStream.Close()

          ' Release the response object resources.
          myFileWebResponse.Close()

        Catch e As WebException
          Console.WriteLine(("The WebException: " + e.Message))
        Catch e As UriFormatException
          Console.WriteLine(("The UriFormatException: " + e.Message))
        End Try
      End Sub 'readFile

      'Entry point which delegates to C-style main Private Function
      Public Shared Sub Main(ByVal args() As String)

        If args.Length < 1 Then
          showUsage()
        Else
          If makeFileRequest(args(0)) = True Then
            readFile()
          End If
        End If
      End Sub 'Main
    End Class 'TestGetResponse

  End Module

End Namespace

' </Snippet1>
