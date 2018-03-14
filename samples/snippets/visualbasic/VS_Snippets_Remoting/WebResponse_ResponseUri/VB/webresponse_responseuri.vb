' System.Net.WebResponse.ResponseUri
'This program demonstrates the 'ResponseUri' property of the 'WebResponse' class.
'It creates a web request and queries for a response.
'It then compares the ResponseUri value to the actual Url value to see if the original request was redirected

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
            Console.WriteLine("WebResponse_ResponseUri http://www.microsoft.com")
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
            ' Create a 'WebRequest' object with the specified url. 

            Dim myWebRequest As WebRequest = WebRequest.Create(url)

            ' Send the 'WebRequest' and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            
            ' "ResponseUri" property is used to get the actual Uri from where the response was attained.
            If ourUri.Equals(myWebResponse.ResponseUri) Then
                Console.WriteLine(ControlChars.Cr + "Request Url : {0} was not redirected", url)
            Else
                Console.WriteLine(ControlChars.Cr + "Request Url : {0} was redirected to {1}", url, myWebResponse.ResponseUri)
            End If 

            ' Release resources of response object.
            myWebResponse.Close()
            
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage
End Class 'WebResponseSnippet