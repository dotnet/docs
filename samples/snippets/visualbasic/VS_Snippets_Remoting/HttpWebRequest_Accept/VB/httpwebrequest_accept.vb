' System.Net.HttpWebRequest.Accept
'  This program demonstrates 'Accept' property of the 'HttpWebRequest' 
'  class.A new 'HttpWebRequest' object is created.
'  The 'Accept' property of 'HttpWebRequest' class is set to 
'' image/*' that in turn sets the 'Accept' field of HTTP Request Headers 
'  to "image/*". HTTP Request  and  
'  Response headers are displayed to the console.The contents of the 
'  page of the requested URI are displayed 
'  to the console.'Accept' property is set with an aim to receive the 
'  response in a specific format.
'
'Note:This program requires http://localhost/CodeSnippetTest.html as 
'     Command line parameter.If the requested page contains any content 
'     other than 'image/*' an error of 'status (406) Not Acceptable'
'     is returned.The functionality of 'Accept' property is supported 
'     only by servers that use HTTP 1.1 protocol.
'     Please refer to RFC 2616 for further information on HTTP Headers.

Imports System
Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic


Class HttpWebRequest_Accept
    
    
    Overloads Shared Sub Main(ByVal args() As String)
        Try
            If args.Length < 2 Then
                Console.WriteLine(ControlChars.Cr + "Please enter the Uri address as a command line parameter")
                Console.WriteLine("Usage:HttpWebRequest_Accept http://www.microsoft.com/library/homepage/images/ms-banner.gif")
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
    End Sub 'Main
     
    Public Shared Sub GetPage(myUri As [String])
        Try
' <Snippet1>
            ' Create a 'HttpWebRequest' object.
            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create(myUri)
            ' Set the 'Accept' property to accept an image of any type.
            myHttpWebRequest.Accept = "image/*"
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "HTTP Request  Headers :" + ControlChars.Cr + ControlChars.Cr + "{0}", myHttpWebRequest.Headers)
            Console.WriteLine(ControlChars.Cr + "HTTP Response Headers :" + ControlChars.Cr + ControlChars.Cr + "{0}", myHttpWebResponse.Headers)
            Console.WriteLine("Press 'Enter' Key to Continue.......")
            Console.Read()
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
            ' Release the response object resources.
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue......")
            Console.Read()
            streamRead.Close()
            streamResponse.Close()
            myHttpWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message : {0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
        End Try
    End Sub ' GetPage 
End Class ' HttpWebRequest_Accept