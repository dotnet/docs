'<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.IO



Class TestX509Chain

    Shared Sub Main(ByVal args() As String)
        '<SNIPPET2>
        'Create new X509 store from local certificate store.
        Dim store As New X509Store("MY", StoreLocation.CurrentUser)
        store.Open(OpenFlags.OpenExistingOnly Or OpenFlags.ReadWrite)

        'Output store information.
        Console.WriteLine("Store Information")
        Console.WriteLine("Number of certificates in the store: {0}", store.Certificates.Count)
        Console.WriteLine("Store location: {0}", store.Location)
        Console.WriteLine("Store name: {0} {1}", store.Name, Environment.NewLine)

        'Put certificates from the store into a collection so user can select one.
        Dim fcollection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
        Dim collection As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(fcollection, "Select an X509 Certificate", "Choose a certificate to examine.", X509SelectionFlag.SingleSelection)
        Dim certificate As X509Certificate2 = collection(0)
        X509Certificate2UI.DisplayCertificate(certificate)
        '</SNIPPET2>
        '<SNIPPET3>
        'Output chain information of the selected certificate.
        Dim ch As New X509Chain()
        ch.Build(certificate)
        Console.WriteLine("Chain Information")
        ch.ChainPolicy.RevocationMode = X509RevocationMode.Online
        Console.WriteLine("Chain revocation flag: {0}", ch.ChainPolicy.RevocationFlag)
        Console.WriteLine("Chain revocation mode: {0}", ch.ChainPolicy.RevocationMode)
        Console.WriteLine("Chain verification flag: {0}", ch.ChainPolicy.VerificationFlags)
        Console.WriteLine("Chain verification time: {0}", ch.ChainPolicy.VerificationTime)
        Console.WriteLine("Chain status length: {0}", ch.ChainStatus.Length)
        Console.WriteLine("Chain application policy count: {0}", ch.ChainPolicy.ApplicationPolicy.Count)
        Console.WriteLine("Chain certificate policy count: {0} {1}", ch.ChainPolicy.CertificatePolicy.Count, Environment.NewLine)
        '</SNIPPET3>
        '<SNIPPET4>
        'Output chain element information.
        Console.WriteLine("Chain Element Information")
        Console.WriteLine("Number of chain elements: {0}", ch.ChainElements.Count)
        Console.WriteLine("Chain elements synchronized? {0} {1}", ch.ChainElements.IsSynchronized, Environment.NewLine)

        Dim element As X509ChainElement
        For Each element In ch.ChainElements
            Console.WriteLine("Element issuer name: {0}", element.Certificate.Issuer)
            Console.WriteLine("Element certificate valid until: {0}", element.Certificate.NotAfter)
            Console.WriteLine("Element certificate is valid: {0}", element.Certificate.Verify())
            Console.WriteLine("Element error status length: {0}", element.ChainElementStatus.Length)
            Console.WriteLine("Element information: {0}", element.Information)
            Console.WriteLine("Number of element extensions: {0}{1}", element.Certificate.Extensions.Count, Environment.NewLine)

            If ch.ChainStatus.Length > 1 Then
                Dim index As Integer
                For index = 0 To element.ChainElementStatus.Length
                    Console.WriteLine(element.ChainElementStatus(index).Status)
                    Console.WriteLine(element.ChainElementStatus(index).StatusInformation)
                Next index
            End If
        Next element
        store.Close()
        '</SNIPPET4>
    End Sub
End Class
'</SNIPPET1>