' System.Web.Services.Discovery.ContractReference.ContractReference(string,string)

'  The following example demonstrates the constructor 'ContractReference(string,string)' 
'  of 'ContractReference' class. In this example the 'ContractReference' class constructor
'  initializes a new instance of the 'ContractReference' class using the supplied references
'  to a service description and a XML Web service implementing the service description.The
'  Contract reference object is added to the list of references contained within the 
'  discovery document and a '.disco' file is generated for the webservice where the 
'  reference tags of ContractReference are reflected.

Imports System
Imports System.Xml
Imports System.IO
Imports System.Web.Services.Discovery

Public Class ContractReference_ctor
   
   Shared Sub Main()
      Try
         ' Get a DiscoveryDocument.
         Dim myDiscoveryDocument As New DiscoveryDocument()
' <Snippet1>
         ' Create a ContractReference using a service description 
         ' and an XML Web service.
         Dim myContractReference As New ContractReference  _
             ("http://localhost/Service1.asmx?wsdl", _
              "http://localhost/Service1.asmx")
' </Snippet1>
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