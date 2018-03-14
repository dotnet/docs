 'System.Net.HttpWebRequest.AddRange(int,int)
'This program demonstrates 'AddRange(int,int)' method of 'HttpWebRequest class.
'A new 'HttpWebRequest' object is created.The number of characters of the response to be received can be 
'restricted by the 'AddRange' method.By calling 'AddRange(50,150)' on the 'HttpWebRequest' object the content 
'of the response page is restricted from the 50th character to 150th charater.The response of the request is
'obtained and displayed to the console.
'

Imports System
Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic


Class HttpWebRequest_AddRange_int_int
    
    Shared Sub Main()
        Try
' <Snippet1>
            ' A New 'HttpWebRequest' objetc is created.
            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create("http://www.contoso.com")
            myHttpWebRequest.AddRange(50, 150)
            Console.WriteLine("Call AddRange(50, 150)")
			      Console.Write("Resulting Request Headers: ")
			      Console.WriteLine(myHttpWebRequest.Headers.ToString())

            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)

            ' Displays the headers in the response received
            Console.Write("Resulting Response Headers: ")
			      Console.WriteLine(myHttpWebResponse.Headers.ToString())

            ' Displaying the contents of the page to the console
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuffer(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuffer, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The HTML contents of the page from 50th to 150 charaters are :" + ControlChars.Cr + "  ")
            While count > 0
                Dim outputData As New [String](readBuffer, 0, count)
                Console.WriteLine(outputData)
                count = streamRead.Read(readBuffer, 0, 256)
            End While
            ' Release the response object resources.
	         streamRead.Close()
	         streamResponse.Close()
            myHttpWebResponse.Close()
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue...........")
            Console.Read()
        
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
        End Try
    End Sub ' Main
End Class ' HttpWebRequest_AddRange_int_int 


