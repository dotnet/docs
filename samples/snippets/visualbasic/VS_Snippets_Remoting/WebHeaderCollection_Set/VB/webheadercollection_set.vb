' 
' This program demonstrates the 'Set' method of "WebHeaderCollection" class.
'
' This program sets the value of the 'Cache-Control' header 
' in the request to "no-cache".
' The 'Cache-Control' header is used to specify the directive
' that must be followed by all caching mechanisms in the 
' Request-Response chain. The 'no-cache' directive indicates
' that the caching mechanism must not resend the cached 
' response for a previous request without validating from
' the origin server (HTTP version 1.1, RFC2616, Sec 14.9)
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic



Public Class WebHeaderCollection_Set
    
' <Snippet1>    
    Public Shared Sub Main()

	Try
            'Create a web request for "www.msn.com".
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.msn.com"), HttpWebRequest)
            
            'Get the headers associated with the request.
            Dim myWebHeaderCollection As WebHeaderCollection = myHttpWebRequest.Headers
            
            'Set the Cache-Control header in the request.
            myWebHeaderCollection.Set("Cache-Control", "no-cache")

            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
	    Console.WriteLine ("Headers after 'Set' method is used on Cache-Control :")
            'Print the headers for the request.
            PrintHeaders(myWebHeaderCollection)
            myHttpWebResponse.Close()
       'Catch exception if trying to set a restricted header.
        Catch e As ArgumentException
            Console.WriteLine(e.Message)
        Catch e As WebException
            Console.WriteLine(e.Message)
            If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
                Console.WriteLine("Server : {0}", CType(e.Response, HttpWebResponse).Server)
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub 'Main
' </Snippet1>    
    
    Public Shared Sub PrintHeaders(headers As WebHeaderCollection)
        Console.WriteLine("Printing Headers : ")
        If headers.Count = 0 Then
            Console.WriteLine(ControlChars.Tab + "No Headers to Display")
        End If
        Dim i As Integer
        For i = 0 To headers.Count - 1
            Console.WriteLine((ControlChars.Tab + headers.AllKeys(i) + " : " + headers(i)))
        Next i
    End Sub 'PrintHeaders
End Class 'WebHeaderCollection_Set