' System.Net.FileWebResponse.ResponseUri

'This program demonstrates the 'ResponseUri' property of the 'FileWebResponse' class.
'It creates a FileWebRequest and queries for a response.It then displays the Uri of the file
'system resource that provided the response.

Imports System
Imports System.Net
Imports Microsoft.VisualBasic
Imports System.Environment


Class FileWebResponseSnippet

    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(GetCommandLineArgs())
    End Sub

    Public Overloads Shared Sub Main(ByVal args() As String)

        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please type the file name as command line parameter as:")
            Console.WriteLine("Usage:FileWebResponse_ResponseUri " + ChrW(60) + "systemname" + ChrW(62) + "/" + ChrW(60) + "sharedfoldername" + ChrW(62) + "/" + ChrW(60) + "filename" + ChrW(62) + "  " + ControlChars.Cr + "Example:FileWebResponse_ResponseUri microsoft/shared/hello.txt")
        Else
            GetPage(args(1))
        End If
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main

    ' <Snippet1>    
    Public Shared Sub GetPage(ByVal url As [String])
        Try
            Dim fileUrl As New Uri("file://" + url)
            ' Create a 'FileWebrequest' object with the specified Uri. 
            Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(fileUrl), FileWebRequest)
            ' Send the 'fileWebRequest' and wait for response.
            Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)
            Console.WriteLine("The Uri of the file system resource that provided the response is : {0}", myFileWebResponse.ResponseUri)
            myFileWebResponse.Close()

        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
        ' </Snippet1>
    End Sub 'GetPage
End Class 'FileWebResponseSnippet