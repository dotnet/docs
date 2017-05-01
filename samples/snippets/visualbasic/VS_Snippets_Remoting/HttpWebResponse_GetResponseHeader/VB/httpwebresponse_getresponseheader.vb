' System.Net.HttpWebResponse.GetResponseHeader

 'This program demonstrates the 'GetResponseHeader' method of the 'HttpWebResponse' class
'It creates a web request and queries for a response.If the site requires authentication it 
'will respond with a challenge string which is extracted using 'GetResponse' method.

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
            Console.WriteLine(ControlChars.NewLine + "Please type a protected resource url as command line parameter")
            Console.WriteLine("Example:")
            Console.WriteLine("HttpWebResponse_GetResponseHeader http://www.microsoft.com/net/")
        Else
            GetPage(args(1))
        End If
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
' <Snippet1>    
    Public Shared Sub GetPage(url As [String])
	Try
            Dim ourUri As New Uri(url)
            ' Creates an HttpWebRequest for the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(ourUri), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine(ControlChars.NewLine + "The server did not issue any challenge.  Please try again with a protected resource URL.")
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
        Catch e As WebException
            Dim response As HttpWebResponse = CType(e.Response, HttpWebResponse)
            If Not (response Is Nothing) Then
                If response.StatusCode = HttpStatusCode.Unauthorized Then
                    Dim challenge As String = Nothing
                    challenge = response.GetResponseHeader("WWW-Authenticate")
                    If Not (challenge Is Nothing) Then
                        Console.WriteLine(ControlChars.NewLine + "The following challenge was raised by the server:{0}", challenge)
                    End If
                Else
                    Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
                End If
            Else
                Console.WriteLine(ControlChars.NewLine + "Response Received from server was null")
            End If 
        Catch e As Exception
            Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 
' </Snippet1>
End Class 'HttpWebResponseSnippet