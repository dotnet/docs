' System.Net.HttpWebResponse.Close

 'This program demonstrates the 'Close' method of the 'HttpWebResponse' class.
' It creates a web request and queries for a response.The response object can be processed as desired.
'The program then closes the response object and releases resources associated with it.

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
            Console.WriteLine("Please type the url as command line parameter")
            Console.WriteLine("Example:")
            Console.WriteLine("HttpWebResponse_Close http://www.microsoft.com/net/")
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
            ' Creates an HttpWebRequest for the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Sends the HttpWebRequest and waits for a response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine("Response Received.Trying to Close the response stream..")
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
            Console.WriteLine("Response Stream successfully closed")
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine("Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine("The following exception was raised : {0}", e.Message)
        End Try
   End Sub 'GetPage
End Class 'HttpWebResponseSnippet