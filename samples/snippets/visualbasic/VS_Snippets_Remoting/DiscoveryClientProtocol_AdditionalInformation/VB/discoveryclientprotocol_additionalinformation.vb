' System.Web.Services.Discovery.SoapBinding.SoapBinding
' System.Web.Services.Discovery.SoapBinding.Address
' System.Web.Services.Discovery.SoapBinding.Binding
' System.Web.Services.Discovery.SoapBinding.Namespace
' System.Web.Services.Discovery.SoapBinding

' The following example demonstrates 'Discovery.SoapBinding' class, its 
' constructor, 'Address', 'Binding' and 'Namespace' members. A variable
' of type 'SoapBinding' is created. The mentioned properties are set.
' This information is added to  'DiscoveryClientProtocol' of a discovery file.
'

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

            ' dataservice.disco is a sample discovery document.
            Dim myStringUrl As String = "http://localhost/dataservice.disco"

            ' Call the Discover method to populate the Documents property.
            Dim myDiscoveryClientProtocol As DiscoveryClientProtocol = _
                New DiscoveryClientProtocol()
            myDiscoveryClientProtocol.Credentials = _
                CredentialCache.DefaultCredentials
            Dim myDiscoveryDocument As DiscoveryDocument = _
                myDiscoveryClientProtocol.Discover(myStringUrl)

            Dim mySoapBinding As SoapBinding = New SoapBinding()
            mySoapBinding.Address = "http://schemas.xmlsoap.org/disco/scl/"
            mySoapBinding.Binding = New XmlQualifiedName("string", _
                "http://www.w3.org/2001/XMLSchema")
            myDiscoveryClientProtocol.AdditionalInformation.Add(mySoapBinding)

            ' Write the information back. 
            myDiscoveryClientProtocol.WriteAll("MyDirectory", _
                "results.discomap")

            Dim myIList As System.Collections.IList = _
                myDiscoveryClientProtocol.AdditionalInformation
            mySoapBinding = Nothing
            mySoapBinding = CType(myIList(0),SoapBinding)
            Console.WriteLine("The address of the SoapBinding associated " _
                & "with AdditionalInformation is: " & mySoapBinding.Address)
        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try

    End Sub 'Run
End Class

' </Snippet1>
