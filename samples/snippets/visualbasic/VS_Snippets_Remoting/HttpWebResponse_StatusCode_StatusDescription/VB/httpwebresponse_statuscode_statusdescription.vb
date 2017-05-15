' System.Net.HttpWebResponse.StatusCode; System.Net.HttpWebResponse.StatusDescription

 'This program demonstrates the 'StatusCode' and 'StatusDescription' property of the 'HttpWebResponse' class
'It creates a web request and queries for a response. 

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
            Console.WriteLine("HttpWebResponse_StatusCode_StatusDescription http://www.microsoft.com/net/")
        Else
            GetPage(args(1))
        End If
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
' <Snippet1>	
' <Snippet2>	    
    Public Shared Sub GetPage(url As [String])
       Try
            ' Creates an HttpWebRequest with the specified URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Sends the request and waits for a response.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                Console.WriteLine(ControlChars.Lf + ControlChars.NewLine + "Response Status Code is OK and StatusDescription is: {0}", myHttpWebResponse.StatusDescription)
            End If
            ' Release the resources of the response.
            myHttpWebResponse.Close()
        
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.NewLine + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 
' </Snippet1>	
' </Snippet2>	    
End Class
