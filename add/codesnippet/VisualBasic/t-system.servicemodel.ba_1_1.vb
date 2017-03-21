            Dim binding As BasicHttpBinding = New BasicHttpBinding()
            binding.Name = "binding1"
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard
            binding.Security.Mode = BasicHttpSecurityMode.Message

            Dim security As BasicHttpSecurity = binding.Security
            Dim msgSecurity As BasicHttpMessageSecurity = security.Message

            Dim secMode As BasicHttpSecurityMode = security.Mode

            Dim transSec As HttpTransportSecurity = security.Transport

            Console.WriteLine("The message-level security setting is {0}", secMode.ToString())
            Console.WriteLine("The transport-level security setting is {0}", transSec.ToString())