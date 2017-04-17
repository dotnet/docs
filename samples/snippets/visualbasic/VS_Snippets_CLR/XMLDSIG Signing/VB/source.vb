'<Snippet1>
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Xml

 _


Public Class XMLdsigsample1

   Shared Sub Main(args() As [String])
      ' Create example data to sign.
      Dim document As New XmlDocument()
      Dim node As XmlNode = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples")
      node.InnerText = "This is some text"
      document.AppendChild(node)
      Console.Error.WriteLine("Data to sign:")
      Console.Error.WriteLine()
      Console.Error.WriteLine(document.OuterXml)
      Console.Error.WriteLine()
      
      ' Create the SignedXml message.
      Dim signedXml As New SignedXml()
      Dim key As RSA = RSA.Create()
      signedXml.SigningKey = key
      
      ' Create a data object to hold the data to sign.
      Dim dataObject As New DataObject()
      dataObject.Data = document.ChildNodes
      dataObject.Id = "MyObjectId"
      
      ' Add the data object to the signature.
      signedXml.AddObject(dataObject)
      
      ' Create a reference to be able to package everything into the
      ' message.
      Dim reference As New Reference()
      reference.Uri = "#MyObjectId"
      
      ' Add it to the message.
      signedXml.AddReference(reference)
      
      ' Add a KeyInfo.
      Dim keyInfo As New KeyInfo()
      keyInfo.AddClause(New RSAKeyValue(key))
      signedXml.KeyInfo = keyInfo
      
      ' Compute the signature.
      signedXml.ComputeSignature()
      
      ' Get the XML representation of the signature.
      Dim xmlSignature As XmlElement = signedXml.GetXml()
      Console.WriteLine(xmlSignature.OuterXml)
   End Sub 'Main
End Class 'XMLdsigsample1 
'</Snippet1>