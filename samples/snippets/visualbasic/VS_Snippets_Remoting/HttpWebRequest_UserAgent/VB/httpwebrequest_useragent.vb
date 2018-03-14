 'System.Net.HttpWebRequest.UserAgent
'This program demonstrates 'UserAgent' property of 'HttpWebRequest' Class.
'A new 'HttpWebRequest' object is created.The 'UserAgent' property is set to
'"Mozilla/4.0 (compatible; MSIE 6.0b; Windows NT 5.0; COM+ 1.0.2702)".
'This inturn sets the 'User-Agent' field of HTTP Request headers.
'The response is obtained and displayed to the console.
'

Imports System
Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic


Class HttpWebRequest_UserAgent
   Shared Sub Main()
        Try
' <Snippet1>
           ' Create a new 'HttpWebRequest' object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            myHttpWebRequest.UserAgent= ".NET Framework Test Client"
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            ' Display the contents of the page to the console.
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of HTML Page are :" + ControlChars.Cr)
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
            streamRead.Close()
	         streamResponse.Close()    
          ' Release the response object resources.
	         myHttpWebResponse.Close()
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "HTTP Request Headers :" + ControlChars.Cr + "{0}", myHttpWebRequest.Headers)
            Console.WriteLine(ControlChars.Cr + "UserAgent is:{0}", myHttpWebRequest.UserAgent)
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue...........")
            Console.Read()
        	   
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
            Console.WriteLine("Status  :{0} ", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine(("Source  : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub ' Main 
End Class ' HttpWebRequest_UserAgent


