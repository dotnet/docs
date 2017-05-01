' System.Net.FileWebRequest.ContentLength;System.Net.FileWebRequest.RequestUri;

' This program demonstrates 'ContentLength'and 'RequestUri property of 'FileWebRequest' class.
' The path of a file where user would like to write something is obtained from command line argument.
' Then a 'webRequest' object is created. The 'ContentLength' property of 'FileWebRequest' is used to
' set the length of the file content that was written.

Imports System.Net
Imports System
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Environment



Class FileWebRequest_ContentLen
    
    ' Entry point which delegates to C-style main Private Function'
    Public Overloads Shared Sub Main()
        Main(GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Sub Main(args() As [String])
        
        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please enter the file name as command line parameter where you want to write:")
            Console.WriteLine("Usage:FileWebRequest_ContentLen " + ChrW(60) + "systemname" + ChrW(62) + "/" + ChrW(60) + "sharedfoldername" + ChrW(62) + "/" + ChrW(60) + "filename" + ChrW(62) + ControlChars.Cr + "Example:FileWebRequest_ContentLen shafeeque/shaf/hello.txt")
        
        Else
            Try
                
                ' Create an 'Uri' object. 
                Dim myUrl As New Uri("file://" + args(1))
                Dim fileName As [String] = "file://" + args(1)
                Dim myFileWebRequest As FileWebRequest = Nothing
                
' <Snippet1>
                myFileWebRequest = CType(WebRequest.Create(myUrl), FileWebRequest)
                
                Console.WriteLine("Enter the string you want to write into the file:")
                Dim userInput As [String] = Console.ReadLine()
                Dim encoder As New ASCIIEncoding()
                Dim byteArray As Byte() = encoder.GetBytes(userInput)
                
                ' Set the 'Method' property of 'FileWebRequest' object to 'POST' method.
                myFileWebRequest.Method = "POST"
                
                ' The 'ContentLength' property is used to set the content length of the file.
                myFileWebRequest.ContentLength = byteArray.Length
' </Snippet1>
' <Snippet2>
                ' Compare the file name and 'RequestUri' is same or not.
                If myFileWebRequest.RequestUri.Equals(myUrl) Then
                    ''GetRequestStream' method returns the stream handler for writing into the file.
                    Dim readStream As Stream = myFileWebRequest.GetRequestStream()
                    ' Write to the stream.
                    readStream.Write(byteArray, 0, userInput.Length)
                    readStream.Close()
                End If

                Console.WriteLine("The String you entered was successfully written into the file.")
                Console.WriteLine((ControlChars.Cr +"The content length sent to the server is " + myFileWebRequest.ContentLength.ToString() + "."))
' </Snippet2>
            Catch e As ArgumentException
                Console.WriteLine(("The ArgumentException is :" + e.Message))
            Catch e As UriFormatException
                Console.WriteLine(("The UriFormatException is :" + e.Message))
            End Try
        End If
    End Sub ' Main
End Class ' FileWebRequest_ContentLen