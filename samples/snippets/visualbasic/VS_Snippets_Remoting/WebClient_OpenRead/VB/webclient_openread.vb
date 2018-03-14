' System.Net.WebClient.OpenRead

'This program demonstrates the 'OpenRead' method of 'WebClient' class.
'It creates a URI to access a web resource. It then invokes 'OpenRead' tp obtain a 'Stream'
'instance which is used to retrieve the web page data. The data read from the stream is then 
'displayed on the console.
'

Imports System
Imports System.Net
Imports System.IO
Imports Microsoft.VisualBasic


Public Class WebClient_OpenRead
    
    Public Shared Sub Main()
        Try
            Console.Write(ControlChars.Cr + "Please enter a Url(e.g. http://www.msn.com): ")
            Dim uriString As String = Console.ReadLine()
' <Snippet1>			
            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            ' Download home page data. 
            Console.WriteLine("Accessing {0} ...", uriString)

            ' Open a stream to point to the data stream coming from the Web resource.
            Dim myStream As Stream = myWebClient.OpenRead(uriString)

            Console.WriteLine(ControlChars.Cr + "Displaying Data :" + ControlChars.Cr)
	    Dim sr As New StreamReader(myStream)
	    Console.WriteLine(sr.ReadToEnd())


            ' Close the stream.
            myStream.Close()
' </Snippet1>
        Catch e As WebException
            ' Display the exception.
            Console.WriteLine(("Webresource access failed!!! WebException : " + e.Message))
        Catch e As Exception
            ' Display the exception.
            Console.WriteLine(("The following general exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_OpenRead
