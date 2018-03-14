'System.Net.HaveResponse 
'This program demonstrates 'HaveResponse' property of 'HttpWebRequest' Class.
'A new 'HttpWebRequest' is created.
'The 'HaveResponse' property is a ReadOnly, boolean property that indicates 
'whether the Requestobject has received any response or not.
'The default vlaue of 'HaveResponse' property of the 'HttpWebRequest' is displayed to the console.
'The HttpWebResponse variable is assigned the response object of 'HttpWebRequest'.
'The HaveReponse property is tested for its value.
'If there is a response then the HTML contents of the page of the requested Uri are displayed to the console 
'else a message 'The response is not received' is displayed to the console.

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic



Class HttpWebRequest_HaveResponse
    
    Public Shared Sub Main()
        
        Try
' <Snippet1>
            ' Create a new 'HttpWebRequest' Object.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            Dim myHttpWebResponse As HttpWebResponse
            ' Display the 'HaveResponse' property of the 'HttpWebRequest' object to the console.
            Console.WriteLine(ControlChars.Cr + "The value of 'HaveResponse' property before a response object is obtained :{0}", myHttpWebRequest.HaveResponse)
            ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            myHttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            If myHttpWebRequest.HaveResponse Then
                Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
                Dim streamRead As New StreamReader(streamResponse)
                Dim readBuff(256) As [Char]
                Dim count As Integer = streamRead.Read(readBuff, 0, 256)
                Console.WriteLine(ControlChars.Cr + "The contents of Html Page are :  " + ControlChars.Cr)
                While count > 0
                    Dim outputData As New [String](readBuff, 0, count)
                    Console.Write(outputData)
                    count = streamRead.Read(readBuff, 0, 256)
                End While
		          '  Close the Stream object.
		          streamResponse.Close()
		          streamRead.Close()
		          ' Release the HttpWebResponse Resource.
		          myHttpWebResponse.Close()
                Console.WriteLine(ControlChars.Cr + "Press 'Enter' key to continue..........")
                Console.Read()
            
            Else
                Console.WriteLine(ControlChars.Cr + "The response is not received ")
            End If
' </Snippet1>        
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught")
            Console.WriteLine(ControlChars.Cr + "Source  :{0}", e.Source)
            Console.WriteLine(ControlChars.Cr + "Message :{0}", e.Message)
        Catch e As Exception
            Console.WriteLine("Exception Caught")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub ' Main 
End Class ' HttpWebRequest_HaveResponse
