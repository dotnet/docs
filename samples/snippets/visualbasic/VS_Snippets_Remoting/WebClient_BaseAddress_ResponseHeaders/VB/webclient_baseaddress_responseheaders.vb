' System.Net.WebClient.BaseAddress; System.Net.WebClient.ResponseHeaders

 'This program demonstrates the 'BaseAddress' and 'ResponseHeaders' property of 'WebClient' class.
'  It accepts the base Uri from the user and assigns it to the 'BaseAddress' property of the 
'  'WebClient' class.It then invokes 'DownloadFile' for the specific web page requested by the
'  user. WebClient internally combines the 'BaseAddress' and specific page name to retrieve the page.
'  
'  The 'ResponseHeaders' property is a 'WebHeaderCollection' that contains the
'  header information of the response received from the server.This is displayed to the console.
'

Imports System
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Public Class WebClient_BaseAddress
    
    Public Shared Sub Main()
        Try
            Console.Write(ControlChars.Cr + "Please enter a Url{e.g. : http://www.microsoft.com}")
            Dim hostUri As String = Console.ReadLine()
            Console.Write(ControlChars.Cr + "Please enter the specific web page you require{e.g. : windows/default.asp} : ")
            Dim uriSuffix As String = Console.ReadLine()
' <Snippet1>
            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            ' Set the BaseAddress of the Web resource in the WebClient.
            myWebClient.BaseAddress = hostUri
            Console.WriteLine(("Downloading from " + hostUri + "/" + uriSuffix))
            Console.WriteLine(ControlChars.Cr + "Press Enter key to continue")
            Console.ReadLine()

            ' Download the target Web resource into a byte array.
            Dim myDatabuffer As Byte() = myWebClient.DownloadData(uriSuffix)

            ' Display the downloaded data.
	    Dim download As String = Encoding.ASCII.GetString(myDatabuffer)
	    Console.WriteLine(download)

            Console.WriteLine(("Download of " + myWebClient.BaseAddress.ToString() + uriSuffix + " was successful."))
' </Snippet1>
' <Snippet2>
            ' ResponseHeaders is a WebHeaderCollection instance that contains the headers sent back 
	         ' in response to the WebClient request. 
            Dim myWebHeaderCollection As WebHeaderCollection = myWebClient.ResponseHeaders
            Console.WriteLine(ControlChars.Cr + "Displaying the response headers" + ControlChars.Cr)
            ' Loop through the ResponseHeaders.
            Dim i As Integer
            For i = 0 To myWebHeaderCollection.Count - 1
                ' Display the headers as name/value pairs.
                Console.WriteLine((ControlChars.Tab + myWebHeaderCollection.GetKey(i) + " " + ChrW(61) + " " + myWebHeaderCollection.Get(i)))
            Next i 
' </Snippet2>
        Catch e As WebException
            Console.WriteLine(("The following WebException was raised: " + e.Message))
        Catch e As Exception
            Console.WriteLine(("The following Exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_BaseAddress
