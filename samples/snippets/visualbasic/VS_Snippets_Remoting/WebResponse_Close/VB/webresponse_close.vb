'  System.Net.WebResponse.Close
'This program demonstrates the 'Close' method of 'WebResponse' Class. 
'It takes an URL from console and creates a 'WebRequest' object for the Url.It then gets back 
'the response object from the Url. The response object can be processed as desired.
'The program then closes the response object and releases resources associated with it.

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
            Console.WriteLine("WebResponse_Close http://www.microsoft.com/net/")
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
            
            '  Process the response here
            Console.WriteLine(ControlChars.Cr + "Response Received.Trying to Close the response stream..")
            ' Release resources of response object
            myWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "Response Stream successfully closed")
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage
End Class 'WebResponseSnippet