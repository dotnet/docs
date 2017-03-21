                TcpTransportSecurity tsTcp = security.Transport;
                Console.WriteLine("\tTcpTransportSecurity:");
                Console.WriteLine("\t\tClient Credential Type: {0}", tsTcp.ClientCredentialType);
                Console.WriteLine("\t\tProtectionLevel: {0}", tsTcp.ProtectionLevel);