'  System.Net.WebRequest.Timeout
'  This program demonstrates the 'Timeout' property of the WebRequest Class.
'  A new WebRequest Object is created .
'  The default value of the 'Timeout' property is printed to the console.
'  It is then set to a value.Then again it is displayed to the console.
'  If the 'Timeout' property is set to a value less than the time required to get the response an Exception is raised.
'  'Timeout' property measures the time in Milliseconds.
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Class WebRequest_Timeout
    
    Shared Sub Main()
	Try
' <Snippet1>

            ' Create a new WebRequest Object to the mentioned URL.
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
            Console.WriteLine(ControlChars.Cr + "The Timeout time of the request before setting is : {0} milliseconds", myWebRequest.Timeout)

            ' Set the 'Timeout' property in Milliseconds.
	     myWebRequest.Timeout = 10000

           ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()

' </Snippet1>

            ' Print the Timeout time to the console.
            Console.WriteLine(ControlChars.Cr + "The Timeout time of the request after setting the time is : {0} milliseconds", myWebRequest.Timeout)
            Console.WriteLine(ControlChars.Cr + "Press any Key to Continue...........")
            Console.Read()
            ' Print the HTML contents of the page to the console. 
            Dim streamResponse As Stream = myWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of the Html page of the requested Url are  :")
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
	  ' Close the Stream object.
            streamResponse.Close()
    	    streamRead.Close()
	  ' Release the HttpWebResponse Resource.
	    myWebResponse.Close()
            Console.WriteLine(ControlChars.Cr + "Press any Key to Continue...........")
            Console.Read()
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "Exception is raised ")
            Console.WriteLine(ControlChars.Cr + "{0} ", e.Message)
            Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
        Catch e As Exception
            
            Console.WriteLine(ControlChars.Cr + "Exception is raised ")
            Console.WriteLine(ControlChars.Cr + "{0} ", e.Message)
        End Try
    End Sub ' Main
End Class ' WebRequest_Timeout