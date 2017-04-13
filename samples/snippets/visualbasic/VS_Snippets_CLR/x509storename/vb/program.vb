'<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.IO



Class X509store2

    Shared Sub Main(ByVal args() As String)
        'Opens the personal certificates store.
        Dim store As New X509Store(StoreName.My)
        store.Open(OpenFlags.ReadWrite)
        Dim certificate As New X509Certificate2()

        'Create certificates from certificate files.
        'You must put in a valid path to three certificates in the following constructors.
        Dim certificate1 As New X509Certificate2("c:\mycerts\*****.cer")
        Dim certificate2 As New X509Certificate2("c:\mycerts\*****.cer")
        Dim certificate5 As New X509Certificate2("c:\mycerts\*****.cer")

        'Create a collection and add two of the certificates.
        Dim collection As New X509Certificate2Collection()
        collection.Add(certificate2)
        collection.Add(certificate5)

        'Add certificates to the store.
        store.Add(certificate1)
        store.AddRange(collection)

        Dim storecollection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
        Console.WriteLine("Store name: {0}", store.Name)
        Console.WriteLine("Store location: {0}", store.Location)
        Dim x509 As X509Certificate2
        For Each x509 In storecollection
            Console.WriteLine("certificate name: {0}", x509.Subject)
        Next x509

        'Remove a certificate.
        store.Remove(certificate1)
        Dim storecollection2 As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
        Console.WriteLine("{1}Store name: {0}", store.Name, Environment.NewLine)
        Dim x509a As X509Certificate2
        For Each x509a In storecollection2
            Console.WriteLine("certificate name: {0}", x509a.Subject)
        Next x509a

        'Remove a range of certificates.
        store.RemoveRange(collection)
        Dim storecollection3 As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
        Console.WriteLine("{1}Store name: {0}", store.Name, Environment.NewLine)
        If storecollection3.Count = 0 Then
            Console.WriteLine("Store contains no certificates.")
        Else
            Dim x509b As X509Certificate2
            For Each x509b In storecollection3
                Console.WriteLine("certificate name: {0}", x509b.Subject)
            Next x509b
        End If

        'Close the store.
        store.Close()

    End Sub
End Class
'</SNIPPET1>