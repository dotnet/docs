' System.Net.HttpWebResponse.Method;System.Net.HttpWebResponse.Server

' This program demonstrates the 'Method' and 'Server' properties of the 'HttpWebResponse' class. 
'It creates a Web request and queries for a response.It evaluates the response method used and the prints
' the Web server name to the console

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
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
            Console.WriteLine("HttpWebResponse_Method_Server http://www.microsoft.com/net/")
        Else
            GetPage(args(1))
        End If
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
    
    Public Shared Sub GetPage(url As [String])
' <Snippet1> 
' <Snippet2> 
      Try
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Dim method As String
            method = myHttpWebResponse.Method
            If [String].Compare(method, "GET") = 0 Then
                Console.WriteLine(ControlChars.NewLine + "The GET method was successfully invoked on the following Web Server : {0}", myHttpWebResponse.Server)
            End If
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(ControlChars.NewLine + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.NewLine + "The following exception was raised : {0}", e.Message)
        End Try
' </Snippet1> 
' </Snippet2>
    End Sub 'GetPage
End Class 
