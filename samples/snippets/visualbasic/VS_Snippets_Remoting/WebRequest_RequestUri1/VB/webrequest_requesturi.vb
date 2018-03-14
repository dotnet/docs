'System.Net.WebRequest.RequestUri
'This program demonstrates the 'Requesturi' property of the WebRequest Class 
' Here the RequestUri property displays the request Uri name to the console.
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Class WebReq
    Shared Sub Main()
	      Try
' <Snippet1>
            ' Create a new WebRequest Object to the mentioned URL.
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
            Console.WriteLine(ControlChars.Cr + ControlChars.Lf +"The Uri that was requested is {0}", myWebRequest.RequestUri)
            ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
			      ' Get the stream containing content returned by the server.
            Dim streamResponse As Stream = myWebResponse.GetResponseStream()
            Console.WriteLine(ControlChars.Cr + ControlChars.Lf + "The Uri that responded to the request is {0}", myWebResponse.ResponseUri)
            ' Print the HTML contents of the page to the console. 
            Dim reader As New StreamReader(streamResponse)
			      ' Read the content.
			      Dim responseFRomServer As String = reader.ReadToEnd()
            ' Display the content.
            Console.WriteLine(ControlChars.Cr + ControlChars.Lf +"The HTML Contents received:")
            Console.WriteLine (responseFromServer)
            ' Cleanup the streams and the response.
            reader.Close ()
            streamResponse.Close ()
            myWebResponse.Close ()
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + " Exception is raised ")
            Console.WriteLine(ControlChars.Cr + "The Error Message is{0} ", e.Message)
            Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + " Exception is raised ")
            Console.WriteLine(ControlChars.Cr + "{0} ", e.Message)
        End Try
    End Sub ' Main
End Class ' WebReq
