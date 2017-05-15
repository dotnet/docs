'System.Net.HttpWebRequest.SendChunked  System.Net.HttpWebRequest.TransferEncoding

'  This program demonstrates 'TransferEncoding' and 'SendChunked' 
'  properties of 'HttpWebRequestClass'.
'  A new 'HttpWebRequest' object is created.The 'SendChunked' property 
'  value is set to 'true' and 'TransferEncoding' property is set to "gzip".
'  If 'TransferEncoding' property is set with 'SendChunked' 
'  property set to 'false' then 'InvalidOperationException' is raised.
'  Data to be posted to the Uri is requested from the user.
'  The HTML contents of the page are displayed to the console after the posted 
'  data is accepted by the URL
'
'Note:This program requires http://localhost/CodeSnippetTest.asp as Command line parameter.
'     If the 'TransferEncoding' of type 'gzip' is not implemented by the server an error of status
'     (501) Not implemented' is returned.
'



Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic



Class HttpWebRequest_SendChunked
   Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Sub Main(args() As String)
        Try
            If args.Length < 2 Then
                Console.WriteLine(ControlChars.Cr + "Please enter the Uri address as a command line parameter:")
                Console.WriteLine("[ Usage:HttpWebRequest_Sendchunked http://" + ChrW(60) + "MachineName" + ChrW(62) + "/CodeSnippetTest.asp ]")
            Else
                GetPage(args(1))
            End If
        
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub 'Main
     
    Public Shared Sub GetPage(myUri As [String])
       Try
' <Snippet1>
' <Snippet2>
            ' A new 'HttpWebRequest' object is created.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(myUri), HttpWebRequest)
            myHttpWebRequest.SendChunked = True
            ' 'TransferEncoding' property is set to 'gzip'.
            myHttpWebRequest.TransferEncoding = "gzip"
            Console.WriteLine(ControlChars.Cr + "Please Enter the data to be posted to the (http://" + ChrW(60) + "machine name" + ChrW(62) + "/CodeSnippetTest.asp) uri:")
            Dim inputData As String = Console.ReadLine()
            Dim postData As String = "testdata" + ChrW(61) + inputData
            ' 'Method' property of 'HttpWebRequest' class is set to POST.
            myHttpWebRequest.Method = "POST"
            Dim encodedData As New ASCIIEncoding()
            Dim byteArray As Byte() = encodedData.GetBytes(postData)
            ' 'ContentType' property of the 'HttpWebRequest' class is set to "application/x-www-form-urlencoded".
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            ' 'ContentLength' property is set to Length of the data to be posted.
            myHttpWebRequest.ContentLength = byteArray.Length
            Dim newStream As Stream = myHttpWebRequest.GetRequestStream()
            newStream.Write(byteArray, 0, byteArray.Length)
            newStream.Close()
            Console.WriteLine(ControlChars.Cr + "Data has been posted to the Uri" + ControlChars.Cr + ControlChars.Cr + "Please wait for the response..........")
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Displaying the contents of the page to the console
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of the HTML page are :  ")
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.WriteLine(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
            ' Release the response object resources.  
            streamRead.Close()
            streamResponse.Close()
            myHttpWebResponse.Close()
' </Snippet2>
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue.................")
            Console.Read()
          
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub ' GetPage
End Class ' HttpWebRequest_SendChunked 