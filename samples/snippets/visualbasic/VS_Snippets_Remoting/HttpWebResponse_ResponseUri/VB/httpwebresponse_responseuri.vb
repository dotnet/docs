' System.Net.HttpWebResponse.ResponseUri
'This program demonstrates the 'ResponseUri' property of the 'HttpWebResponse' class
'It creates a web request and queries for a response.It checks if the original Uri 
'was redirected by the server. 

Imports System
Imports System.Net
Imports Microsoft.VisualBasic
Imports System.Environment

Class HttpWebResponseSnippet
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Sub Main(args() As String)
        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please type the url as command line parameter")
            Console.WriteLine("Example:")
            Console.WriteLine("HttpWebResponse_ResponseUri http://www.microsoft.com/net/")
        Else
            GetPage(args(1))
        End If
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
    
    Public Shared Sub GetPage(url As [String])
	Try
' <Snippet1>
            Dim myUri As New Uri(url)
            ' Create a 'HttpWebRequest' object for the specified url 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
            ' Send the request and wait for response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                Console.WriteLine(ControlChars.Cr + "Request succeeded and the requested information is in the response , Description : {0}", myHttpWebResponse.StatusDescription)
            End If
            If myUri.Equals(myHttpWebResponse.ResponseUri) Then
                Console.WriteLine(ControlChars.Cr + "The Request Uri was not redirected by the server")
            Else
                Console.WriteLine(ControlChars.Cr + "The Request Uri was redirected to :{0}", myHttpWebResponse.ResponseUri)
            End If
            ' Release resources of response object.
            myHttpWebResponse.Close()
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage
End Class 'HttpWebResponseSnippet