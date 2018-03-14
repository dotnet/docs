'<SNIPPET4>
Imports System
Imports System.Security.Cryptography.Xml
Imports System.Xml
Imports System.IO


'/ This sample used the EncryptedData class to create a EncryptedData element
'/ and write it to an XML file.
Module EncryptedDataSample1

    Sub Main()
'<SNIPPET3>
'<SNIPPET1>

        ' Create a new CipherData object using a byte array to represent encrypted data.
	Dim sampledata(7) As Byte
        Dim cd As New CipherData(sampledata)

'</SNIPPET1>

        ' Create a new EncryptedData object.
        Dim ed As New EncryptedData

        'Add an encryption method to the object.
        ed.Id = "ED"
        ed.EncryptionMethod = New EncryptionMethod("http://www.w3.org/2001/04/xmlenc#aes128-cbc")
        ed.CipherData = cd

'</SNIPPET3>
'<SNIPPET2>
        'Add key information to the object.
        Dim ki As New KeyInfo
        ki.AddClause(New KeyInfoRetrievalMethod("#EK", "http://www.w3.org/2001/04/xmlenc#EncryptedKey"))
        ed.KeyInfo = ki

'</SNIPPET2>
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
'</SNIPPET4>