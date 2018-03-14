
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Class TestApplicationPolicy
    Shared Sub Main()
'<SNIPPET5>
        Dim ch As new X509Chain()
        ch.ChainPolicy.ApplicationPolicy.Add(new Oid("1.2.1.1"))
'</SNIPPET5>
        ' Output chain information about the chain.
        Console.WriteLine ("Chain Information")
        ch.ChainPolicy.RevocationMode = X509RevocationMode.Online
        Console.WriteLine("Chain revocation flag: {0}", ch.ChainPolicy.RevocationFlag)
        Console.WriteLine("Chain revocation mode: {0}", ch.ChainPolicy.RevocationMode)
        Console.WriteLine("Chain verification flag: {0}", ch.ChainPolicy.VerificationFlags)
        Console.WriteLine("Chain verification time: {0}", ch.ChainPolicy.VerificationTime)
        Console.WriteLine("Chain status length: {0}", ch.ChainStatus.Length)
        Console.WriteLine("Chain application policy count: {0}", ch.ChainPolicy.ApplicationPolicy.Count)
        Console.WriteLine("Chain certificate policy count: {0} {1}", ch.ChainPolicy.CertificatePolicy.Count, Environment.NewLine)
    End Sub
End Class
