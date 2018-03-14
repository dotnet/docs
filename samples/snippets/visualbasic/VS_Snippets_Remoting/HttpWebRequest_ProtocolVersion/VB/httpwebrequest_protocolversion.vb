'System.Net.HttpWebRequest.ProtocolVersion
' This Program demonstrates  the 'PrtocolVersion' property of the HttpWebRequest Class.
'The 'ProtocolVersion' is a property that identifies the Version of the Protocol being used.
'A new HttpWebRequest object is created.
'First the default version being used is displayed to the console.
'It is then set to another version.
'Then again it is displayed to the Console.
'The Html contents of the page of the requested Uri Are printed to the console.
'Here the 'ProtocolVersion' property displays the ProtocolVersion being used  

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic



Class HttpWebRequest_ProtocolVersion
    
    Shared Sub Main()
	Try
' <Snippet1>
            ' Create a new 'HttpWebRequest' Object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)
            ' Use the existing 'ProtocolVersion' , and display it onto the console.	
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the protocol used is {0}", myHttpWebRequest.ProtocolVersion)
            ' Set the 'ProtocolVersion' property of the 'HttpWebRequest' to 'Version1.0' .
            myHttpWebRequest.ProtocolVersion = HttpVersion.Version10
            '  Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the protocol changed to {0}", myHttpWebRequest.ProtocolVersion)
            Console.WriteLine(ControlChars.Cr + "The protocol version of the response object is {0}", myHttpWebResponse.ProtocolVersion)
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press any Key to Continue..............")
            Console.Read()
     	    Console.Read()
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of the Html Page are  :")
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
		 Console.WriteLine(ControlChars.Cr + "Press any Key to Continue..............")
	         Console.Read()
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
End Class ' HttpWebRequest_ProtocolVersion


