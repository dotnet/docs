' System.Net.FileWebResponse.Close

'This program demonstrates the functionality of 'Close' method of 'FileWebResponse' Class. 
'It takes an Uri from console and creates a 'FileWebRequest' object for the Uri.It then gets back
'the response object from the Uri. The response object can be processed as desired.The program then 
'closes the response object and releases resources associated with it.
Imports System
Imports System.Net
Imports System.IO
Imports System.Text
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
            Console.WriteLine("Usage:FileWebResponse_Close " + ChrW(60) + "systemname" + ChrW(62) + "/" + ChrW(60) + "sharedfoldername" + ChrW(62) + "/" + ChrW(60) + "filename" + ChrW(62) + "  " + ControlChars.Cr + "Example:FileWebResponse_Close microsoft/shared/hello.txt")
        Else
            GetPage(args(1))
        End If
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
' <Snippet1>  
    Public Shared Sub GetPage(url As [String])
        Try
            Dim fileUrl As New Uri("file://" + url)
            ' Create a FileWebrequest with the specified Uri. 
            Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(fileUrl), FileWebRequest)
            ' Send the 'fileWebRequest' and wait for response.
            Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)
            ' Process the response here                        
            Console.WriteLine(ControlChars.Cr + "Response Received.Trying to Close the response stream..")
            ' The method call to release resources of response object.
            myFileWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "Response Stream successfully closed")
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
' </Snippet1>
    End Sub 'GetPage
End Class 'FileWebResponseSnippet