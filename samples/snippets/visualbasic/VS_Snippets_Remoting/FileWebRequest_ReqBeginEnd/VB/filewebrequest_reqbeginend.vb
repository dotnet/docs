' System.Net.FileWebRequest.BeginGetRequestStream;System.Net.FileWebRequest.EndGetRequestStream;
' Snippet1 and Snippet2 go together

' This program demonstrates 'BeginGetRequestStream' and 'EndGetRequestStream method of 'FileWebRequest' class
' The path of the file from where content is to be read  is obtained as a command line argument and a 'webRequest'
' object is created.Using the 'BeginGetRequestStream' method and 'EndGetRequestStream' of 'FileWebRequest' class 
' a stream object is obtained which is used to write into the file.


Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic


' <Snippet1>
' <Snippet2>
Public Class RequestDeclare
    Public myFileWebRequest As FileWebRequest
    Public userinput As [String]
    
    
    Public Sub New()
        myFileWebRequest = Nothing
    End Sub ' New
End Class ' RequestDeclare


Class FileWebRequest_reqbeginend
    Public Shared allDone As New ManualResetEvent(False)
    
    ' Entry point which delegates to C-style main Private Function.
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    
    Overloads Shared Sub Main(args() As String)
        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please enter the file name as command line parameter:")
            Console.WriteLine("Usage:FileWebRequest_reqbeginend <systemname>/<sharedfoldername>/<filename>")
	    Console.WriteLine("Example: FileWebRequest_reqbeginend shafeeque/shaf/hello.txt")
        
        Else
            Try

                ' Place a webrequest.
                Dim myWebRequest As WebRequest = WebRequest.Create(("file://" + args(1)))
                
                ' Create an instance of the 'RequestDeclare' and associate the 'myWebRequest' to it.		
                Dim requestDeclare As New RequestDeclare()
                requestDeclare.myFileWebRequest = CType(myWebRequest, FileWebRequest)
                ' Set the 'Method' property of 'FileWebRequest' object to 'POST' method.
                requestDeclare.myFileWebRequest.Method = "POST"
                Console.WriteLine("Enter the string you want to write into the file:")
                requestDeclare.userinput = Console.ReadLine()
                
                ' Begin the Asynchronous request for getting file content using 'BeginGetRequestStream()' method .
                Dim r As IAsyncResult = CType(requestDeclare.myFileWebRequest.BeginGetRequestStream(AddressOf ReadCallback, requestDeclare), IAsyncResult)
                allDone.WaitOne()
                
                Console.Read()
            Catch e As ProtocolViolationException
                Console.WriteLine(("ProtocolViolationException is :" + e.Message))
            Catch e As InvalidOperationException
                Console.WriteLine(("InvalidOperationException is :" + e.Message))
            Catch e As UriFormatException
                Console.WriteLine(("UriFormatExceptionException is :" + e.Message))
            End Try

        End If 
    End Sub 'Main
    
    
    Private Shared Sub ReadCallback(ar As IAsyncResult)
        Try

            ' State of the request is asynchronous.
            Dim requestDeclare As RequestDeclare = CType(ar.AsyncState, RequestDeclare)
            Dim myFileWebRequest As FileWebRequest = requestDeclare.myFileWebRequest
            Dim sendToFile As [String] = requestDeclare.userinput
            
            ' End the Asynchronus request by calling the 'EndGetRequestStream()' method.
            Dim readStream As Stream = myFileWebRequest.EndGetRequestStream(ar)
            
            ' Convert the string into byte array.
            Dim encoder As New ASCIIEncoding()
            Dim byteArray As Byte() = encoder.GetBytes(sendToFile)
            
            ' Write to the stream.
            readStream.Write(byteArray, 0, sendToFile.Length)
            readStream.Close()
            allDone.Set()

            
            Console.WriteLine(ControlChars.Cr +"The String you entered was successfully written into the file.")
            Console.WriteLine(ControlChars.Cr +"Press Enter to continue.")

            Catch e As ApplicationException
            Console.WriteLine(("ApplicationException is :" + e.Message))
        End Try

    End Sub ' ReadCallback 
' </Snippet2> 
' </Snippet1>
End Class ' FileWebRequest_reqbeginend




