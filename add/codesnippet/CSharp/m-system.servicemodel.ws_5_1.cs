        WSHttpBinding binding = new WSHttpBinding();
        binding.Name = "binding1";
        binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
        binding.Security.Mode = SecurityMode.Message;
        binding.ReliableSession.Enabled = false;
        binding.TransactionFlow = false;