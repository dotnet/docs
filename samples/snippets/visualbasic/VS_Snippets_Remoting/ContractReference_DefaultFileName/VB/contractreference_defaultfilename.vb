' System.Web.Services.Discovery.ContractReference.DefaultFileName
' System.Web.Services.Discovery.ContractReference.Url

' The following example demonstrates the 'DefaultFilename' and 'Url' properties of 
' 'ContractReference' class. It gets the 'DiscoveryDocument' object using the 
' 'Discover' method of 'DiscoveryClientProtocol' class. It gets the 'ContractReference'
'  object by using the 'References' property of 'DiscoveryDocument' object.Then it displays the
' 'DefaultFileName' and 'Url' properties of 'ContractReference'.

Imports System
Imports System.Web.Services.Discovery
Imports System.Xml.Schema
Imports System.Collections

Public Class DiscoveryDocument_Example
   
   Shared Sub Main()
' <Snippet1>
' <Snippet2>
      Dim myProtocol As New DiscoveryClientProtocol()

      ' Get the DiscoveryDocument.
      Dim myDiscoveryDocument As DiscoveryDocument = _
          myProtocol.Discover("http://localhost/ContractReference/Test_vb.disco")
      Dim myArrayList As ArrayList = _
          CType(myDiscoveryDocument.References, ArrayList)

      ' Get the ContractReference.
      Dim myContractRefrence As ContractReference = _
          CType(myArrayList(0), ContractReference)

      ' Get the DefaultFileName associated with the .disco file.
      Dim myFileName As String  = myContractRefrence.DefaultFilename

      ' Get the URL associated with the .disco file.
      Dim myUrl As String  = myContractRefrence.Url
      Console.WriteLine("The DefaulFilename is: " + myUrl)
      Console.WriteLine("The URL is: " + myUrl)
' </Snippet2>
' </Snippet1>
   End Sub 'Main 
End Class 'DiscoveryDocument_Example 