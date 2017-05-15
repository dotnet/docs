'Sytem.Net.HttpWebRequest.PipeLined
' This program demonstrates  'Pipelined' property of the 'HttpWebRequest' class.
'  A new 'HttpWebRequest' object is created.The 'Pipelined' property is displayed to the console.
'  HTTP Request  and  Response Headers are displayed to the console.The contents of the page of the
'  requested URI are displayed to the console.
'
'Note:The 'Pipelined' property is supported only by servers that allow Pipelining of requests.
'

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Class HttpWebRequest_Pipelined
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Shared Sub Main(args() As String)
        Try
            If args.Length < 2 Then
                Console.WriteLine(ControlChars.Cr + "Please enter the Uri address as a command line parameter:")
                Console.WriteLine("[ Usage:HttpWebRequest_Pipelined http://www.microsoft.com ]")
            Else
                GetPage(args(1))
            End If
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message :{0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub 'Main
    
    Public Shared Sub GetPage(myUri As [String])
        Try
' <Snippet1>
            ' Create a 'HttpWebRequest' object.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
            ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Display the contents of the page to the console
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuffer(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuffer, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of HTML page are.......")
            While count > 0
                Dim outputData As New [String](readBuffer, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuffer, 0, 256)
            End While
            Console.WriteLine(ControlChars.Cr + "HTTP Request  Headers :" + ControlChars.Cr + ControlChars.Cr + "{0}", myHttpWebRequest.Headers)
            Console.WriteLine(ControlChars.Cr + "HTTP Response Headers :" + ControlChars.Cr + ControlChars.Cr + "{0}", myHttpWebResponse.Headers)
            streamRead.Close()
	         streamResponse.Close()
            ' Release the response object resources.
            myHttpWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "'Pipelined' property is:{0}", myHttpWebRequest.Pipelined)
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue......")
            Console.Read()
' </Snippet1>
            
	         
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message : {0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
        End Try
    End Sub ' GetPage 
End Class ' HttpWebRequest_Pipelined
