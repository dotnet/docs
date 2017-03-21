                NetTcpSecurity security = binding.Security;
                MessageSecurityOverTcp msTcp = security.Message;

                Console.WriteLine("Dumping NetTcpSecurity object:");
                Console.WriteLine("\tMessageSecurityOverTcp:");
                Console.WriteLine("\t\tAlgorithm Suite: {0}", msTcp.AlgorithmSuite);
                Console.WriteLine("\t\tClient Credential Type: {0}", msTcp.ClientCredentialType);