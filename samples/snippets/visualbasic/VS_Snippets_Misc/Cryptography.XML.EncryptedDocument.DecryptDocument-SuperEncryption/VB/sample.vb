
Imports System
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml



Module Program

    Sub Main(ByVal args() As String)

    End Sub 'Main



    '<SNIPPET1>
    Sub Decrypt(ByVal Doc As XmlDocument, ByVal Alg As RSA, ByVal KeyName As String)
        ' Check the arguments.  
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        If Alg Is Nothing Then
            Throw New ArgumentNullException("Alg")
        End If
        If KeyName Is Nothing Then
            Throw New ArgumentNullException("KeyName")
        End If
        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml(Doc)

        ' Add a key-name mapping.
        ' This method can only decrypt documents
        ' that present the specified key name.
        exml.AddKeyNameMapping(KeyName, Alg)

        While Doc.GetElementsByTagName("EncryptedData", EncryptedXml.XmlEncNamespaceUrl).Count > 0
            ' Decrypt the element.
            exml.DecryptDocument()
        End While

    End Sub
    '</SNIPPET1>
End Module 'Program 