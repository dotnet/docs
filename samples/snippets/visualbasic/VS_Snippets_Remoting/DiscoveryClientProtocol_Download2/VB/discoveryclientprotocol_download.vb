' System.web.Services.Discovery.DiscoveryClientProtocol.Download(string,string)

' The following example demonstrates the usage of the 'Download' method
' of the class 'DiscoveryClientProtocol'. The input to the program is
' a discovery file 'MathService_vb.vsdisco'. It generates a 'Stream' 
' instance of the discovery file 'MathService_vb.vsdisco' from the 
' 'Download' method of 'DiscoveryClientPrototocol' and prints out 
' the 'contentType' and length in bytes of the discoverydocument.
Option Strict On
Imports System
Imports System.Web.Services.Discovery
Imports System.Collections
Imports System.IO

Public Class DiscoveryClientProtocol_Download
   
   Public Shared Sub Main()
' <Snippet1>
      Dim myDiscoFile As String = "http://localhost/MathService_vb.vsdisco"
      Dim myEncoding As String = ""
      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      
      Dim myStream As Stream = myDiscoveryClientProtocol.Download(myDiscoFile, myEncoding)
      Console.WriteLine("The length of the stream in bytes: " & myStream.Length)
      Console.WriteLine _
            ("The MIME encoding of the downloaded discovery document: " & myEncoding)
      myStream.Close()
' </Snippet1>
   End Sub 'Main
End Class 'DiscoveryClientProtocol_Download 