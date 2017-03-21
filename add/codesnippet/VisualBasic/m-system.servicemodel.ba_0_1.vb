            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.Message

            Dim security As BasicHttpSecurity = binding.Security
            Dim msgSecurity As BasicHttpMessageSecurity = security.Message

            Dim sas As SecurityAlgorithmSuite = msgSecurity.AlgorithmSuite
            Dim credType As BasicHttpMessageCredentialType = msgSecurity.ClientCredentialType

            Console.WriteLine("The algorithm suite used is {0}", sas.ToString())
            Console.WriteLine("The client credential type used is {0}", credType.ToString())