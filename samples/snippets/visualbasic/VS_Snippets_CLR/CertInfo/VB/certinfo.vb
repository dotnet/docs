'<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Permissions
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.VisualBasic




Class CertInfo

    'Reads a file.
    Friend Shared Function ReadFile(ByVal fileName As String) As Byte()
        Dim f As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim size As Integer = Fix(f.Length)
        Dim data(size) As Byte
        size = f.Read(data, 0, size)
        f.Close()
        Return data

    End Function 

    <SecurityPermission(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Shared Sub Main(ByVal args() As String)
        'Test for correct number of arguments.
        If args.Length < 1 Then
            Console.WriteLine("Usage: CertInfo <filename>")
            Return
        End If
        Try
            Dim x509 As New X509Certificate2()
            'Create X509Certificate2 object from .cer file.
            Dim rawData As Byte() = ReadFile(args(0))
            
            x509.Import(rawData)

            'Print to console information contained in the certificate.
            Console.WriteLine("{0}Subject: {1}{0}", Environment.NewLine, x509.Subject)
            Console.WriteLine("{0}Issuer: {1}{0}", Environment.NewLine, x509.Issuer)
            Console.WriteLine("{0}Version: {1}{0}", Environment.NewLine, x509.Version)
            Console.WriteLine("{0}Valid Date: {1}{0}", Environment.NewLine, x509.NotBefore)
            Console.WriteLine("{0}Expiry Date: {1}{0}", Environment.NewLine, x509.NotAfter)
            Console.WriteLine("{0}Thumbprint: {1}{0}", Environment.NewLine, x509.Thumbprint)
            Console.WriteLine("{0}Serial Number: {1}{0}", Environment.NewLine, x509.SerialNumber)
            Console.WriteLine("{0}Friendly Name: {1}{0}", Environment.NewLine, x509.PublicKey.Oid.FriendlyName)
            Console.WriteLine("{0}Public Key Format: {1}{0}", Environment.NewLine, x509.PublicKey.EncodedKeyValue.Format(True))
            Console.WriteLine("{0}Raw Data Length: {1}{0}", Environment.NewLine, x509.RawData.Length)
            Console.WriteLine("{0}Certificate to string: {1}{0}", Environment.NewLine, x509.ToString(True))

            Console.WriteLine("{0}Certificate to XML String: {1}{0}", Environment.NewLine, x509.PublicKey.Key.ToXmlString(False))

            'Add the certificate to a X509Store.
            Dim store As New X509Store()
            store.Open(OpenFlags.MaxAllowed)
            store.Add(x509)
            store.Close()

        Catch dnfExcept As DirectoryNotFoundException
            Console.WriteLine("Error: The directory specified could not be found.")
        Catch ioExpcept As IOException
            Console.WriteLine("Error: A file in the directory could not be accessed.")
        Catch nrExcept As NullReferenceException
            Console.WriteLine("File must be a .cer file. Program does not have access to that type of file.")
        End Try

    End Sub
End Class
'</SNIPPET1>