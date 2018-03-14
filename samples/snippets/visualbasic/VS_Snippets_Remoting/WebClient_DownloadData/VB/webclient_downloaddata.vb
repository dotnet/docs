' System.Net.WebClient.DownloadData

'This program demonstrates the 'DownloadData' method and 'WebClient()' constructor of 'WebClient' class.
'It creates a URI to access a web resource. The Uri can point 
'to any text or binary web resource, like images etc. The 'DownloadData' method then downloads 
'the required text/html homepage into a byte array. The downloaded data is displayed on the Console.
'

Imports System
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Public Class WebClient_DownloadData
    
    Public Shared Sub Main()
        Try
            ' <Snippet1>		
            ' <Snippet2>

            Console.Write(ControlChars.Cr + "Please enter a Url(for example, http://www.msn.com): ")
            Dim remoteUrl As String = Console.ReadLine()
            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            ' Download the home page data.
            Console.WriteLine(("Downloading " + remoteUrl))
            ' DownloadData() method takes a 'uriRemote.ToString()' and downloads the Web resource and saves it into a data buffer.
            Dim myDatabuffer As Byte() = myWebClient.DownloadData(remoteUrl)

            ' Display the downloaded data.
            Dim download As String = Encoding.ASCII.GetString(myDataBuffer)
            Console.WriteLine(download)

            Console.WriteLine("Download successful.")
            ' </Snippet2>
            ' </Snippet1>
        Catch e As WebException
            ' Display the exception.
            Console.WriteLine(("Download failed!!! WebException : " + e.Message))
        Catch e As Exception
            ' Display the exception.
            Console.WriteLine(("The following general exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_DownloadData
