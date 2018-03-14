' System.Net.FileWebResponse.ContentLength;System.Net.FileWebResponse.ContentType

'This program demonstrates the 'ContentLength' and 'ContentType' property of 'FileWebResponse' class
'It creates a web request and queries for a response.It then prints the content length
'and content type of the entity body in the response onto the console 

Imports System
Imports System.Net
Imports Microsoft.VisualBasic
Imports System.Environment


Class FileWebResponseSnippet
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Sub Main(args() As String)
        
        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please type the file name as command line parameter as:")
            Console.WriteLine("Usage:FileWebResponse_ContentLength_ContentType " + ChrW(60) + "systemname" + ChrW(62) + "/" + ChrW(60) + "sharedfoldername" + ChrW(62) + "/" + ChrW(60) + "filename" + ChrW(62) + "  " + ControlChars.Cr + "Example:FileWebResponse_ContentLength_ContentType microsoft/shared/hello.txt")
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
            Dim fileUrl As New Uri("file://" + url)
            ' Create a 'FileWebrequest' object with the specified Uri 
            Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(fileUrl), FileWebRequest)
            ' Send the 'fileWebRequest' and wait for response.    
            Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)
            
            ' The ContentLength and ContentType received as headers in the response object are also exposed as properties.
            ' These provide information about the length and type of the entity body in the response.
            Console.WriteLine(ControlChars.Cr + "Content length :{0}, Content Type : {1}", myFileWebResponse.ContentLength, myFileWebResponse.ContentType)
            myFileWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
' </Snippet1>
' </Snippet2>
    End Sub 'GetPage 
End Class 'FileWebResponseSnippet 