'<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates



Module CertSelect

    Sub Main()
        Try
            Dim store As New X509Store("MY", StoreLocation.CurrentUser)
            store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

            Dim collection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
            Dim i As Integer
            For i = 0 To collection.Count
                Dim extension As X509Extension
                For Each extension In collection(i).Extensions
                    Console.WriteLine(extension.Oid.FriendlyName + "(" + extension.Oid.Value + ")")


                    If extension.Oid.FriendlyName = "Key Usage" Then
                        Dim ext As X509KeyUsageExtension = CType(extension, X509KeyUsageExtension)
                        Console.WriteLine(ext.KeyUsages)
                    End If

                    If extension.Oid.FriendlyName = "Basic Constraints" Then
                        Dim ext As X509BasicConstraintsExtension = CType(extension, X509BasicConstraintsExtension)
                        Console.WriteLine(ext.CertificateAuthority)
                        Console.WriteLine(ext.HasPathLengthConstraint)
                        Console.WriteLine(ext.PathLengthConstraint)
                    End If

                    If extension.Oid.FriendlyName = "Subject Key Identifier" Then
                        Dim ext As X509SubjectKeyIdentifierExtension = CType(extension, X509SubjectKeyIdentifierExtension)
                        Console.WriteLine(ext.SubjectKeyIdentifier)
                    End If

                    If extension.Oid.FriendlyName = "Enhanced Key Usage" Then
                        Dim ext As X509EnhancedKeyUsageExtension = CType(extension, X509EnhancedKeyUsageExtension)
                        Dim oids As OidCollection = ext.EnhancedKeyUsages
                        Dim oid As Oid
                        For Each oid In oids
                            Console.WriteLine(oid.FriendlyName + "(" + oid.Value + ")")
                        Next oid
                    End If
                Next extension
            Next i
            store.Close()
        Catch
            Console.WriteLine("Information could not be written out for this certificate.")
        End Try

    End Sub
End Module
'</SNIPPET1>