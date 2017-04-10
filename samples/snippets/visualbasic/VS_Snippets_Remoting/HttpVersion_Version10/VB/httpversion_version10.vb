'System.Net.HttpVersion.Version10
'This program demonstrates the  'Version10' field of the 'HttpVersion' Class.
'The 'ProtocolVersion'  property of 'HttpWebrequest' class identifies the Version of the Protocol being used.
'A new 'HttpWebRequest' object is created.
'Then the default value of 'ProtocolVersion' property is displayed to the console.
'The 'Version10' field of the 'HttpVersion' class is assigned to the 'ProtocolVersion' property of the 'HttpWebRequest' Class.
'The changed Version and the 'ProtocolVersion' of the response object are displayed.
'

Imports System
Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic


Class HttpVersion_Version10
    
    Public Shared Sub Main()
        Try
' <Snippet1>
            ' Create a 'HttpWebRequest' object.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the protocol before assignment is :{0}", myHttpWebRequest.ProtocolVersion)
            ' Assign Version10 to ProtocolVersion.
            myHttpWebRequest.ProtocolVersion = HttpVersion.Version10
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the protocol after  assignment is :{0}", myHttpWebRequest.ProtocolVersion)
            Console.WriteLine(ControlChars.Cr + "The 'ProtocolVersion' of the response object is :{0}", myHttpWebResponse.ProtocolVersion)
' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press 'Enter' Key to Continue..............")
            Console.Read()
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
            Console.WriteLine("Source  :{0} ", e.Source)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception Caught!")
            Console.WriteLine("Source  :{0}", e.Source)
            Console.WriteLine("Message :{0}", e.Message)
        End Try
    End Sub ' Main
End Class ' HttpVersion_Version10 


