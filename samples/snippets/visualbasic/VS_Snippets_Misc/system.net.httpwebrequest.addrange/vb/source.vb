 'System.Net.HttpWebRequest.AddRange(int,int)
'This program demonstrates 'AddRange(int,int)' method of 'HttpWebRequest class.
'A new 'HttpWebRequest' object is created.The number of characters of the response to be received can be 
'restricted by the 'AddRange' method.By calling 'AddRange(50,150)' on the 'HttpWebRequest' object the content 
'of the response page is restricted from the 50th character to 150th charater.The response of the request is
'obtained and displayed to the console.
'

Imports System
Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic


Class HttpWebRequest_AddRange_int
    
    Shared Sub Main()
        Try
' <Snippet1>
            ' A New 'HttpWebRequest' object is created.
            Dim myHttpWebRequest1 As HttpWebRequest = WebRequest.Create("http://www.contoso.com")
            myHttpWebRequest1.AddRange(1000)
            Console.WriteLine("Call AddRange(1000)")
			      Console.Write("Resulting Headers: ")
			      Console.WriteLine(myHttpWebRequest1.Headers.ToString())

            Dim myHttpWebRequest2 As HttpWebRequest = WebRequest.Create("http://www.contoso.com")
            myHttpWebRequest2.AddRange(-1000)
            Console.WriteLine("Call AddRange(-1000)")
			      Console.Write("Resulting Headers: ")
			      Console.WriteLine(myHttpWebRequest2.Headers.ToString())
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
        End Try
    End Sub ' Main
End Class ' HttpWebRequest_AddRange_int


