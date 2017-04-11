' System.Net.HttpWebResponse.GetResponseStream

' This program demonstrates the 'GetResponseStream' method of the 'HttpWebResponse' class.
'It creates a web request and queries for a response.It then gets the response stream . 
'This response stream is piped to a higher level stream reader. The reader reads 256 characters at a time ,
' writes them into a string and then displays the string in the console

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
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
            Console.WriteLine("HttpWebResponse_GetResponseStream http://www.microsoft.com/net/")
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
            ' Creates an HttpWebRequest for the specified URL. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Sends the request and waits for a response.			
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Calls the method GetResponseStream to return the stream associated with the response.
            Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            ' Pipes the response stream to a higher level stream reader with the required encoding format. 
            Dim readStream As New StreamReader(receiveStream, encode)
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Response stream received")
            Dim read(256) As [Char]
            ' Reads 256 characters at a time.    
            Dim count As Integer = readStream.Read(read, 0, 256)
            Console.WriteLine("HTML..." + ControlChars.Lf + ControlChars.Cr)
            While count > 0
                ' Dumps the 256 characters to a string and displays the string to the console.
                Dim str As New [String](read, 0, count)
                Console.Write(str)
                count = readStream.Read(read, 0, 256)
            End While
            Console.WriteLine("")
            ' Releases the resources of the Stream.
            readStream.Close()
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