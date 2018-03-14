' System.Net.WebResponse.ContentLength;System.Net.WebResponse.ContentType

'This program demonstrates the 'ContentLength' and 'ContentType' property of 'WebResponse' class.
'It creates a web request and queries for a response.
'It then prints the content length and content type of the entity body in the response onto the console 

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
            Console.WriteLine("WebResponse_ContentLength_Type http://www.microsoft.com/net/")
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
' <Snippet2>            

            ' Create a 'WebRequest' with the specified url. 	
            Dim myWebRequest As WebRequest = WebRequest.Create("www.contoso.com")

            ' Send the 'WebRequest' and wait for response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()

            ' The ContentLength and ContentType received as headers in the response object are also exposed as properties.
			   ' These provide information about the length and type of the entity body in the response.
            Console.WriteLine(ControlChars.Cr + "Content length :{0}, Content Type : {1}", myWebResponse.ContentLength, myWebResponse.ContentType)
            myWebResponse.Close()
            
' </Snippet1>
' </Snippet2>                    
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "The following error occured : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage 
End Class 'WebResponseSnippet