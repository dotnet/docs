' System.Net.HttpWebRequest.AllowAutoRedirect System.Net.HttpWebRequest.Address
' This program demonstrates  'AllowAutoRedirect' and 'Address' properties of HttpWebRequest Class.
' A new HttpWebRequest Object is created.
' AllowAutoredirect is a property that redirects a page automatically to the new Uri.
' The 'AllowAutoRedirect' property is set to true.
' Using the 'Address' property the address of the Responding Uri is printed to console.
' The contents of the redirected page are displayed to the console.

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic



Class HttpWebRequest_AllowAutoRedirect
    
    Shared Sub Main()
     Try
    ' <Snippet1>
    ' <Snippet2>
   
	    'This method creates a new HttpWebRequest Object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            myHttpWebRequest.MaximumAutomaticRedirections = 1
            myHttpWebRequest.AllowAutoRedirect = True
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
    '</Snippet2>
            Dim streamResponse As Stream = myHttpWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of Html Page are :  ")
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
	    Console.WriteLine(ControlChars.Cr + "The Requested Uri is {0}", myHttpWebRequest.RequestUri)
            Console.WriteLine(ControlChars.Cr + "The Actual Uri responding to the request is " + ControlChars.Cr + "{0}", myHttpWebRequest.Address)	
   ' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press any Key to Continue..........")
            Console.Read()
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
            Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
          
        Catch e As Exception
            Console.WriteLine("Exception raised!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
	   
        End Try
    End Sub ' Main
End Class ' HttpWebRequest_AllowAutoRedirect


