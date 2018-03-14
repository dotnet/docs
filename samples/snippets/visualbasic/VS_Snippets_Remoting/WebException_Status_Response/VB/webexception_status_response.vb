 '
'This program demonstrates the 'Status' and the 'Response' property of "WebException" class.
'
' This program tries to access an invalid site and displays the status code and 
'  status description of the resultant exception that is raised.
'

Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Public Class WebException_Status_Response
    
    
    Public Shared Sub Main()
' <Snippet1>
' <Snippet2>
        Try
            'Create a web request for an invalid site. Substitute the "invalid site" strong in the Create call with a invalid name.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("invalid site"), HttpWebRequest)
            
            'Get the associated response for the above request.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            myHttpWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(e.Message)
            
             If e.Status = WebExceptionStatus.ProtocolError Then
                Console.WriteLine("Status Code : {0}", CType(e.Response, HttpWebResponse).StatusCode)
                Console.WriteLine("Status Description : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
            End If
' </Snippet2>

       Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        ' </Snippet1>        
    End Sub 'Main
End Class 'WebException_Status_Response