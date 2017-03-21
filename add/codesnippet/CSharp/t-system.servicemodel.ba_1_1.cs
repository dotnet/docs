            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "binding1";
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.Security.Mode = BasicHttpSecurityMode.Message;
            
            BasicHttpSecurity security = binding.Security;
            BasicHttpMessageSecurity msgSecurity = security.Message;

            BasicHttpSecurityMode secMode = security.Mode;

            HttpTransportSecurity transSec = security.Transport;

            Console.WriteLine("The message-level security setting is {0}", secMode.ToString());
            Console.WriteLine("The transport-level security setting is {0}", transSec.ToString());