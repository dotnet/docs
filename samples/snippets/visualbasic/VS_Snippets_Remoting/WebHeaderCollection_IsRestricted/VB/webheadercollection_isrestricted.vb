 '
' This program demonstrates the "IsRestricted" method of "WebHeaderCollection".
'
' This program checks if the first header returned in the 
' response is a restricted header or not.
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Public Class CheckRestricted
    
' <Snippet1>            
    Public Shared Sub Main()
	Try
            'Create a web request for "www.msn.com".
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.msn.com"), HttpWebRequest)
            
            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
            'Get the headers associated with the response.
            Dim myWebHeaderCollection As WebHeaderCollection = myHttpWebResponse.Headers
            
            'Check if the first response header is restricted.
	    dim i as integer
	    for i =0 to myWebHeaderCollection.Count-1
	            If WebHeaderCollection.IsRestricted(myWebHeaderCollection.AllKeys(i)) Then
	                Console.WriteLine("'{0}' is a restricted header", myWebHeaderCollection.AllKeys(i))
	            Else
	                Console.WriteLine("'{0}' is not a restricted header", myWebHeaderCollection.AllKeys(i))
	            End If 
	    next
        myHttpWebResponse.Close()
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
End Class 'CheckRestricted