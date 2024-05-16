' <snippet1>
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates

Module Program

    Sub Main(ByVal args() As String)
        Try
            ' Create an XmlDocument object.
            ' <snippet2>
            Dim xmlDoc As New XmlDocument()
            ' </snippet2>
            ' Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("test.xml")

            ' Decrypt the document.
            Decrypt(xmlDoc)

            ' Save the XML document.
            ' <snippet5>
            xmlDoc.Save("test.xml")
            ' </snippet5>
            ' Display the decrypted XML to the console.
            Console.WriteLine("Decrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)

        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub


    Sub Decrypt(ByVal Doc As XmlDocument)
        ' Check the arguments.  
        ArgumentNullException.ThrowIfNull(Doc)

        ' Create a new EncryptedXml object.
        ' <snippet3>
        Dim exml As New EncryptedXml(Doc)
        ' </snippet3>
        ' Decrypt the XML document.
        ' <snippet4>
        exml.DecryptDocument()
        ' </snippet4>
    End Sub
End Module
' </snippet1>
