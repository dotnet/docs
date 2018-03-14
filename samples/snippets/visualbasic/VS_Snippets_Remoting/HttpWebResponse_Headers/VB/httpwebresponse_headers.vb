' System.Net.HttpWebResponse.Headers
 
'This program demonstrates the 'Headers' property of the 'HttpWebResponse' class.
'It creates a web request and queries for a response.It then displays 
'all the response headers to the console. 

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
            Console.WriteLine("HttpWebResponse_Headers http://www.microsoft.com/net/")
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
            ' Creates an HttpWebRequest with the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Sends the HttpWebRequest and waits for a response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Displays all the Headers present in the response received from the URI.
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The following headers were received in the response")
            'The Headers property is a WebHeaderCollection. Use it's properties to traverse the collection and display each header.
            Dim i As Integer
            While i < myHttpWebResponse.Headers.Count
                Console.WriteLine(ControlChars.Cr + "Header Name:{0}, Value :{1}", myHttpWebResponse.Headers.Keys(i), myHttpWebResponse.Headers(i))
		      i = i + 1
            End While
            myHttpWebResponse.Close()
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try

    End Sub 'GetPage
End Class 'HttpWebResponseSnippet