 ' 
' This program demonstrates the "Add" method of "WebHeaderCollection" class.
'
' The program uses the "Add" method of "WebHeaderCollection" class
' to add the 'Accept-Language' header in the request.
' The 'Accept-Language' header is used in a request to specify the
' language preferences of the user. The server can use the language
' preferences specified to generate output for that particular 
' language. 
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Public Class WebHeaderCollection_Add
    
' <Snippet1>   
    Public Shared Sub Main()

     Try
            'Create a web request for "www.msn.com".
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.msn.com"), HttpWebRequest)
            
            'Get the headers associated with the request.
            Dim myWebHeaderCollection As WebHeaderCollection = myHttpWebRequest.Headers
            
   	    Console.WriteLine("Configuring Webrequest to accept Danish and English language using 'Add' method")
            
	    'Add the Accept-Language header (for Danish) in the request.
            myWebHeaderCollection.Add("Accept-Language:da")
            
            'Include English in the Accept-Langauge header. 
            myWebHeaderCollection.Add("Accept-Language","en;q" + ChrW(61) + "0.8")
            
            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
            'Print the headers for the request.
            printHeaders(myWebHeaderCollection)
            myHttpWebResponse.Close()
        'Catch exception if trying to add a restricted header.
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
    
    Public Shared Sub printHeaders(headers As WebHeaderCollection)
        Console.WriteLine("Printing Headers : ")
        If headers.Count = 0 Then
            Console.WriteLine(ControlChars.Tab + "No Headers to Display")
        End If
        Dim i As Integer
        For i = 0 To headers.Count - 1
            Console.WriteLine((ControlChars.Tab + headers.AllKeys(i) + " : " + headers(i)))
        Next i
    End Sub 'printHeaders
End Class 'WebHeaderCollection_Add