' System.Web.Services.Discovery.DiscoveryDocument.Write(Stream)

' The following example demonstrates the 'Write(Stream)' method
' of the 'DiscoveryDocument' class.
' A XmlTextReader object is created with a sample discovery file and this is
' passed to the Read method to create a DiscoveryDocument. The contents of this
' document are displayed onto the console using the Write(Stream) method.

Imports System
Imports System.Xml
Imports System.IO
Imports System.Web.Services.Discovery
Imports System.Collections

Public Class DiscoveryDocument_Example

   Shared Sub Main()
      Try
' <Snippet1>
         ' Create an object of the 'DiscoveryDocument'.
         Dim myDiscoveryDocument As New DiscoveryDocument()

         ' Create an XmlTextReader with the sample file.
         Dim myXmlTextReader As New XmlTextReader("http://localhost/example_Write1_vb.disco")

         ' Read the given XmlTextReader.
         myDiscoveryDocument = DiscoveryDocument.Read(myXmlTextReader)


         ' Write the DiscoveryDocument into the stream.
         Dim myFileStream As New FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write)
         myDiscoveryDocument.Write(myFileStream)

         myFileStream.Flush()
         myFileStream.Close()

         ' Display the contents of the DiscoveryDocument onto the console.
         Dim myFileStream1 As New FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Read)
         Dim myStreamReader As New StreamReader(myFileStream1)

         ' Set the file pointer to the begin.
         myStreamReader.BaseStream.Seek(0, SeekOrigin.Begin)
         Console.WriteLine("The contents of the DiscoveryDocument are-")
         While myStreamReader.Peek() > - 1
            Console.WriteLine(myStreamReader.ReadLine())
         End While
         myStreamReader.Close()
' </Snippet1>
   Catch e As Exception
         Console.WriteLine("Exception raised : {0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'DiscoveryDocument_Example