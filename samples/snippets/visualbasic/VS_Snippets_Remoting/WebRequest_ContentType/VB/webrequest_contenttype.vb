'  System.Net.WebRequest.ContentType System.Net.WebRequest.ContentLength System.Net.WebRequest.GetRequestStream
'  This program demonstrates 'GetRequestStream' method , 'ContentLength' and 'ContentType' properties of 
'	'WebRequestClass'.
'  A new 'WebRequest' object is created and the method used for sending data is set to 'POST' method by setting 
'  The 'Method' property to 'POST'.The 'ContentType' property is set to 'application/x-www-form-urlencoded'.
'  The 'ContentLength' property is set to the length of the Byte stream to be posted. A new 'Stream' object is
'  obtained from the 'GetRequestStream' method of the 'WebRequest' class.Data to be posted is requested from 
'  the user and is posted using the stream object.The HTML contents of the page are then displayed to the 
'  console after the Posted data is accepted by the URL.
'
'  Note: This program POSTs data to the Uri: http://www20.Brinkster.com/codesnippets/next.asp 

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Class WebRequest_ContentLength
    
    Shared Sub Main()
        Try
' <Snippet1>
' <Snippet2>
' <Snippet3>

            ' Create a new request to the mentioned URL. 					
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com ")

            ' Set the 'Method' property of the myWebrequest to POST.	
            myWebRequest.Method = "POST"

            ' Create a new string object to POST data to the above url.
            Console.WriteLine(ControlChars.Cr + "The value of 'ContentLength' property before sending the data is {0}", myWebRequest.ContentLength)
            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to (http://www.contoso.com) Uri")
            Dim inputData As String = Console.ReadLine()
            Dim postData As String = "firstone" + ChrW(61) + inputData
            Dim encoding As New ASCIIEncoding()
            Dim byteArray As Byte() = encoding.GetBytes(postData)



'<Snippet4>


            ' Set the 'ContentType' property of the WebRequest.
            myWebRequest.ContentType = "application/x-www-form-urlencoded"

            ' Set the 'ContentLength' property of the WebRequest.
            myWebRequest.ContentLength = byteArray.Length
            Dim newStream As Stream = myWebRequest.GetRequestStream()
            newStream.Write(byteArray, 0, byteArray.Length)

            ' Close the Stream object.
            newStream.Close()

            ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()

'</Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>

            Console.WriteLine(ControlChars.Cr + "The value of ContentLength property after sending the data is {0}", myWebRequest.ContentLength)
            Console.WriteLine(ControlChars.Cr + "The string entered has been succesfully posted to the Uri.")
            Console.WriteLine(ControlChars.Cr + "Please wait for the response.......")
            Dim streamResponse As Stream = myWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of the Html page are :  " + ControlChars.Cr)
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.WriteLine(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
	         ' Close the Stream objects.
	         streamRead.Close()
	         streamResponse.Close()
	         ' Release the resources of response object.
	         myWebResponse.Close()			
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue.........")
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
End Class ' WebRequest_ContentLength 
