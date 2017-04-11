' System.Net.HttpWebRequest.Method,System.Net.HttpWebRequest.ContentLength,System.Net.HttpWebRequest.ContentType
' System.Net.HttpWebRequest.GetRequestStream 
' This program demonstrates 'Method', 'ContentLength' and 'ContentType' properties and 'GetRequestStream'
'   method of HttpWebRequest Class.
'   It creates a 'HttpWebRequest' object.The 'Method' property of 'HttpWebRequestClass' is set to 'POST'.
'   The 'ContentType' property is set to 'application/x-www-form-urlencoded'.The 'ContentLength' property 
'   is set to the length of the Byte stream to be posted.A new 'Stream' object is obtained from the 
'   'GetRequestStream' method of the 'HttpWebRequest' class. Data to be posted is requested from the user.
'   Data is posted using the stream object.The HTML contents of the page are then displayed to the console 
'   after the Posted data is accepted by the URL.
'
'Note: This program POSTs data to the Uri: http://www20.Brinkster.com/codesnippets/next.asp 
'


Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic

Class HttpWebRequest_ContentLength
    
    Shared Sub Main()
        Try
            ' Create a new WebRequest Object to the mentione Uri.				
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com/codesnippets/next.asp"), HttpWebRequest)
            Console.WriteLine(ControlChars.Cr + "The value of 'ContentLength' property before sending the data is {0}", myHttpWebRequest.ContentLength)
            ' <Snippet1>
            ' <Snippet4>
            ' Set the 'Method' property of the 'Webrequest' to 'POST'.
            myHttpWebRequest.Method = "POST"
' <Snippet2>
' <Snippet3>

            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) Uri :")
            ' Create a new string object to POST data to the Url.
            Dim inputData As String = Console.ReadLine()
            Dim postData As String = "firstone" + ChrW(61) + inputData
            Dim encoding As New ASCIIEncoding()
            Dim byte1 As Byte() = encoding.GetBytes(postData)
            ' Set the content type of the data being posted.
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            ' Set the content length of the string being posted.
            myHttpWebRequest.ContentLength = byte1.Length
            Dim newStream As Stream = myHttpWebRequest.GetRequestStream()
            newStream.Write(byte1, 0, byte1.Length)
            Console.WriteLine("The value of 'ContentLength' property after sending the data is {0}", myHttpWebRequest.ContentLength)
            newStream.Close()
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "The string entered is successfully posted to the  Uri ")
            Console.WriteLine("Please wait for the response.......")
	   ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
	    Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
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
          ' Close the Stream object.
	    streamResponse.Close()
	    streamRead.Close()
	  ' Release the resources held by  response object.
	    myHttpWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue.............")
            Console.Read()
        Catch e As WebException
            Console.WriteLine("WebException raised!")
            Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
            Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
        Catch e As Exception
            Console.WriteLine("Exception raised!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub ' Main
End Class ' HttpWebRequest_ContentLength 
