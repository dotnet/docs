' System.Net.FileWebResponse.GetResponseStream.

' This program demonstrates the 'GetResponseStream' method of the 'FileWebResponse' class
'It creates a 'FileWebRequest' object and queries for a response.
' The response stream obtained is piped to a higher level stream reader. The reader reads 
' 256 characters at a time , writes them into a string and then displays the string onto the console

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
            Console.WriteLine("Usage:FileWebResponse_GetResponseStream " + ChrW(60) + "systemname" + ChrW(62) + "/" + ChrW(60) + "sharedfoldername" + ChrW(62) + "/" + ChrW(60) + "filename" + ChrW(62) + "  " + ControlChars.Cr + "Example:FileWebResponse_GetResponseStream microsoft/shared/hello.txt")
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
            Dim fileUrl As New Uri("file://" + url)
            ' Create a 'FileWebrequest' object with the specified Uri .
            Dim myFileWebRequest As FileWebRequest = CType(WebRequest.Create(fileUrl), FileWebRequest)
            ' Send the 'fileWebRequest' and wait for response. 
            Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.GetResponse(), FileWebResponse)
            
            
            ' CALLING METHOD GetResponseStream will return the stream associated with the response object.
            Dim ReceiveStream As Stream = myFileWebResponse.GetResponseStream()
            
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            ' Pipe the stream to a higher level stream reader with the required encoding format .
            Dim readStream As New StreamReader(ReceiveStream, encode)
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Response stream received")
            
            Dim read(256) As [Char]
            ' Reading 256 characters at a time.    
            Dim count As Integer = readStream.Read(read, 0, 256)
            Console.WriteLine("File Data..." + ControlChars.Lf + ControlChars.Cr)
            While count > 0
                ' Dump the 256 characters on a string and display the string onto the console.
                Dim str As New [String](read, 0, count)
                Console.Write(str)
                count = readStream.Read(read, 0, 256)
            End While
            Console.WriteLine("")
            ' Release the resources of stream object.
            readStream.Close()
            ' Release the resources of response object.
            myFileWebResponse.Close()
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage
End Class 'FileWebResponseSnippet