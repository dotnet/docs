' <snippet1>
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml

Module Program

    Sub Main(ByVal args() As String)

        ' Create an XmlDocument object.
        ' <snippet4>
        Dim xmlDoc As New XmlDocument()

        ' Load an XML file into the XmlDocument object.
        Try
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("test.xml")
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        ' </snippet4>
        ' <snippet2>
        Dim cspParams As New CspParameters()
        cspParams.KeyContainerName = "XML_ENC_RSA_KEY"
        ' </snippet2>
        ' Get the RSA key from the key container.  This key will decrypt 
        ' a symmetric key that was imbedded in the XML document. 
        ' <snippet3>
        Dim rsaKey As New RSACryptoServiceProvider(cspParams)
        ' </snippet3>
        Try

            ' Decrypt the elements.
            Decrypt(xmlDoc, rsaKey, "rsaKey")

            ' Save the XML document.
            ' <snippet8>
            xmlDoc.Save("test.xml")
            ' </snippet8>
            ' Display the encrypted XML to the console.
            Console.WriteLine()
            Console.WriteLine("Decrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the RSA key.
            rsaKey.Clear()
        End Try


        Console.ReadLine()

    End Sub



    Sub Decrypt(ByVal Doc As XmlDocument, ByVal Alg As RSA, ByVal KeyName As String)
        ' Check the arguments.  
        ArgumentNullException.ThrowIfNull(Doc)
        ArgumentNullException.ThrowIfNull(Alg)
        ArgumentNullException.ThrowIfNull(KeyName)

        ' <snippet5>
        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml(Doc)
        ' </snippet5>
        ' Add a key-name mapping.
        ' This method can only decrypt documents
        ' that present the specified key name.
        ' <snippet6>
        exml.AddKeyNameMapping(KeyName, Alg)
        ' </snippet6>
        ' Decrypt the element.
        ' <snippet7>
        exml.DecryptDocument()
        '</snippet7>
    End Sub
End Module
' </snippet1>
