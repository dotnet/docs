' System.Net.FileWebRequest.BeginGetResponse;System.Net.FileWebRequest.EndGetResponse;
' Snippet1 and Snippet2 go together  
' This program demonstrates 'BeginGetResponse' and 'EndGetResponse' methods of 'FileWebRequest' class.
' The path of the file from where content is to be read  is obtained as a command line argument and a 
' 'webRequest' object is created. Using the 'BeginGetResponse' method and 'EndGetResponse' of 'FileWebRequest' 
' class a 'FileWebResponse' object is obtained which is used to print the content on the file.


Imports System
Imports System.Net
Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic
Imports System.Environment

' <Snippet1>
' <Snippet2>
Public Class RequestDeclare
    Public myFileWebRequest As FileWebRequest
     
    Public Sub New()
        myFileWebRequest = Nothing
    End Sub ' New
End Class ' RequestDeclare



Class FileWebRequest_resbeginend
    
    Public Shared allDone As New ManualResetEvent(False)
    
    ' Entry point which delegates to C-style main Private Function.
    Public Overloads Shared Sub Main()
        Main(GetCommandLineArgs())
    End Sub
    
    Overloads Shared Sub Main(args() As String)
        
        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please enter the file name as command line parameter:")
            Console.WriteLine("Usage:FileWebRequest_resbeginend " + ChrW(60) + "systemname" + ChrW(62) + "/" + ChrW(60) + "sharedfoldername" + ChrW(62) + "/" + ChrW(60) + "filename" + ChrW(62) + ControlChars.Cr + "Example:FileWebRequest_resbeginend shafeeque/shaf/hello.txt")
        
        Else
            Try

                ' Place a webrequest.
                Dim myWebRequest As WebRequest = WebRequest.Create(("file://" + args(1)))
                ' Create an instance of the 'RequestDeclare' and associating the 'myWebRequest' to it.		
                Dim myRequestDeclare As New RequestDeclare()
                myRequestDeclare.myFileWebRequest = CType(myWebRequest, FileWebRequest)
                
                ' Begin the Asynchronous request for getting file content using 'BeginGetResponse()' method.	
                 Dim asyncResult As IAsyncResult = CType(myRequestDeclare.myFileWebRequest.BeginGetResponse(AddressOf RespCallback, myRequestDeclare), IAsyncResult)
                 allDone.WaitOne()

            
            Catch e As ArgumentNullException
                Console.WriteLine(("ArgumentNullException is :" + e.Message))
            Catch e As UriFormatException
                Console.WriteLine(("UriFormatException is :" + e.Message))
            End Try
        End If
    End Sub ' Main
    
    
    Private Shared Sub RespCallback(ar As IAsyncResult)



        ' State of request is asynchronous.
        Dim requestDeclare As RequestDeclare = CType(ar.AsyncState, RequestDeclare)
        
        Dim myFileWebRequest As FileWebRequest = requestDeclare.myFileWebRequest
        
        ' End the Asynchronus request by calling the 'EndGetResponse()' method.
        Dim myFileWebResponse As FileWebResponse = CType(myFileWebRequest.EndGetResponse(ar), FileWebResponse)
        
        ' Reade the response into Stream.
        Dim streamReader As New StreamReader(myFileWebResponse.GetResponseStream())

       
        Dim readBuffer(256) As [Char]
        
        Dim count As Integer = streamReader.Read(readBuffer, 0, 256)
        
        Console.WriteLine("The contents of the file are :"+ControlChars.Cr)
        
        While count > 0
            Dim str As New [String](readBuffer, 0, count)
            Console.WriteLine(str)
            count = streamReader.Read(readBuffer, 0, 256)
        End While
	     streamReader.Close()
        ' Release the response object resources.
	     myFileWebResponse.Close()
        allDone.Set()
        Console.WriteLine("File reading is over.")
    End Sub ' RespCallback 
End Class ' FileWebRequest_resbeginend

' </Snippet2> 
' </Snippet1>