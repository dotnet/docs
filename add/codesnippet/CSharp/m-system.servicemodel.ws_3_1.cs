        // The security mode is set to Message.
        WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message);
        binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
        return binding;