' System.Net.HttpWebResponse.LastModified

' This program demonstrates the 'LastModified' property of the 'HttpWebResponse' class.
'It creates a web request and queries for a response.The program checks 
'if the entity requested was modified any time today.

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
            Console.WriteLine("HttpWebResponse_LastModified http://www.microsoft.com/net/")
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
            ' Creates an HttpWebRequest for the specified URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            If myHttpWebResponse.StatusCode = HttpStatusCode.OK Then
                Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Request succeeded and the requested information is in the response , Description : {0}", myHttpWebResponse.StatusDescription)
            End If
            Dim today As DateTime = DateTime.Now
            ' Uses the LastModified property to compare with today's date.
            If DateTime.Compare(today, myHttpWebResponse.LastModified) = 0 Then
                Console.WriteLine(ControlChars.Cr + "The requested URI entity was modified today")
            Else
                If DateTime.Compare(today, myHttpWebResponse.LastModified) =  1 Then
                    Console.WriteLine(ControlChars.Cr + "The requested Uri was last modified on:{0}", myHttpWebResponse.LastModified)
                End If
            End If
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
' </Snippet1>	        
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Exception Raised. The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage
End Class 'HttpWebResponseSnippet