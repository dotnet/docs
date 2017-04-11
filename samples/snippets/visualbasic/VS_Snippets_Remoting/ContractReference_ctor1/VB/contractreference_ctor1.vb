' System.Web.Services.Discovery.ContractReference.ContractReference(string)

' The following example demonstrates the constructor 'ContractReference(string)' 
' of 'ContractReference' class. A 'DiscoveryDocument' object is created .The 
' constructor initializes a new instance of 'ContractReference' using the supplied 
' reference to a Service Description.The Contract reference object is added to the list 
' of references contained within the discovery document. A '.disco' file is generated
' for the webservice, where the reference tags of ContractReference are reflected.

Imports System
Imports System.Xml
Imports System.IO
Imports System.Web.Services.Discovery

Public Class ContractReference_ctor
   
   Shared Sub Main()
      Try
         ' Create a DiscoveryDocument.
         Dim myDiscoveryDocument As New DiscoveryDocument()
' <Snippet1>
         'Create a ContractReference using a reference to a service description.
         Dim myContractReference As _
             New ContractReference("http://localhost/Service1.asmx?wsdl")
' </Snippet1>
         ' Set the URL for an XML Web service implementing the service description.
         myContractReference.DocRef = "http://localhost/service1.asmx"
         Dim myBinding As New SoapBinding()
         myBinding.Binding = New XmlQualifiedName("q1:Service1Soap")
         myBinding.Address = "http://localhost/service1.asmx"
         
         ' Add myContractReference to the list of references contained 
         ' in the discovery document.
         myDiscoveryDocument.References.Add(myContractReference)
         myDiscoveryDocument.References.Add(myBinding)

         ' Open or create a file for writing.
         Dim myFileStream As New FileStream("Service1.disco", _
             FileMode.OpenOrCreate, FileAccess.Write)
         Dim myStreamWriter As New StreamWriter(myFileStream)

         ' Write myDiscoveryDocument into the passed stream.
         myDiscoveryDocument.Write(myStreamWriter)
         Console.WriteLine("The Service1.disco is generated.")
      Catch e As Exception
         Console.WriteLine("Error is " + e.Message)
      End Try
   End Sub 'Main
End Class 'ContractReference_ctor