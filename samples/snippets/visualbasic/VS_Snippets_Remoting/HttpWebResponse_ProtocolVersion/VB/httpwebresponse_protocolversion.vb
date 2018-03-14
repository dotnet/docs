' System.Net.HttpWebResponse.ProtocolVersion

 ' This program demonstrates the 'ProtocolVersion' property of the 'HttpWebResponse' class.
 ' It creates a web request and queries for a response.The server should respond using the same version 

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
            Console.WriteLine(ControlChars.NewLine + "Please type the url as command line parameter")
            Console.WriteLine("Example:")
            Console.WriteLine("HttpWebResponse_ProtocolVersion http://www.microsoft.com/net/")
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
            Dim ourUri As New Uri(url)
            ' Creates an HttpWebRequest with the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(ourUri), HttpWebRequest)
            myHttpWebRequest.ProtocolVersion = HttpVersion.Version10
            ' Sends the request and waits for the response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            'The ProtocolVersion property is used to ensure that only Http/1.0 responses are accepted. 
            If myHttpWebResponse.ProtocolVersion Is HttpVersion.Version10 Then
                Console.WriteLine(ControlChars.NewLine + "The server responded with a version other than Http/1.0")
            Else
                If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                    Console.WriteLine(ControlChars.NewLine + "Request sent using version HTTP/1.0. Successfully received response with version Http/1.0 ")
                End If
            End If
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine(ControlChars.NewLine + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage
End Class 'HttpWebResponseSnippet