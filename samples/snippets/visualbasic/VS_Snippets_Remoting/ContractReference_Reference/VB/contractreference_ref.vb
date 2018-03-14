' System.Web.Services.Discovery.ContractReference.ctor(String)
' System.Web.Services.Discovery.ContractReference.Ref
' System.Web.Services.Discovery.ContractReference.DocRef
' System.Web.Services.Discovery.ContractReference.Namespace

' The following example demonstrates the constructor, the
' properties 'Ref', 'DocRef' and 'Namespace'. A sample discovery 
' document is read and 'Ref', 'DocRef' and 'Namespace' properties
' are displayed.

Imports System
Imports System.Data
Imports System.Xml
Imports System.Web.Services.Discovery

 Public Class myContractReferenceSample
   
   Public Shared Sub Main()
' <Snippet4>
' <Snippet3>
' <Snippet2>
' <Snippet1>
      ' Call the Constructor of ContractReference.
      Dim myContractReference As New ContractReference()
' </Snippet1>
      Dim myXmlDocument As New XmlDocument()
      
      ' Read the discovery document for the 'contractRef' tag.
      myXmlDocument.Load("http://localhost/Discoverydoc.disco")
      
      Dim myXmlRoot As XmlNode = myXmlDocument.FirstChild
      Dim myXmlNode As XmlNode = myXmlRoot("scl:contractRef")
      Dim myAttributeCollection As XmlAttributeCollection = myXmlNode.Attributes
      
      myContractReference.Ref = myAttributeCollection(0).Value
      Console.WriteLine("The URL to the referenced service description is : {0}", myContractReference.Ref)
' </Snippet2>
      myContractReference.DocRef = myAttributeCollection(1).Value
      Console.WriteLine("The URL implementing the referenced service description is : {0}", myContractReference.DocRef)
' </Snippet3>
      Console.WriteLine("Namespace for the referenced service description is : {0}", ContractReference.Namespace)
' </Snippet4>
   End Sub 'Main
End Class 'myContractReferenceSample