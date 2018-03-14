' System.Net.WebClient.OpenWrite(String,String)

'This program demonstrates the 'OpenWrite(String,String)' method of "WebClient" class.
'It accepts an Uri and some string content to be posted to the Uri. The
'program makes a call to 'OpenWrite(String,String)' method and obtains a "Stream" instance
'This stream is used to post data to the site. 
'
'Note : Behaviour of this program may not be the same with all other sites. Also certain 
'sites would not accept "Post" method thereby leading to an error.It is advisable 
'to construct a site using files accompanying this and provide
'url name of this site to the program.
'
Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic


Public Class WebClient_OpenWrite
    
    Public Shared Sub Main()
        Try
' <Snippet1>			
            Dim uriString As String
            Console.Write(ControlChars.Cr + "Please enter the URI to post data to : ")
            uriString = Console.ReadLine()
            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the URI {0}:", uriString)
            Dim postData As String = Console.ReadLine()
            ' Apply ASCII encoding to obtain an array of bytes.
            Dim postArray As Byte() = Encoding.ASCII.GetBytes(postData)

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            Console.WriteLine("Uploading to {0} ...", uriString)
            Dim postStream As Stream = myWebClient.OpenWrite(uriString, "POST")

            postStream.Write(postArray, 0, postArray.Length)

            ' Close the stream and release resources.
            postStream.Close()

            Console.WriteLine(ControlChars.Cr + "Successfully posted the data.")
' </Snippet1>			
        Catch e As WebException
            Console.WriteLine(("The following exception was raised: " + e.Message))
        Catch e As Exception
            Console.WriteLine(("The following exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_OpenWrite
