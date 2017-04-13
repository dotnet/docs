'<SNIPPET1>
Imports System
Imports System.Security.Cryptography.Xml
Imports System.Xml
Imports System.IO


'/ This sample used the EncryptedData class to create a EncryptedData element
'/ and write it to an XML file. It demonstrates the use of CipherReference.
Module Module1

    Sub Main()
        ' Create a URI string.
        Dim uri As String = "http://www.woodgrovebank.com/document.xml"
        ' Create a Base64 transform. The input content retrieved from the
        ' URI should be Base64-decoded before other processing.
        Dim base64 As Transform = New XmlDsigBase64Transform
        Dim tc As New TransformChain
        tc.Add(base64)
        ' Create <CipherReference> information.
        Dim reference As CipherReference = New CipherReference(uri, tc)

        ' Create a new CipherData object.
        ' Note that you cannot assign both a CipherReference and a CipherValue
        ' to a CipherData object.
        Dim cd As CipherData = New CipherData(Reference)

        ' Create a new EncryptedData object.
        Dim ed As New EncryptedData

        'Add an encryption method to the object.
        ed.Id = "ED"
        ed.EncryptionMethod = New EncryptionMethod("http://www.w3.org/2001/04/xmlenc#aes128-cbc")
        ed.CipherData = cd

        'Add key information to the object.
        Dim ki As New KeyInfo
        ki.AddClause(New KeyInfoRetrievalMethod("#EK", "http://www.w3.org/2001/04/xmlenc#EncryptedKey"))
        ed.KeyInfo = ki

        ' Create new XML document and put encrypted data into it.
        Dim doc As New XmlDocument
        Dim encryptionPropertyElement As XmlElement = CType(doc.CreateElement("EncryptionProperty", EncryptedXml.XmlEncNamespaceUrl), XmlElement)
        Dim ep As New EncryptionProperty(encryptionPropertyElement)
        ed.AddProperty(ep)

        ' Output the resulting XML information into a file.
        Dim path As String = "c:\test\MyTest.xml"
        File.WriteAllText(path, ed.GetXml().OuterXml)
    End Sub

End Module
'</SNIPPET1>
