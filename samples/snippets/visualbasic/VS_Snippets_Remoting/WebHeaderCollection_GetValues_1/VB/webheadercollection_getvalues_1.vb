 '
' This program demonstrate's the 'GetValues(string)' method of 'WebHeaderCollection' class.
' 
' The program creates a 'HttpWebRequest' object from the specified URL and gets the response from it. The 
' headers of the response is assigned to a 'WeHeaderCollection' object and all the values associated with
' the corresponding headers in the response are displayed to the console.
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Public Class WebHeaderCollection_GetValues_1
    
    
    Public Shared Sub Main()
        
        Try
' <Snippet1>
            'Create a web request for "www.msn.com".
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.msn.com"), HttpWebRequest)
	    myHttpWebRequest.Timeout = 1000
            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            
            'Get the headers associated with the response.
            Dim myWebHeaderCollection As WebHeaderCollection = myHttpWebResponse.Headers
            Dim i As Integer
            For i = 0 To myWebHeaderCollection.Count - 1
                Dim header As [String] = myWebHeaderCollection.GetKey(i)
                Dim values As [String]() = myWebHeaderCollection.GetValues(header)
                If values.Length > 0 Then
                    Console.WriteLine("The values of {0} header are : ", header)
                    Dim j As Integer
                    For j = 0 To values.Length - 1
                        Console.WriteLine(ControlChars.Tab + "{0}", values(j))
                    Next j
                Else
                    Console.WriteLine("There is no value associated with the header")
                End If
            Next i 
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException raised : {0}", e.Message)
            If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
                Console.WriteLine("Server : {0}", CType(e.Response, HttpWebResponse).Server)
            End If
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + " Exception raised : {0}", e.Message)
        End Try
    End Sub 'Main
End Class 'WebHeaderCollection_GetValues_1