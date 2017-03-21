                If sp.Certificate Is Nothing Then
                    Console.WriteLine("Certificate = (null)")
                Else
                    Console.WriteLine(("Certificate = " + sp.Certificate.ToString()))
                End If

                If sp.ClientCertificate Is Nothing Then
                    Console.WriteLine("ClientCertificate = (null)")
                Else
                    Console.WriteLine(("ClientCertificate = " + sp.ClientCertificate.ToString()))
                End If

                Console.WriteLine("ProtocolVersion = " + sp.ProtocolVersion.ToString())
                Console.WriteLine(("SupportsPipelining = " + sp.SupportsPipelining.ToString()))