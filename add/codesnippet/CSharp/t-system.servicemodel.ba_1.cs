            BasicHttpBinding binding = new BasicHttpBinding("myBinding");
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.Message;

            BasicHttpSecurity security = binding.Security;
            BasicHttpMessageSecurity msgSecurity = security.Message;

            SecurityAlgorithmSuite sas = msgSecurity.AlgorithmSuite;
            BasicHttpMessageCredentialType credType = msgSecurity.ClientCredentialType;

            Console.WriteLine("The algorithm suite used is {0}", sas.ToString());
            Console.WriteLine("The client credential type used is {0}", credType.ToString());