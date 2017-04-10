'<SNIPPET1>
Imports System
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml



Module Program

    Sub Main(ByVal args() As String)

        ' Create an XmlDocument object.
        Dim xmlDoc As New XmlDocument()

        ' Load an XML file into the XmlDocument object.
        xmlDoc.PreserveWhitespace = True
        xmlDoc.Load("test.xml")


        ' Create a new TripleDES key. 
        Dim tDESkey As New TripleDESCryptoServiceProvider()

        ' Create a new instance of the TrippleDESDocumentEncryption object
        ' defined in this sample.
        Dim xmlTDES As New TrippleDESDocumentEncryption(xmlDoc, tDESkey)

        Try
            ' Encrypt the "creditcard" element.
            xmlTDES.Encrypt("creditcard")

            ' Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlTDES.Doc.OuterXml)

            ' Decrypt the "creditcard" element.
            xmlTDES.Decrypt()

            ' Display the encrypted XML to the console.
            Console.WriteLine()
            Console.WriteLine("Decrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlTDES.Doc.OuterXml)
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the TripleDES key.
            xmlTDES.Clear()
        End Try

    End Sub 'Main 
End Module 'Program



Class TrippleDESDocumentEncryption
    Protected docValue As XmlDocument
    Protected algValue As TripleDES


    Public Sub New(ByVal Doc As XmlDocument, ByVal Key As TripleDES)
        If Not (Doc Is Nothing) Then
            docValue = Doc
        Else
            Throw New ArgumentNullException("Doc")
        End If

        If Not (Key Is Nothing) Then

            algValue = Key
        Else
            Throw New ArgumentNullException("Key")
        End If

    End Sub


    Public Property Doc() As XmlDocument
        Get
            Return docValue
        End Get
        Set(ByVal value As XmlDocument)
            docValue = value
        End Set
    End Property

    Public Property Alg() As TripleDES
        Get
            Return algValue
        End Get
        Set(ByVal value As TripleDES)
            algValue = value
        End Set
    End Property

    Public Sub Clear()
        If Not (algValue Is Nothing) Then
            algValue.Clear()
        Else
            Throw New Exception("No TripleDES key was found to clear.")
        End If

    End Sub


    Public Sub Encrypt(ByVal Element As String)
        ' Find the element by name and create a new
        ' XmlElement object.
        Dim inputElement As XmlElement = docValue.GetElementsByTagName(Element)(0)

        ' If the element was not found, throw an exception.
        If inputElement Is Nothing Then
            Throw New Exception("The element was not found.")
        End If

        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml(docValue)

        ' Encrypt the element using the symmetric key.
        Dim rgbOutput As Byte() = exml.EncryptData(inputElement, algValue, False)

        ' Create an EncryptedData object and populate it.
        Dim ed As New EncryptedData()

        ' Specify the namespace URI for XML encryption elements.
        ed.Type = EncryptedXml.XmlEncElementUrl

        ' Specify the namespace URI for the TrippleDES algorithm.
        ed.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncTripleDESUrl)

        ' Create a CipherData element.
        ed.CipherData = New CipherData()

        ' Set the CipherData element to the value of the encrypted XML element.
        ed.CipherData.CipherValue = rgbOutput

        ' Replace the plaintext XML elemnt with an EncryptedData element.
        EncryptedXml.ReplaceElement(inputElement, ed, False)

    End Sub


    Public Sub Decrypt()

        ' XmlElement object.
        Dim encryptedElement As XmlElement = docValue.GetElementsByTagName("EncryptedData")(0)

        ' If the EncryptedData element was not found, throw an exception.
        If encryptedElement Is Nothing Then
            Throw New Exception("The EncryptedData element was not found.")
        End If

        ' Create an EncryptedData object and populate it.
        Dim ed As New EncryptedData()
        ed.LoadXml(encryptedElement)

        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml()

        ' Decrypt the element using the symmetric key.
        Dim rgbOutput As Byte() = exml.DecryptData(ed, algValue)

        ' Replace the encryptedData element with the plaintext XML elemnt.
        exml.ReplaceData(encryptedElement, rgbOutput)

    End Sub
End Class
'</SNIPPET1>