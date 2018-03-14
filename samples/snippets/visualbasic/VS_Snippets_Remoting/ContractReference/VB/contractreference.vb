' System.Web.Services.Discovery.ContractReference

'  The following example demonstrates the 'ContractReference' class .
'  A new instance of 'ContractReference' class  is obtained. The
'  Contract reference object is added to the list of references 
'  contained within the discovery document and a '.disco' file is 
'  generated for the Webservice where the reference tags of 
'  ContractReference are reflected.

' <Snippet1>
Imports System
Imports System.Xml
Imports System.IO
Imports System.Web.Services.Discovery

Public Class MyContractReference
   Shared Sub Main()
      Try
         ' Get a 'DiscoveryDocument' object.
         Dim myDiscoveryDocument As New DiscoveryDocument()
         ' Get a 'ContractReference' object.
         Dim myContractReference As New ContractReference()
         ' Set the URL to the referenced service description.
         myContractReference.Ref = "http://localhost/service1.asmx?wsdl"
         ' Set the URL for a XML Web service implementing the service
         ' description .
         myContractReference.DocRef = "http://localhost/service1.asmx"
         Dim myBinding As New SoapBinding()
         myBinding.Binding = New XmlQualifiedName("q1:Service1Soap")
         myBinding.Address = "http://localhost/service1.asmx"
         ' Add 'myContractReference' to the list of references contained 
         ' within the discovery document.
         myDiscoveryDocument.References.Add(myContractReference)
         ' Add 'Binding' to referenceCollection.
         myDiscoveryDocument.References.Add(myBinding)
         ' Open or create a file for writing .
         Dim myFileStream As New FileStream("Service1.disco", FileMode.OpenOrCreate, FileAccess.Write)
         Dim myStreamWriter As New StreamWriter(myFileStream)
         ' Write 'myDiscoveryDocument' into the passed stream.
         myDiscoveryDocument.Write(myStreamWriter)
         Console.WriteLine("The 'Service1.disco' is generated.")
      Catch e As Exception
         Console.WriteLine("Error is" + e.Message)
      End Try
   End Sub 'Main
End Class 'MyContractReference
' </Snippet1>