' System.Web.Services.Discovery.ContractReference.Contract
' 
' The following example demonstrates the 'Contract' property of the 'ContractReference'
' class.
' It creates an instance of 'DiscoveryDocument' class by reading from a disco file 
' and gets the first reference to a service description in a 'ContractReference' instance.
' Using the 'Contract' property of the 'ContractReference' instance it creates a wsdl 
' file which works as a service description file.' 

Imports System
Imports System.Web.Services.Protocols
Imports System.Net
Imports System.IO
Imports System.Web.Services.Discovery
Imports System.Web.Services.Description


Namespace ConsoleApplication1

' <Snippet1>
   Class MyClass1
      Shared Sub Main()
         Try
            ' Create the file stream.
            Dim discoStream As _
                New FileStream("Service1_vb.disco", FileMode.Open)

            ' Create the discovery document.
            Dim myDiscoveryDocument As _
                DiscoveryDocument = DiscoveryDocument.Read(discoStream)

            ' Get the first ContractReference in the collection.
            Dim myContractReference As ContractReference = _
                CType(myDiscoveryDocument.References(0), ContractReference)

            ' Set the client protocol.
            myContractReference.ClientProtocol = New DiscoveryClientProtocol()
            myContractReference.ClientProtocol.Credentials = _
                CredentialCache.DefaultCredentials

            ' Get the service description.
            Dim myContract As ServiceDescription = myContractReference.Contract

            ' Create the service description file.
            myContract.Write("MyService1.wsdl")
            Console.WriteLine("The WSDL file created is MyService1.wsdl")

            discoStream.Close()

         Catch ex As Exception
            Console.WriteLine("Exception: " + ex.Message)
         End Try
      End Sub 'Main
   End Class 'MyClass1
' </Snippet1>

End Namespace 'ConsoleApplication1 