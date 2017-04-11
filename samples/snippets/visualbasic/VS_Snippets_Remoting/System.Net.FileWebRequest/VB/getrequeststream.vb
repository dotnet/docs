' <Internal Comment>
' This program contains examples for the following types and methods:
' System.Net.FileWebRequest (Snippet1); System.Net.FileWebRequest.Method (Snippet2); 
' System.Net.FileWebRequest.Timeout (Snippet3); 
' System.Net.FileWebRequest.ContentLength (Snippet4).
' System.Net.FileWebRequest.GetRequestStream (Snippet5);
' </Internal Comment>

' <Snippet1>
'
' This example creates or opens a text file and stores a string in it. 
' Both the file and the string are passed by the user.
' Note. For this program to work, the folder containing the test file
' must be shared, with its permissions set to allow write access. 

Imports System.Net
Imports System
Imports System.IO
Imports System.Text

Namespace Mssc.PluggableProtocols.File

    Module TestGetRequestStream

        Class TestGetRequestStream

            Private Shared myFileWebRequest As FileWebRequest

            ' Show how to use this program.
            Private Shared Sub showUsage()
                Console.WriteLine(ControlChars.Lf + "Please enter file name and timeout :")
                Console.WriteLine("Usage: vb_getrequeststream <systemname>/<sharedfoldername>/<filename> timeout")
                Console.WriteLine("Example: vb_getrequeststream ngetrequestrtream() ndpue/temp/hello.txt  1000")
                Console.WriteLine("Small time-out values (for example, 3 or less) cause a time-out exception.")
            End Sub

            Private Shared Sub makeFileRequest(ByVal fileName As String, ByVal timeout As Integer)
                Try
                    ' <Snippet2>
                    ' <Snippet3>
                    ' Create a Uri object.to access the file requested by the user. 
                    Dim myUrl As New Uri("file://" + fileName)

                    ' Create a FileWebRequest object.for the requeste file.
                    myFileWebRequest = CType(WebRequest.CreateDefault(myUrl), FileWebRequest)

                    ' Set the time-out to the value selected by the user.
                    myFileWebRequest.Timeout = timeout

                    ' </Snippet3>
                    ' Set the Method property to POST  
                    myFileWebRequest.Method = "POST"

                    ' </Snippet2>

                Catch e As WebException
                    Console.WriteLine(("WebException is: " + e.Message))
                Catch e As UriFormatException
                    Console.WriteLine(("UriFormatWebException is: " + e.Message))
                End Try

            End Sub

            Private Shared Sub writeToFile()
                Try
                    ' <Snippet5>
                    ' Enter the string to write to the file.
                    Console.WriteLine("Enter the string you want to write:")
                    Dim userInput As String = Console.ReadLine()

                    ' Convert the string to a byte array.
                    Dim encoder As New ASCIIEncoding
                    Dim byteArray As Byte() = encoder.GetBytes(userInput)

                    ' <Snippet4>
                    ' Set the ContentLength property.
                    myFileWebRequest.ContentLength = byteArray.Length

                    Dim contentLength As String = myFileWebRequest.ContentLength.ToString()

                    Console.WriteLine(ControlChars.Lf + "The content length is {0}.", contentLength)

                    ' </Snippet4>

                    ' Get the file stream handler to write to the file.
                    Dim readStream As Stream = myFileWebRequest.GetRequestStream()

                    ' Write to the stream. 
                    ' Note. For this to work the file must be accessible
                    ' on the network. This can be accomplished by setting the property
                    ' sharing of the folder containg the file.  
                    ' FileWebRequest.Credentials property cannot be used for this purpose.
                    readStream.Write(byteArray, 0, userInput.Length)


                    Console.WriteLine(ControlChars.Lf + "The String you entered was successfully written to the file.")

                    ' </Snippet5>
                    readStream.Close()

                Catch e As WebException
                    Console.WriteLine(("WebException is: " + e.Message))
                Catch e As UriFormatException
                    Console.WriteLine(("UriFormatWebException is: " + e.Message))
                End Try

            End Sub

            Public Shared Sub Main(ByVal args() As String)

                If args.Length < 2 Then
                    showUsage()
                Else
                    makeFileRequest(args(0), Integer.Parse(args(1)))
                    writeToFile()
                End If

            End Sub 'Main

        End Class 'TestGetRequestStream



    End Module

End Namespace

' </Snippet1>  
