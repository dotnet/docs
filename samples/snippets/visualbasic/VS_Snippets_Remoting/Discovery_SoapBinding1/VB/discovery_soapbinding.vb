' System.Web.Services.Discovery.SoapBinding.SoapBinding
' System.Web.Services.Discovery.SoapBinding.Address
' System.Web.Services.Discovery.SoapBinding.Binding
' System.Web.Services.Discovery.SoapBinding.Namespace
' System.Web.Services.Discovery.SoapBinding

' The following example demonstrates 'Discovery.SoapBinding' class, its 
' constructor, 'Address', 'Binding' and 'Namespace' members. A variable
' of type 'SoapBinding' is created. The properties are set.
' Finally the created 'SoapBinding' is added to 'DiscoveryClientProtocol'.
' 'DiscoveryClientProtocol' is saved.


' <Snippet1>
Imports System
Imports System.Net
Imports System.Security.Permissions
Imports System.Xml
Imports System.Web.Services.Discovery

Class DiscoverySoapBindingMod

   Shared Sub Main()
      Run()
   End Sub 'Main

   <PermissionSetAttribute(SecurityAction.Demand, Name := "FullTrust")> _
   Shared Sub Run()

      Try

' <Snippet2>

         ' 'dataservice.disco' is a sample discovery document.
         Dim myStringUrl As String = "http://localhost/dataservice.disco"

         ' Call the Discover method to populate the Documents property.
         Dim myDiscoveryClientProtocol As DiscoveryClientProtocol = _
             New DiscoveryClientProtocol()
         myDiscoveryClientProtocol.Credentials = _
             CredentialCache.DefaultCredentials
         Dim myDiscoveryDocument As DiscoveryDocument = _
             myDiscoveryClientProtocol.Discover(myStringUrl)

         Console.WriteLine("Demonstrating the Discovery.SoapBinding class.")

         ' Create a SOAP binding.
         Dim mySoapBinding As SoapBinding = New SoapBinding()

         ' Assign the address to the SOAP binding.
         mySoapBinding.Address = "http://schemas.xmlsoap.org/disco/scl/"

         ' Bind the created SOAP binding with a new XmlQualifiedName.
         mySoapBinding.Binding = New XmlQualifiedName("string", _
             "http://www.w3.org/2001/XMLSchema")

         ' Add the created SOAP binding to the DiscoveryClientProtocol.
         myDiscoveryClientProtocol.AdditionalInformation.Add(mySoapBinding)

         ' Display the namespace associated with the SOAP binding.
         Console.WriteLine("Namespace associated with Soap Binding is: " _
             + SoapBinding.Namespace)

         ' Write all the information of the DiscoveryClientProtocol. 
         myDiscoveryClientProtocol.WriteAll(".","results.discomap")

' </Snippet2>

      Catch e As Exception
         Console.WriteLine(e.ToString)
      End Try

   End Sub 'Run
End Class
' </Snippet1>

