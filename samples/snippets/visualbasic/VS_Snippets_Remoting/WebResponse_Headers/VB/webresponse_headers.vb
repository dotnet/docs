' System.Net.WebResponse.Headers

' This program demonstrates the 'Headers' property of the 'WebResponse' class.
'
'It creates a web request and queries for a response.
' It then prints out all the response headers ( name -value pairs) onto the console 

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Environment

Class WebResponseSnippet
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(GetCommandLineArgs())
    End Sub
    Overloads Public Shared Sub Main(args() As String)
        
        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please type the Url as command line parameter")
            Console.WriteLine("Example:")
            Console.WriteLine("WebResponse_Headers http://www.microsoft.com/net/")
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

            ' Create a 'WebRequest' object with the specified url 	
            Dim myWebRequest As WebRequest = WebRequest.Create("www.contoso.com")
            
            ' Send the 'WebRequest' and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            
            ' Display all the Headers present in the response received from the URl.
            Console.WriteLine(ControlChars.Cr + "The following headers were received in the response")
            
            ' Headers property is a 'WebHeaderCollection'. Use it's properties to traverse the collection and display each header
            Dim i As Integer
            
            While i < myWebResponse.Headers.Count
                Console.WriteLine(ControlChars.Cr + "Header Name:{0}, Header value :{1}", myWebResponse.Headers.Keys(i), myWebResponse.Headers(i))
		i = i + 1
            End While

            ' Release resources of response object.
            myWebResponse.Close()
            
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage
End Class 'WebResponseSnippet