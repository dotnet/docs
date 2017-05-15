'<SNIPPET1>
Imports System
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml



Class XmlLicenseTransformExample

    Public Shared Sub Main()

    End Sub


    '<SNIPPET2>
    Public Shared Sub CheckSignatureWithEncryptedGrant(ByVal fileName As String, ByVal decryptor As IRelDecryptor)
        ' Create a new XML document.
        Dim xmlDocument As New XmlDocument()
        Dim nsManager As New XmlNamespaceManager(xmlDocument.NameTable)

        ' Format using whitespaces.
        xmlDocument.PreserveWhitespace = True

        ' Load the passed XML file into the document. 
        xmlDocument.Load(fileName)
        nsManager.AddNamespace("dsig", SignedXml.XmlDsigNamespaceUrl)

        ' Find the "Signature" node and create a new XmlNodeList object.
        Dim nodeList As XmlNodeList = xmlDocument.SelectNodes("//dsig:Signature", nsManager)

        Dim count = nodeList.Count
        Dim i As Integer

        For i = 0 To count
            Dim clone As XmlDocument = xmlDocument.Clone()
           
            Dim signatures As XmlNodeList = clone.SelectNodes("//dsig:Signature", nsManager)

            ' Create a new SignedXml object and pass into it the XML document clone.
            Dim signedXml As New SignedXml(clone)

            ' Load the signature node.
            signedXml.LoadXml(CType(signatures(i), XmlElement))

            ' Set the context for license transform
            Dim trans As Transform = CType(signedXml.SignedInfo.References(0), Reference).TransformChain(0)

            If TypeOf trans Is XmlLicenseTransform Then

                ' Decryptor is used to decrypt encryptedGrant elements.
                If Not (decryptor Is Nothing) Then
                    CType(trans, XmlLicenseTransform).Decryptor = decryptor
                End If

            End If

            ' Check the signature and display the result.
            Dim result As Boolean = signedXml.CheckSignature()

            If result Then
                Console.WriteLine("SUCCESS: CheckSignatureWithEncryptedGrant - issuer index #" + i.ToString())
            Else
                Console.WriteLine("FAILURE: CheckSignatureWithEncryptedGrant - issuer index #" + i.ToString())
            End If
        Next i

    End Sub
End Class
'</SNIPPET2>

'</SNIPPET1>