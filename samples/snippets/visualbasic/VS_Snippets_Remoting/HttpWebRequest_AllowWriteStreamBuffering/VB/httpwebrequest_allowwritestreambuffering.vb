' System.Net.HttpWebRequest.AllowWriteStreamBuffering
' This program demonstrates 'AllowWriteStreamBuffering' property of 'HttpWebRequestClass'.
' A new 'HttpWebRequest' object is created.
' The 'AllowWriteStreamBuffering' property value is set to false.
' If the 'AllowWriteStreamBuffering' is set to false,
' then 'ContentLength' property should be set to the length of data to be posted before posting the data 
' else the Http Status(411) Length required is returned.
' Data to be posted to the Uri is requested from the user.
' The 'Method' property is set to POST to be able to post data to the Uri.
' The 'GetRequestStream' method of the 'HttpWebRequest' class returns a stream object.
' This stream object is used to write data to the Uri.
' The HTML contents of the page are displayed to the console after the posted data is accepted by the URL
'
'
' Note:This program posts data to the Uri : http://www20.brinkster.com/codesnippets/next.asp.


Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic



Class HttpWebRequest_AllowWriteStreamBuffering
    Public Shared Sub Main()
        Try
' <Snippet1>
            ' A new 'HttpWebRequest' object is created 				
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com/codesnippets/next.asp"), HttpWebRequest)
           ' AllowWriteStreamBuffering is set to 'false' 
            myHttpWebRequest.AllowWriteStreamBuffering = False
            Console.WriteLine(ControlChars.Cr + "Please Enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) uri:")
            Dim inputData As String = Console.ReadLine()
            Dim postData As String = "firstone" + ChrW(61) + inputData
            ' 'Method' property of 'HttpWebRequest' class is set to POST.
            myHttpWebRequest.Method = "POST"
            Dim encodedData As New ASCIIEncoding()
            Dim byteArray As Byte() = encodedData.GetBytes(postData)
            ' 'ContentType' property of the 'HttpWebRequest' class is set to "application/x-www-form-urlencoded".
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            ' If the AllowWriteStreamBuffering property of HttpWebRequest is set to false,then contentlength has to be set to length of data to be posted else Exception(411) Length required is raised.
             myHttpWebRequest.ContentLength=byteArray.Length
            Dim newStream As Stream = myHttpWebRequest.GetRequestStream()
            newStream.Write(byteArray, 0, byteArray.Length)
            newStream.Close()
            Console.WriteLine(ControlChars.Cr + "Data has been posted to the Uri" + ControlChars.Cr + ControlChars.Cr + "Please wait for the response..........")
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
' </Snippet1>
            Dim StreamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim StreamRead As New StreamReader(StreamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = StreamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of the Html page are :  ")
            While count > 0
                
                Dim outputData As New [String](readBuff, 0, count)
                Console.WriteLine(outputData)
                count = StreamRead.Read(readBuff, 0, 256)
            End While
	         ' Closing the Stream object.
	         streamResponse.Close()
	         streamRead.Close()
	         ' Releasing the WebResponse Resource
	         myHttpWebResponse.Close()
	         Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue.................")
            Console.Read()
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message :{0}", e.Message)
            Console.WriteLine(ControlChars.Cr + "(The 'ContentLength' property of 'HttpWebRequest' is not set after 'AllowWriteStreamBuffering' is set to 'false'.)")
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub 'Main
End Class 'HttpWebRequest_AllowWriteStreamBuffering 
