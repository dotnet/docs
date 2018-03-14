' System.Net.WebRequest.Headers
' This program demonstrates the 'Headers' property of 'WebRequest' Class.
' A new 'WebRequest' object is created.The (name,value) collection of the HTTP Headers are displayed to the
' console.The contents of the HTML page of the requested URI are displayed to the console. 

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Class WebRequest_Headers
    
    Shared Sub Main()
        Try
' <Snippet1>

            ' Create a new request to the mentioned URL.	
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
            
           ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
           
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
           ' Release the resources of response object.
           
	     myWebResponse.Close()
	    Console.WriteLine(ControlChars.Cr + "The HttpHeaders are " + ControlChars.Cr + "{0}", myWebRequest.Headers)

' </Snippet1>

            Console.WriteLine(ControlChars.Cr + "Press Enter Key to Continue.........")
            Console.Read()
        
        Catch e As WebException
            Console.WriteLine("Exception raised!")
            Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
            Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
        Catch e As Exception
            Console.WriteLine("Exception raised!")
            Console.WriteLine("Source :{0} ", e.Source)
            Console.WriteLine("Message :{0} ", e.Message)

        End Try

    End Sub ' Main 

End Class ' WebRequest_Headers

