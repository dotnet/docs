 'System.Net.WebRequest.Create(Uri)
'
'This program demonstrates the 'Create(Uri)' method of the 'WebRequest' class.
'A new 'Uri' object is created to the specified Uri.
'A new 'WebRequest' object is created to the 'specified' Uri by passing the 'Uri' object as parameter.
'The response is obtained .
'The HTML contents of the page of the requested Uri are displayed to the console.
'
'

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic


Class WebRequest_Create_Uri
    
    Public Shared Sub Main()
        Try
' <Snippet1>
            ' Create a new 'Uri' object with the specified string.
            Dim myUri As New Uri("http://www.contoso.com")
            ' Create a new request to the above mentioned URL.	
            Dim myWebRequest As WebRequest = WebRequest.Create(myUri)
            '  Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
' </Snippet1>
            Dim streamResponse As Stream = myWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of HTML Page are :  " + ControlChars.Cr)
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
	    ' Close the Stream object.
	     streamResponse.Close()
	     streamRead.Close()
	   ' Release the WebResponse Resource.
	    myWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' key to continue.................")
            Console.Read()
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Source   :{0}", e.Source)
            Console.WriteLine("Message  :{0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Source   :{0} ", e.Source)
            Console.WriteLine("Message  :{0} ", e.Message)
        End Try
    End Sub ' Main 
End Class ' WebRequest_Create_Uri