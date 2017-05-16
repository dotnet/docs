'System.Net.HttpWebRequest Headers
'
' This program demonstrates the 'Headers' property of 'HttpWebRequest' Class.
' A new 'HttpWebRequest' object is created.
' The (name,value) collection of the Http Headers are displayed to the console.
' The contents of the HTML page of the requested URI are displayed to the console. 
' 
'

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Class HttpWebRequest_Headers
    
    Public Shared Sub Main()
        Try
' <Snippet1>
            ' Create a new 'HttpWebRequest' Object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            ' Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine(ControlChars.Cr + "The HttpHeaders are " + ControlChars.Cr + ControlChars.Cr + ControlChars.Tab + "Name" + ControlChars.Tab + ControlChars.Tab + "Value" + ControlChars.Cr + "{0}", myHttpWebRequest.Headers)

            ' Print the HTML contents of the page to the console. 
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The HTML contents of page the are  : " + ControlChars.Cr + ControlChars.Cr + " ")
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
	   ' Close the Stream object.
	   streamResponse.Close()
	   streamRead.Close()
	   ' Release the HttpWebResponse Resource.
	    myHttpWebResponse.Close()
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue.........")
            Console.Read()
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message :{0}", e.Message)
            Console.WriteLine("Status  :{0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub ' Main
End Class ' HttpWebRequest_Headers 

