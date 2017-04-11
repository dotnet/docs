'<SNIPPET1>
Imports System
Imports System.Security.Cryptography.Xml
Imports System.Xml
Imports System.IO


'/ This sample used the EncryptedData class to create a EncryptedData element
'/ and write it to an XML file.
Module EncryptedDataSample1

    Sub Main()
'<SNIPPET2>
        ' Create a new CipherData object.
        Dim cd As New CipherData
        ' Assign a byte array to the CipherValue.
        cd.CipherValue = New Byte(7) {}
'</SNIPPET2>
'<SNIPPET3>
        ' Create a new EncryptedData object.
        Dim ed As New EncryptedData
'</SNIPPET3>
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
        'End Sub 'Main 'Console.WriteLine(ed.GetXml().OuterXml);
    End Sub

End Module
'</SNIPPET1>