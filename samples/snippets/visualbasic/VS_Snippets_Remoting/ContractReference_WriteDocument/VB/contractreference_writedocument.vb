' System.Web.Services.Discovery.ContractReference.WriteDocument

' The following example demonstrates the 'WriteDocument' method of 
' 'ContractReference' class. It creates a 'ContactReference' and a 'FileStream' object. 
' Then it gets the 'ServiceDescription' object corresponding to the 'test.wsdl' file.
' Using the 'WriteDocument' method, the 'ServiceDescription' object is written into the
' file stream.
' Note: The 'TestInput_vb.wsdl' file should exist in the same folder.

Imports System
Imports System.Web.Services.Discovery
Imports System.IO
Imports System.Web.Services.Description

Public Class DiscoveryDocument_Example
   
   Shared Sub Main()
      Try
' <Snippet1>
        Dim myContractReference As New ContractReference()
        Dim myFileStream As New FileStream("TestOutput_vb.wsdl", _
            FileMode.OpenOrCreate, FileAccess.Write)

        ' Get the ServiceDescription for the test .wsdl file.
        Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("TestInput_vb.wsdl")

        ' Write the ServiceDescription into the file stream.
        myContractReference.WriteDocument(myServiceDescription, myFileStream)
        Console.WriteLine("ServiceDescription is written " + _
            "into the file stream successfully.")
        Console.WriteLine("The number of bytes written into the file stream: " + _
            myFileStream.Length.ToString())
        myFileStream.Close()
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception raised:" + e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'DiscoveryDocument_Example