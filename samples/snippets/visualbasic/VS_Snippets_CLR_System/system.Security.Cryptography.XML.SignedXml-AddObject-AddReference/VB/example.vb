' <Snippet1>
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Xml




Public Class XMLdsigsample1
   
   
   Overloads Shared Sub Main(args() As [String])
      Try
         ' Create example data to sign.
         Dim document As New XmlDocument()
         Dim node As XmlNode = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples")
         node.InnerText = "This is some text"
         document.AppendChild(node)
         Console.WriteLine(("Data to sign:" + ControlChars.Lf + document.OuterXml + ControlChars.Lf))
         
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
         
         ' Add the reference to the message.
         signedXml.AddReference(reference)
         
         ' Add a KeyInfo.
         Dim keyInfo As New KeyInfo()
         keyInfo.AddClause(New RSAKeyValue(key))
         signedXml.KeyInfo = keyInfo
         
         ' Compute the signature.
         signedXml.ComputeSignature()
         
         Console.WriteLine("The data was signed.")
      Catch e As CryptographicException
         Console.WriteLine(e.Message)
      End Try
   End Sub 
End Class 
' </Snippet1>