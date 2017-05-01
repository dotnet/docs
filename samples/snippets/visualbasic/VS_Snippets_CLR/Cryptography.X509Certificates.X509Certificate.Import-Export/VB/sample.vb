'<SNIPPET1> 
Imports System
Imports System.Security.Cryptography.X509Certificates


Module X509

    Sub Main()

        ' The path to the certificate.
        Dim Certificate As String = "test.pfx"

        ' Load the certificate into an X509Certificate object.
        Dim cert As New X509Certificate(Certificate)


        Dim certData As Byte() = cert.Export(X509ContentType.Cert)

        Dim newCert As New X509Certificate(certData)

        ' Get the value.
        Dim resultsTrue As String = newCert.ToString(True)

        ' Display the value to the console.
        Console.WriteLine(resultsTrue)

        ' Get the value.
        Dim resultsFalse As String = newCert.ToString(False)

        ' Display the value to the console.
        Console.WriteLine(resultsFalse)

    End Sub
End Module
'</SNIPPET1> 