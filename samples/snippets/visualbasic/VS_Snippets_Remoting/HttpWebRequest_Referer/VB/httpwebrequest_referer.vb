 'System.Net.HttpWebRequest.Referer
'This program demonstrates 'Referer' property of the 'HttpWebRequest' class.
'A new 'HttpWebRequest' object is created.The 'Referer' property is displayed to the console.
'HTTP Request  and  Response Headers are displayed to the console.The contents of the page of the 
'requested URI are displayed to the console.
'
'Note:The 'Referer' property is used by the server to store the address of the Uri that has referred 
'     the request to that server.Please refer to RFC 2616 for more information on HTTP Headers.
'

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Class HttpWebRequest_Referer
     Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Shared Sub Main(args() As String)
        Try
            If args.Length < 2 Then
                Console.WriteLine(ControlChars.Cr + "Please enter the Uri address as a command line parameter")
                Console.WriteLine("[ Usage:HttpWebRequest_Referer http://www.microsoft.com ]")
            Else
                GetPage(args(1))
            End If
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message :{0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub ' Main
    
    Public Shared Sub GetPage(myUri As [String])
        Try
' <Snippet1>
            ' Create a 'HttpWebRequest' object.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
            ' Referer property is set to http://www.microsoft.com
            myHttpWebRequest.Referer = "http://www.microsoft.com"
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Displaying the contents of the page to the console
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuffer(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuffer, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of HTML page are.......")
            While count > 0
                Dim outputData As New [String](readBuffer, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuffer, 0, 256)
            End While
            Console.WriteLine(ControlChars.Cr + "HTTP Request  Headers :" + ControlChars.Cr + ControlChars.Cr + "{0}", myHttpWebRequest.Headers)
            Console.WriteLine(ControlChars.Cr + "HTTP Response Headers :" + ControlChars.Cr + ControlChars.Cr + "{0}", myHttpWebResponse.Headers)
            ' Release the response object resources.
            streamRead.Close()
	         streamResponse.Close()
            myHttpWebResponse.Close()
            Console.WriteLine("Referer to the site is:{0}", myHttpWebRequest.Referer)
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue......")
            Console.Read()
 	    
       Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message : {0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
        End Try
    End Sub ' GetPage 
End Class ' HttpWebRequest_Referer