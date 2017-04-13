' System.Net.HttpWebRequest.Timeout
 'This program demonstrates 'Timeout' property of the HttpWebRequest Class.
' A new HttpWebRequest Object is created .
' The default value of the 'Timeout' property is printed to the console.
' It is then set to a value.Then again it is displayed to the console.
' If the 'Timeout' property is set to a value less than the time required to get the response an Exception is raised.
' 'Timeout' property measures the time in Milliseconds. 
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic



Class HttpWebRequest_Timeout
    
    Shared Sub Main()
	Try
' <Snippet1>
	   ' Create a new 'HttpWebRequest' Object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            Console.WriteLine(ControlChars.Cr + "The timeout time of the request before setting the property is  {0}  milliSeconds", myHttpWebRequest.Timeout)
           ' Set the  'Timeout' property of the HttpWebRequest to 10 milliseconds.
	    myHttpWebRequest.Timeout = 10	
            ' Display the 'Timeout' property of the 'HttpWebRequest' on the console.
            Console.WriteLine(ControlChars.Cr + "The timeout time of the request after setting the timeout is {0}  milliSeconds", myHttpWebRequest.Timeout)
            ' A HttpWebResponse object is created and is GetResponse Property of the HttpWebRequest associated with it 
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
' </Snippet1>
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of the Html page are ")
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
            ' Closing the Stream object.
            streamResponse.Close()
	         streamRead.Close()
	         ' Releasing the HttpWebResponse Resource.
	         myHttpWebResponse.Close()	
            Console.WriteLine(ControlChars.Cr + "Press any Key to Continue.............")
            Console.Read()
        Catch e As WebException
            Console.WriteLine("Exception raised!")
            Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
            Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
	    
        Catch e As Exception
            Console.WriteLine("Exception raised!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
	    
        End Try
    End Sub ' Main
End Class ' HttpWebRequest_Timeout


